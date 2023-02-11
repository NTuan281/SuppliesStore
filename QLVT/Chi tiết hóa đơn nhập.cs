using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class Chi_tiết_hóa_đơn_nhập : Form
    {
        string MAHDN;
        public Chi_tiết_hóa_đơn_nhập()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-61R69JO\SQLEXPRESS;Initial Catalog=QUAN_LY_VAT_TU;Integrated Security=True");

        public Chi_tiết_hóa_đơn_nhập(string maHDN)
        {
            InitializeComponent();
            this.MAHDN = maHDN;
        }

        private void LoadDataCTHD_N()
        {

            dgvCTN.Rows.Clear();
            cnn.Open();
            string sql = @"exec Chitiet_HDN @sohd = '" + MAHDN + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;

            foreach (DataRow dr in dt.Rows)
            {
                dgvCTN.Rows.Add();
                dgvCTN.Rows[i].Cells[0].Value = dr.Field<string>(0);
                dgvCTN.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvCTN.Rows[i].Cells[2].Value = dr.Field<int>(2);
                dgvCTN.Rows[i].Cells[3].Value = dr.Field<int>(3);
                dgvCTN.Rows[i].Cells[4].Value = dr.Field<int>(4);
                i++;
            }
            cnn.Close();
            if (dgvCTN.RowCount > 1)
            {
                int rowindex = 0;
                cmbHH_N.Text = dgvCTN.Rows[rowindex].Cells[0].Value.ToString();
                txtSL.Text = dgvCTN.Rows[rowindex].Cells[2].Value.ToString();
                txtDG_N.Text = dgvCTN.Rows[rowindex].Cells[3].Value.ToString();
                lblThanhTien.Text = dgvCTN.Rows[rowindex].Cells[4].Value.ToString();
                lblDVT_N.Text = dgvCTN.Rows[rowindex].Cells[1].Value.ToString();
            }
        }
        private void LoadDataCmb(ComboBox cmb1, string name, string table)
        {
            cnn.Open();
            string sql = @"Select " + name + " from " + table;
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string[] tensp = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {

                tensp[i] = dr.Field<string>(0); //lấy trường đầu tiên trong DataTable
                cmb1.Items.Add(tensp[i]);
                i++;
            }
            cnn.Close();
        }
        private bool checkPrimaryKey(string pk, string name, string table)
        {
            cnn.Open();
            string sql = @"Select " + name + " from " + table;
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bool Check = false;
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.Field<string>(0) == pk)
                {
                    Check = true;
                }
                i++;
            }
            cnn.Close();
            return Check;
        }
        private void loadDataLabel(string mahd)
        {
            lblSO_HDN.Text = mahd;
            cnn.Open();
            string sql = @"exec LoadLabel_HDN @sohd = '" + mahd + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string trangthai = "";
            foreach (DataRow dr in dt.Rows)
            {
                lblNCC.Text = dr.Field<string>(0); ;
                lblNV_N.Text = dr.Field<string>(1);
                lblNgayLap_N.Text = dr.Field<DateTime>(2).ToString("dd/MM/yyyy");
                trangthai = dr.Field<string>(3);
            }

            cnn.Close();
            if (trangthai == "Đã hoàn thành")
            {
                cbTrangThai_N.Checked = true;
            }
            else
                cbTrangThai_N.Checked = false;
        }
        private void Chi_tiết_hóa_đơn_nhập_Load(object sender, EventArgs e)
        {
            LoadDataCmb(cmbHH_N, "TENHH", "HANGHOA");
            LoadDataCTHD_N();
            loadDataLabel(MAHDN);
        }

        private void dgvCTN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dgvCTN.CurrentCell.RowIndex;
            cmbHH_N.Text = dgvCTN.Rows[rowindex].Cells[0].Value.ToString();
            txtSL.Text = dgvCTN.Rows[rowindex].Cells[2].Value.ToString();
            txtDG_N.Text = dgvCTN.Rows[rowindex].Cells[3].Value.ToString();
            lblThanhTien.Text = dgvCTN.Rows[rowindex].Cells[4].Value.ToString();
            lblDVT_N.Text = dgvCTN.Rows[rowindex].Cells[1].Value.ToString();
        }

        private void cbTrangThai_N_Click(object sender, EventArgs e)
        {
            if (cbTrangThai_N.Checked == false)
                MessageBox.Show("ticked");
            else
            {
                MessageBox.Show("Hóa đơn đã hoàn thành không thể sửa");
                cbTrangThai_N.Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbTrangThai_N.Checked == false)
            {
                MessageBox.Show("Hóa đơn đang trong thời gian xử lý. Bạn vẫn muốn xóa");
                string ID = lblSO_HDN.Text;
                try
                {
                    cnn.Open();
                    string Sql = @"exec delete_CTHD_N @sohd ='"+ID+"',@tenhh=N'"+cmbHH_N.Text+"'";
                    SqlCommand cmd = new SqlCommand(Sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công");
                    cnn.Close();
                    LoadDataCTHD_N();
                    cmbHH_N.ResetText();
                    txtSL.ResetText();
                    txtDG_N.ResetText();
                    lblThanhTien.ResetText();
                    lblDVT_N.ResetText();
                    
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
            }
            else
            {
                string ID = lblSO_HDN.Text;
                try
                {
                    cnn.Open();
                    string Sql = @"exec delete_CTHD_X @sohd = '" + ID + "',@tenhh = N'" + cmbHH_N.Text + "',@sl = " + txtSL.Text;
                    SqlCommand cmd = new SqlCommand(Sql, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Xóa thành công");
                    LoadDataCTHD_N();
                    cmbHH_N.ResetText();
                    txtSL.ResetText();
                    txtDG_N.ResetText();
                    lblThanhTien.ResetText();
                    lblDVT_N.ResetText();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbTrangThai_N.Checked == false)
            {
                string tenhh = cmbHH_N.Text;
                string sohd = MAHDN;
                
                int sl = int.Parse(txtSL.Text);
                int dongia = int.Parse(txtDG_N.Text);
                try
                {
                    cnn.Open();
                    string Sql = @"exec Insert_CTHD_X  @sohd = '" + sohd + "', @tenhh = N'" + tenhh + "',@sl = " + sl + ", @dongia = " + dongia;
                    SqlCommand cmd = new SqlCommand(Sql, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Sửa thành công");
                    LoadDataCTHD_N();
                    cmbHH_N.ResetText();
                    txtSL.ResetText();
                    txtDG_N.ResetText();
                    lblThanhTien.ResetText();
                    lblDVT_N.ResetText();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                }
            }
            else
            {
                MessageBox.Show("Hóa đơn đã hoàn thành không thể sửa");
                cnn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbTrangThai_N.Checked == false)
            {
                string tenhh = cmbHH_N.Text;
                string sohd = MAHDN;
                int sl = int.Parse(txtSL.Text);
                int dongia = int.Parse(txtDG_N.Text);
                try
                {
                    cnn.Open();
                    string Sql = @"exec Insert_CTHD_X  @sohd = '" + sohd + "', @tenhh = N'" + tenhh + "',@sl = " + sl + ", @dongia = " + dongia;
                    SqlCommand cmd = new SqlCommand(Sql, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Thêm thành công");
                    LoadDataCTHD_N();
                    cmbHH_N.ResetText();
                    txtSL.ResetText();
                    txtDG_N.ResetText();
                    lblThanhTien.ResetText();
                    lblDVT_N.ResetText();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                }
            }
            else
            {
                MessageBox.Show("Hóa đơn đã hoàn thành không thể thêm hàng hóa");
                cnn.Close();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In");
        }
    }
}
