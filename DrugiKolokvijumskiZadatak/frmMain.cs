﻿using BusinessLayer;
using DataLayer;
using DrugiKolokvijumZadatak;
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
    public partial class frmMain : Form
    {
        OrderBL orderBl;
        ProductBL productBl;
        CustomerBL customerBl;
        EmployeeBL employeeBl;
        public frmMain()
        {
            InitializeComponent();
            orderBl = new OrderBL();
            productBl = new ProductBL();
            customerBl = new CustomerBL();
            employeeBl = new EmployeeBL();
        }

        private void SearchOrders()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                int? selectedEmployeeId = null;
                if (cmbEmployee.SelectedIndex != -1 && cmbEmployee.SelectedValue != null && cmbEmployee.SelectedValue is int)
                {
                    selectedEmployeeId = (int)cmbEmployee.SelectedValue;
                }

                string selectedCustomerId = cmbCustomer.SelectedIndex != -1 ? cmbCustomer.SelectedValue.ToString() : null;

                int? selectedProductId = null;
                if (cmbProduct.SelectedIndex != -1 && cmbProduct.SelectedValue != null && cmbProduct.SelectedValue is int)
                {
                    selectedProductId = (int)cmbProduct.SelectedValue;
                }

                var orders = orderBl.SearchOrders(selectedEmployeeId, selectedCustomerId, selectedProductId);
                dataGrid.DataSource = orders;
                dataGrid.Refresh();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            frmNewOrder fo = new frmNewOrder();
            fo.ShowDialog();
            dataGrid.DataSource = orderBl.GetAllOrders();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbEmployee.SelectedIndex = -1;
            cmbCustomer.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOrders();
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOrders();
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOrders();
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void setup_datagrid()
        {
            dataGrid.Columns.Clear();
            // Display preview button for order details
            DataGridViewButtonColumn btnColumnPreview = new DataGridViewButtonColumn();
            btnColumnPreview.HeaderText = "Order Details";
            btnColumnPreview.Text = "Preview";
            btnColumnPreview.UseColumnTextForButtonValue = true; // Display text on button
            btnColumnPreview.Name = "OrderDetails"; // Set the column name
            dataGrid.Columns.Add(btnColumnPreview);

            //Display edit button for order editing
            DataGridViewButtonColumn btnColumnEdit = new DataGridViewButtonColumn();
            btnColumnEdit.HeaderText = "Edit";
            btnColumnEdit.Text = "Edit";
            btnColumnEdit.UseColumnTextForButtonValue = true; // Display text on button
            btnColumnEdit.Name = "Edit"; // Set the column name
            dataGrid.Columns.Add(btnColumnEdit);

            // Populate grid with data
            dataGrid.DataSource = orderBl.GetAllOrders();

            //Populate combo boxes
            cmbEmployee.DataSource = employeeBl.GetAllEmployees();
            cmbEmployee.DisplayMember = "FirstName";
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.SelectedIndex = -1;

            cmbCustomer.DataSource = customerBl.getAllCustomers();
            cmbCustomer.DisplayMember = "CompanyName";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.SelectedIndex = -1;

            cmbProduct.DataSource = productBl.getAllProducts();
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
            cmbProduct.SelectedIndex = -1;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            setup_datagrid();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderId = (int)dataGrid.Rows[e.RowIndex].Cells["OrderID"].Value;
            // Handle preview order button click
            if (e.ColumnIndex == dataGrid.Columns["OrderDetails"].Index && e.RowIndex >= 0)
            {
                frmPreviewOrderDetail detailsForm = new frmPreviewOrderDetail(orderId);
                detailsForm.ShowDialog();


            }
            else if (e.ColumnIndex == dataGrid.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                frmEditOrder editOrderForm = new frmEditOrder(orderId);
                editOrderForm.ShowDialog();
                dataGrid.DataSource = orderBl.GetAllOrders();
            }
            else
            {
                frmEditOrder editOrderForm = new frmEditOrder(orderId);
                editOrderForm.ShowDialog();
                dataGrid.DataSource = orderBl.GetAllOrders();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            setup_datagrid();
        }
    }
}
