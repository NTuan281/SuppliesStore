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
    public partial class reportNCC : Form
    {
        public reportNCC()
        {
            InitializeComponent();
        }

        private void reportNCC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reportNhaCungCap.NHACUNGCAP' table. You can move, or remove it, as needed.
            this.NHACUNGCAPTableAdapter.Fill(this.reportNhaCungCap.NHACUNGCAP);

            this.reportViewer1.RefreshReport();
        }
    }
}
