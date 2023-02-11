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
    public partial class frmReportLoaiHang : Form
    {
        public frmReportLoaiHang()
        {
            InitializeComponent();
        }

        private void frmReportLoaiHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLVT_LoaiHang.LOAIHANG' table. You can move, or remove it, as needed.
            this.LOAIHANGTableAdapter.Fill(this.QLVT_LoaiHang.LOAIHANG);

            this.reportViewer1.RefreshReport();
        }
    }
}
