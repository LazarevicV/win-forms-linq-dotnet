using BusinessLayer;
using DataLayer;
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
    public partial class frmPreviewOrderDetail : Form
    {
        int orderDetailID;
        OrderDetailsBL orderDetailsBl;
        OrderBL orderBL;
        OrderDTO orderDTO;
        CustomerBL customerBl;
        public frmPreviewOrderDetail(int orderDetailId)
        {
            InitializeComponent();

            orderDetailID = orderDetailId;
            orderDetailsBl = new OrderDetailsBL();
            orderBL = new OrderBL();
        }

        private void frmPreviewOrderDetail_Load(object sender, EventArgs e)
        {
            OrderDetailsDTO orderDetail = new OrderDetailsBL().GetOrderDetail(orderDetailID);
            ProductDTO product = new ProductBL().getProduct(orderDetail.ProductID);

            //orderDTO = orderBL.GetOrder(orderDetail.OrderID);

            dataGrid.DataSource = orderDetailsBl.GetAllByOrder(orderDetailID);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
