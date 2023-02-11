
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
    public partial class Form1 : Form
    {
        ketnoiSQL cnn = new ketnoiSQL();
        public Form1()
        {
            InitializeComponent();
        }
        int waiter = 0, panel_y =329;
        private void timer1_Tick(object sender, EventArgs e)
        {
            waiter++;
            if (waiter > 50)
            {
                panel_y -= 10;
                loginPanel.Size = new Size(loginPanel.Size.Width, panel_y);
                if (panel_y < 10)
                {
                    timer1.Enabled = false;
                    waiter = 0;
                    lbllogin.Visible = true;
                }
             }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbllogin.Visible = false;
            loginPanel.Size = new Size(loginPanel.Size.Width , panel_y);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            waiter++;
            if (waiter > 50)
            {
                panel_y += 10;
                loginPanel.Size = new Size(loginPanel.Size.Width, panel_y);
                if (panel_y > 329)
                {
                    timer2.Enabled = false;
                    waiter = 0;
                    lbllogin.Visible =false;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có thật sự muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = cnn.GetData(@"select * from NGUOIDUNG where USERNAME='" + txtUser.Text + "'and PASSWORD='" + txtPassword.Text + "'");
            if (dt.Rows.Count > 0)
            {

                FormChinh fc = new FormChinh(dt.Rows[0][0].ToString(),dt.Rows[0][2].ToString());
                this.Hide();
                fc.ShowDialog();

            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác ! mời nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.ResetText();

            }
        }

        private void loginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void signPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signupFormPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

      

    }
}
