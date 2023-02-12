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
    
    public partial class Chi_Tiết_Hóa_Đơn_Xuất : Form
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=TUAN\MSSQLSERVER01;Initial Catalog=QUAN_LY_VAT_TU;Integrated Security=True");
        private string MAHDX;
        int soluong;
        public Chi_Tiết_Hóa_Đơn_Xuất()
        {
            InitializeComponent();
        }
        public Chi_Tiết_Hóa_Đơn_Xuất(string mahdx)
        {
            InitializeComponent();
            this.MAHDX = mahdx;
        }
        
        private void LoadDataCTHD_X()
        {

            dgvCTHD_X.Rows.Clear();
            cnn.Open();
            string sql = @"exec Chitiet_HDX @So_hdx = '" + MAHDX + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            string[] xuatxu = new string[10];
            int[] soluong_kho = new int[10];
            foreach (DataRow dr in dt.Rows)
            {
                dgvCTHD_X.Rows.Add();
                dgvCTHD_X.Rows[i].Cells[0].Value = dr.Field<string>(0);
                dgvCTHD_X.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvCTHD_X.Rows[i].Cells[2].Value = dr.Field<int>(2);
                dgvCTHD_X.Rows[i].Cells[3].Value = dr.Field<int>(3);
                dgvCTHD_X.Rows[i].Cells[4].Value = dr.Field<int>(4);
                xuatxu[i] = dr.Field<string>(5);
                soluong_kho[i] = dr.Field<int>(6);
                i++;
            }
            cnn.Close();
            if (dgvCTHD_X.RowCount > 1)
            {
                int rowindex = 0;
                cmbHH.Text = dgvCTHD_X.Rows[rowindex].Cells[0].Value.ToString();
                lbDVT.Text = dgvCTHD_X.Rows[rowindex].Cells[1].Value.ToString();
                txtSLKho.Text = dgvCTHD_X.Rows[rowindex].Cells[2].Value.ToString();
                txtDonGia.Text = dgvCTHD_X.Rows[rowindex].Cells[3].Value.ToString();
                txtDonGoc.Text = dgvCTHD_X.Rows[rowindex].Cells[3].Value.ToString();
                lbTTien.Text = dgvCTHD_X.Rows[rowindex].Cells[4].Value.ToString();
                txtSL.Text = soluong_kho[0].ToString();
                lbMade.Text = xuatxu[0];
            }
        }
        private void Loadlabel(int rowindex)
        {


            cnn.Open();
            string sql = @"exec Chitiet_HDX @So_hdx = '" + MAHDX + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            string[] xuatxu = new string[10];
            int[] soluong_kho = new int[10];
            foreach (DataRow dr in dt.Rows)
            {

                xuatxu[i] = dr.Field<string>(5);
                soluong_kho[i] = dr.Field<int>(6);
                i++;
            }
            cnn.Close();

            txtSL.Text = soluong_kho[rowindex].ToString();
            lbMade.Text = xuatxu[rowindex];

        }
        private void loadDataLabel(string mahd)
        {
            lbIDHD.Text = MAHDX;
            cnn.Open();
            string sql = @"exec LoadLabel_HDX @sohd = '" + mahd + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string trangthai = "";
            foreach (DataRow dr in dt.Rows)
            {
                lbKH.Text = dr.Field<string>(0); ;
                lbAdress.Text = dr.Field<string>(1);
                lbSDT.Text = dr.Field<string>(2);
                lbNV.Text = dr.Field<string>(3);
                lbNLAP.Text = dr.Field<DateTime>(4).ToString("dd/MM/yyyy");
                trangthai = dr.Field<string>(5);
            }

            cnn.Close();
            if (trangthai == "Đã hoàn thành")
            {
                cbtrangthai.Checked = true;
            }
            else
                cbtrangthai.Checked = false;
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
        private void Chi_Tiết_Hóa_Đơn_Xuất_Load(object sender, EventArgs e)
        {
            LoadDataCmb(cmbHH, "TENHH", "HANGHOA");
            LoadDataCTHD_X();
            loadDataLabel(MAHDX);
            
        }
        private void cbtrangthai_Click(object sender, EventArgs e)
        {
            if (cbtrangthai.Checked == true)
                MessageBox.Show("Hóa đơn đã hoàn thành, Bạn không thể cập nhập");
            else
            {
                MessageBox.Show("Hóa đơn đã hoàn thành không thể sửa");
                cbtrangthai.Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbtrangthai.Checked == false)
            {
                MessageBox.Show("Hóa đơn đang trong thời gian xử lý. Bạn vẫn muốn xóa");
                string ID = lbIDHD.Text;
                try
                {
                    cnn.Open();
                    string Sql = @"exec delete_CTHD_X @sohd = '" + ID + "',@tenhh = N'" + cmbHH.Text + ",@slkho = " + txtSL.Text + ",@sl = " + txtSLKho.Text;
                    SqlCommand cmd = new SqlCommand(Sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công"); 
                    cnn.Close();
                    LoadDataCTHD_X();
                    cmbHH.ResetText();
                    txtDonGia.ResetText();
                    txtDonGoc.ResetText();
                    txtSL.ResetText();
                    txtSLKho.ResetText();
                    lbMade.ResetText();
                    lbDVT.ResetText();
                    lbTTien.ResetText();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
            }
            else
            {
                string ID = lbIDHD.Text;
                try
                {
                    cnn.Open();
                    string Sql = @"exec delete_CTHD_X @sohd = '" + ID + "',@tenhh = N'" + cmbHH.Text + "',@slkho = " + txtSL.Text + ",@sl = " + txtSLKho.Text;
                    SqlCommand cmd = new SqlCommand(Sql, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Xóa thành công");
                    LoadDataCTHD_X();
                    cmbHH.ResetText();
                    txtDonGia.ResetText();
                    txtDonGoc.ResetText();
                    txtSL.ResetText();
                    txtSLKho.ResetText();
                    lbMade.ResetText();
                    lbDVT.ResetText();
                    lbTTien.ResetText();
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
            if (cbtrangthai.Checked == false)
            {
                string tenhh = cmbHH.Text;
                string sohd = MAHDX;
                int sl = int.Parse(txtSL.Text);
                int dongia = int.Parse(txtDonGia.Text);
                try
                {
                    cnn.Open();
                    string Sql = @"exec Insert_CTHD_X  @sohd = '" + sohd + "', @tenhh = N'" + tenhh + "',@sl = " + sl + ", @dongia = " + dongia;
                    SqlCommand cmd = new SqlCommand(Sql, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Sửa thành công");
                    LoadDataCTHD_X();
                    cmbHH.ResetText();
                    txtSL.ResetText();
                    txtSLKho.ResetText();
                    txtDonGia.ResetText();
                    txtDonGoc.ResetText();
                    lbMade.ResetText();
                    lbDVT.ResetText();
                    lbTTien.Text = "0";
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
            }
            else
            {
                MessageBox.Show("Hóa đơn đã hoàn thành không thể sửa");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbtrangthai.Checked == false)
            {
                string tenhh = cmbHH.Text;
                string sohd = MAHDX;
                
                int sl = int.Parse(txtSL.Text);
                int dongia = int.Parse(txtDonGia.Text);
                try
                {
                    cnn.Open();
                    string Sql = @"exec Insert_CTHD_X  @sohd = '" + sohd + "', @tenhh = N'" + tenhh + "',@sl = " + sl + ", @dongia = " + dongia;
                    SqlCommand cmd = new SqlCommand(Sql, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Thêm thành công");
                    LoadDataCTHD_X();
                    cmbHH.ResetText();
                    txtSL.ResetText();
                    txtSLKho.ResetText();
                    txtDonGia.ResetText();
                    txtDonGoc.ResetText();
                    lbMade.ResetText();
                    lbDVT.ResetText();
                    lbTTien.Text = "0";
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
            }
            else
            {
                MessageBox.Show("Hóa đơn đã hoàn thành không thể thêm hàng hóa");
                cnn.Close();
            }
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hóa đơn đã hoàn thành không thể sửa");

        }

        private void dgvCTHD_X_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dgvCTHD_X.CurrentCell.RowIndex;
            cmbHH.Text = dgvCTHD_X.Rows[rowindex].Cells[0].Value.ToString();
            lbDVT.Text = dgvCTHD_X.Rows[rowindex].Cells[1].Value.ToString();
            txtSLKho.Text = dgvCTHD_X.Rows[rowindex].Cells[2].Value.ToString();
            txtDonGia.Text = dgvCTHD_X.Rows[rowindex].Cells[3].Value.ToString();
            txtDonGoc.Text = dgvCTHD_X.Rows[rowindex].Cells[3].Value.ToString();
            lbTTien.Text = dgvCTHD_X.Rows[rowindex].Cells[4].Value.ToString();
            Loadlabel(rowindex);
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
