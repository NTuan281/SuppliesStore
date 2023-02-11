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
    public partial class frmReportHangHoa : Form
    {
        public frmReportHangHoa()
        {
            InitializeComponent();
        }

        private void frmReportHangHoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLVT_HangHoa.HANGHOA' table. You can move, or remove it, as needed.
            this.HANGHOATableAdapter.Fill(this.QLVT_HangHoa.HANGHOA);

            this.reportViewer1.RefreshReport();
        }
    }
}
