using BusinessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugiKolokvijumskiZadatak
{
    public partial class frmEditOrder : Form
    {
        int orderID;
        OrderDTO orderDTO;
        OrderDetailsDTO detailsDTO;
        OrderBL orderBl;
        ProductBL productBl;
        CustomerBL customerBl;
        EmployeeBL employeeBl;
        ShipperBL shipperBl;
        public frmEditOrder(int orderId)
        {
            InitializeComponent();
            orderID = orderId;

            orderDTO = new OrderBL().GetOrder(orderId);
            detailsDTO = new OrderDetailsBL().GetOrderDetail(orderId);
            orderBl = new OrderBL();
            productBl = new ProductBL();
            customerBl = new CustomerBL();
            employeeBl = new EmployeeBL();
            shipperBl = new ShipperBL();
        }
    }
}
