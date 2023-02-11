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
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
        }
        string userName="", loai = "";
        public FormChinh(string userName ,string loai)
        {
            InitializeComponent();
            this.loai = loai;
            this.userName = userName;
        }
        private Form currentFormChild;
        private void OpenChildForm (Form ChildForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelShow1.Controls.Add(ChildForm);
            panelShow1.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void bntNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Nhân_Sự(userName,loai));
            lblHeader.Text = btnNhanVien.Text;

        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Danh_Mục(loai));
            lblHeader.Text = btnDanhMuc.Text;

        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Thống_kê(loai));
            lblHeader.Text = btnBCTK.Text;

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lblHeader.Text = "QUẢN LÝ VẬT TƯ";
        }

        private void FormChinh_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang đăng nhập với tư cách '" + loai + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }
    }
}
