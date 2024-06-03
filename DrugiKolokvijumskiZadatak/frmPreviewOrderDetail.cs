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
        public frmPreviewOrderDetail(int orderDetailId)
        {
            InitializeComponent();

            orderDetailID = orderDetailId;
        }

        private void frmPreviewOrderDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
