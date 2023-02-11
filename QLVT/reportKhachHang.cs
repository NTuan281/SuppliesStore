using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class reportKhachHang : Form
    {
        public reportKhachHang()
        {
            InitializeComponent();
        }

        private void reportKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QUAN_LY_VAT_TUDataSet.KHACHHANG' table. You can move, or remove it, as needed.
            this.KHACHHANGTableAdapter.Fill(this.QUAN_LY_VAT_TUDataSet.KHACHHANG);

            this.reportViewer1.RefreshReport();
        }
    }
}
