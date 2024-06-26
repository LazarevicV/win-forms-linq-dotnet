﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderDL
    {
        private readonly NorthwindEntities _context;

        public OrderDL()
        {
            _context = new NorthwindEntities();
        }

        public int Insert(OrderDTO oDTO)
        {
            var orderDetail = Mapper.MapToEntity(oDTO);
            _context.Orders.Add(orderDetail);
            _context.SaveChanges();

            return orderDetail.OrderID;
        }

        public void Delete(int OrderId)
        {
            var orderDetails = _context.Orders.Where(od => od.OrderID == OrderId).ToList();

            _context.Orders.RemoveRange(orderDetails);
            _context.SaveChanges();
        }

        public void Save(OrderDTO oDTO)
        {
            var order = _context.Orders.Find(oDTO.OrderID);
            if (order != null)
            {

                order.OrderID = oDTO.OrderID;
                order.CustomerID = oDTO.CustomerID;
                order.ShipAddress = oDTO.ShipAddress;
                order.ShipCity = oDTO.ShipCity;
                order.ShipRegion = oDTO.ShipRegion;
                order.ShipPostalCode = oDTO.ShipPostalCode;
                order.ShipCountry = oDTO.ShipCountry;
                order.ShipName = oDTO.ShipName;
                order.EmployeeID = oDTO.EmployeeID;
                order.OrderDate = oDTO.OrderDate;
                order.ShipVia = oDTO.ShipVia;

                _context.SaveChanges();
            }
        }

        public OrderDTO GetSingle(int orderId)
        {
            OrderDTO order;
            var orderDB = _context.Orders.SingleOrDefault(od => od.OrderID == orderId);

            order = Mapper.MapToDTO(orderDB);

            return order;
        }

        public List<OrderDTO> GetAll()
        {
            var orders = _context.Orders.ToList();

            return Mapper.convertToList(orders);
        }

        public List<OrderDTO> SearchOrders(int? employeeID, string customerID, int? productID)
        {
            var results = _context.spSearchOrders(employeeID, customerID, productID).ToList();
            return Mapper.convertToList(results);
        }
    }
}
