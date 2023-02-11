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
using System.Globalization;

namespace QLVT
{
    public partial class Nhân_Sự : Form
    {
        public Nhân_Sự()
        {
            InitializeComponent();
        }
        string userName="",loai = "";
        public Nhân_Sự(string userName, string loai)
        {
            InitializeComponent();
            this.loai = loai;
            this.userName = userName;
        }
     
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-61R69JO\SQLEXPRESS;Initial Catalog=QUAN_LY_VAT_TU;Integrated Security=True");
        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_NV_Click(object sender, EventArgs e)
        {
            string sqlUpdate;
            string manv = txtMANV.Text;
            string tennv = txtNameNV.Text;
            string diachi = txtAdressNV.Text;
            string sdt = txtSDT_NV.Text;
            string gioitinh;
            if(rbGender_Nam.Checked == true)
                    gioitinh = "Nam";
            else
                    gioitinh = "Nữ";
            DateTime birthday = dprBirthDay.Value;

            if (checkPrimaryKey(manv, "MANV", "NHANVIEN") == false)
            {
                MessageBox.Show("Nhân viên chưa được thêm");
            }
            else
            {
                try
                {
                    cnn.Open();
                    sqlUpdate = @"exec update_nv @manv = '"+manv+"',@tennv = N'"+tennv+"',@diachi = N'"+diachi+"',@gioitinh = N'"+gioitinh+"',"+
			                                    "@ngaysinh = '"+birthday.ToString("yyyyMMdd")+"',"+
			                                    "@sdt= '"+sdt+"'";
                    MessageBox.Show(sqlUpdate);
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cnn);
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    cnn.Close();
                    LoadDataNV(@"select * from NHANVIEN");
                    txtMANV.Text = "";
                    txtNameNV.Text = "";
                    txtAdressNV.Text = "";
                    rbGender_Nu.Checked = false;
                    rbGender_Nam.Checked = false;
                    DateTime dt = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    dprBirthDay.Value = dt;
                    txtSDT_NV.Text = "";
                }
                catch
                {
                    lbLalert_Tuoi.Text = "Vui lòng đổi lại ngày sinh";
                    MessageBox.Show("Yêu cầu nhân viên phải trên 18 tuổi");
                }
            }
        }
        private void InsertSQL_ND()
        {
            string TenDN = txtUser.Text;
            string password = txtPassword.Text;
            //string pass = txtAdress_KH.Text;
            string type = "";
            if (rbUser.Checked == true)
                type = "User";
            if (rbAdmin.Checked == true)
                type = "Admin";
            string active;
            if (cbTrangThai.Checked == true)
                active = "Đang hoạt động";
            else
            {
                active = "Chưa thể sử dụng";
                MessageBox.Show("Tài khoản chưa sử dụng ngay được");
            } 
              //Add dữ liệu vào sql
            
            cnn.Open();
            string insert = @"exec INSERT_ND @1 = '" + TenDN + "',@2 ='" + password + "',@3 = '" + type + "',@4 = N'" + active + "'";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(insert, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();
            LoadDataND();
            txtUser.ResetText();
            txtPassword.ResetText();
            txtPassword_Again.ResetText();
            rbUser.Refresh();
            rbAdmin.Refresh();
            cbTrangThai.Refresh();
        }
        private bool checkPrimaryKey(string pk,string name,string table)
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
                    Check = true;
                i++;
            }
            cnn.Close();
            return Check;
        }
        private void LoadDataND()
        {
            dgvAccount.Rows.Clear();
            cnn.Open();
            string sql = @"select USERNAME, LOAI, ACTIVE from NGUOIDUNG ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvAccount.Rows.Add();
                dgvAccount.Rows[i].Cells[0].Value = dr.Field<string>(0);
                dgvAccount.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvAccount.Rows[i].Cells[2].Value = dr.Field<string>(2);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataND_NV()
        {
            dgvAccount_NV.Rows.Clear();
            cnn.Open();
            string sql = @"exec data_TK_ND";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvAccount_NV.Rows.Add();
                dgvAccount_NV.Rows[i].Cells[0].Value = dr.Field<string>(0);
                dgvAccount_NV.Rows[i].Cells[1].Value = dr.Field<string>(1);
                i++;
            }
            cnn.Close();
        }
        private void btnAdd_Account_Click(object sender, EventArgs e)
        {
            int count = 0; 
            if (txtUser.Text == "")
            {
                lblFail.Text = "Tên đăng nhập không được bỏ trống";
                count++;
            }
            else
                lblFail.Text = "";
            if (txtPassword.Text == "")
            {
                lblFail1.Text = "Vui lòng nhập password bạn muốn!!";
                count++;
            }
            else
                lblFail1.Text = "";
            if (txtPassword_Again.Text == "")
            {
                lblFail2.Text = "Mật không không khớp";
                count++;
            }
            else
                lblFail2.Text = "";
            if (  txtPassword_Again.Text != txtPassword.Text)
            {
                lblFail2.Text = "Mật không không khớp";
                count++;
            }
            else
                lblFail2.Text = "";
            if (rbAdmin.Checked != true && rbUser.Checked != true)
            {
                lblFail3.Text = "Vui lòng chọn một trong hai";
                count++;
            }
            else
                lblFail3.Text = "";
            if (checkPrimaryKey(txtUser.Text, "USERNAME", "NGUOIDUNG") == true)
            {
                MessageBox.Show("Tên đăng nhập đã được sử dụng");
                count++;
            }
            if (count != 0)
            {
                MessageBox.Show("Vui lòng thực hiện mọi yêu cầu!!");
            }
            if (count == 0)
                try {
                    InsertSQL_ND();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                }
                
            
        }
        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            int rowindex = dgvAccount.CurrentCell.RowIndex;
            txtUser.Text = dgvAccount.Rows[rowindex].Cells[0].Value.ToString();
            if (dgvAccount.Rows[rowindex].Cells[1].Value.ToString() == "Admin")
            {
                rbAdmin.Checked = true;
                rbUser.Refresh();
            }
            if (dgvAccount.Rows[rowindex].Cells[1].Value.ToString() == "User")
            {
                rbUser.Checked = true;
                rbAdmin.Refresh();
            }
            if (dgvAccount.Rows[rowindex].Cells[2].Value.ToString() == "Đang hoạt động")
                cbTrangThai.Checked = true;
            if (dgvAccount.Rows[rowindex].Cells[2].Value.ToString() == "Chưa thể sử dụng")
                cbTrangThai.Checked = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Dòng này không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
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

        //Chỉ ADMIN mới có quyền thêm xóa sửa
        private void phanQuyen()
        {
            if (loai == "User")
            {
                //tt tài khoản
                btnAdd_Account.Enabled = false;
                btnDelete_Account.Enabled = false;
                btnUpdate_ND.Enabled = false;
                //tài khoản nhân viên 
                btnAdd_TK_NV.Enabled = false;
                btnUpdate_TK_NV.Enabled = false;
                btnDelete_TK_NV.Enabled = false;
                //nhân viên
                btnAdd_NV.Enabled = false;
                btnUpdate_NV.Enabled = false;
                btnDelete_NV.Enabled = false;
                //đổi mật khẩu

            }
        }
        private void Nhân_Sự_Load(object sender, EventArgs e)
        {
            txtUpdate_NameUser.Text = userName;
            txtUpdate_NameUser.Enabled = false;
            phanQuyen();
            LoadDataND();
            LoadDataCmb(cbTK_ND, "USERNAME", "NGUOIDUNG");
            LoadDataCmb(cb_NV, "TENNV", "NHANVIEN");
            LoadDataND_NV();
            LoadDataNV(@"select * from NHANVIEN");
            DateTime dt = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dprBirthDay.Value = dt;
        }

        private void btnDelete_Account_Click(object sender, EventArgs e)
        {
            cnn.Open();
            int rowindex = dgvAccount.CurrentCell.RowIndex;
            string masp = dgvAccount.Rows[rowindex].Cells[0].Value.ToString();
            string sqlDelete = @"exec DELETE_ND @USERNAME = '" + masp + "'";
            SqlCommand cmdDelete = new SqlCommand(sqlDelete, cnn);
            cmdDelete.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công!");
            cnn.Close();
            LoadDataND();
            txtUser.ResetText();
            txtPassword.ResetText();
            txtPassword_Again.ResetText();
            rbUser.Refresh();
            rbAdmin.Refresh();
            cbTrangThai.Refresh();
        }

        private void btnUpdate_ND_Click(object sender, EventArgs e)
        {
            cnn.Open();
            int rowindex = dgvAccount.CurrentCell.RowIndex;
            string masp = dgvAccount.Rows[rowindex].Cells[0].Value.ToString();
            string sqlUpdate ;
            if (cbTrangThai.Checked == true)
                sqlUpdate = @"exec UPDATE_ND2 @USERNAME = '" + masp + "'";
            else
            {
                sqlUpdate = @"exec UPDATE_ND1 @USERNAME = '" + masp + "'";
            }
            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cnn);
            cmdUpdate.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thành công!");
            cnn.Close();
            LoadDataND();
            txtUser.ResetText();
            txtPassword.ResetText();
            txtPassword_Again.ResetText();
            rbUser.Refresh();
            rbAdmin.Refresh();
            cbTrangThai.Refresh();  
        }
        private void InsertSQL_ND_NV()
        {
            string ND_NV = cbTK_ND.Text;
            string NV = cb_NV.Text;
            //Add dữ liệu vào sql

            cnn.Open();
            string insert = @"exec INSERT_TK_ND @USERNAME = '" + ND_NV + "',@TENNV = N'" + NV + "'";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(insert, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();
            LoadDataND();
            txtUser.ResetText();
            txtPassword.ResetText();
            txtPassword_Again.ResetText();
            rbUser.Refresh();
            rbAdmin.Refresh();
            cbTrangThai.Refresh();
        }
        private void btnAdd_TK_NV_Click(object sender, EventArgs e)
        {

            if (checkPrimaryKey(cbTK_ND.Text, "USERNAME", "NGUOIDUNG_NHANVIEN") == true)
            {
                MessageBox.Show("Tên đăng nhập đã được sử dụng");
            }
            else
            try {
                InsertSQL_ND_NV();
                MessageBox.Show("Thêm thành công!!!");
                cbTK_ND.Text = "";
                cb_NV.Text = "";
                LoadDataND_NV();
                    cbTK_ND.Text = null;
                    cb_NV.Text = null;
                }
            catch
            {
                MessageBox.Show("Quá trình nhập xảy ra lỗi, vui lòng thử lại!!!");
            }
            
        }
        private void dgvAccount_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
            int rowindex =dgvAccount_NV.CurrentCell.RowIndex;
            cbTK_ND.Text = dgvAccount_NV.Rows[rowindex].Cells[0].Value.ToString();
            cb_NV.Text = dgvAccount_NV.Rows[rowindex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dòng này không có dữ liêu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
            }
        }

        private void btnDelete_TK_NV_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                int rowindex = dgvAccount_NV.CurrentCell.RowIndex;
                string username = dgvAccount_NV.Rows[rowindex].Cells[0].Value.ToString();
                string sqlDelete = @"exec DELETE_TK_ND @USERNAME = '" + username + "'";
                SqlCommand cmdDelete = new SqlCommand(sqlDelete, cnn);
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!");
                cnn.Close();
                LoadDataND_NV();
                cbTK_ND.Text = null;
                cb_NV.Text = null;
            }
            catch
            {
                MessageBox.Show("Quá trình Xóa xảy ra lỗi, vui lòng thử lại!!!");
            }
        }

        private void btnUpdate_TK_NV_Click(object sender, EventArgs e)
        {

            string sqlUpdate;
            string username = cbTK_ND.Text;
            if (checkPrimaryKey(cbTK_ND.Text, "USERNAME", "NGUOIDUNG_NHANVIEN") == false)
            {
                MessageBox.Show("Tên đăng nhập chưa được tạo");
            }
            else
            {
                try
                {
                    cnn.Open();
                    sqlUpdate = @"exec UPDATE_TK_NV @TENNV = N'" + cb_NV.Text + "' , @username = '" + cbTK_ND.Text + "'";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cnn);
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    cnn.Close();
                    LoadDataND_NV();
                    cbTK_ND.Text = null;
                    cb_NV.Text = null;
                }
                catch
                {
                    MessageBox.Show("Quá trình Sửa xảy ra lỗi, vui lòng thử lại!!!");
                }
            }   
        }
        private string CheckPassword()
        {
            cnn.Open();
            string sql = @"exec old_password @USERNAME = '"+userName+"' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string nameCheck = "";
            
            foreach (DataRow dr in dt.Rows)
            {
                nameCheck = dr.Field<string>(0);
            }
            cnn.Close();
            return nameCheck;
        }
        private void btnSaveNewMK_Click(object sender, EventArgs e)
        {
            int i = 0;
            string sqlUpdate;
            /*if (checkPrimaryKey(txtUpdate_NameUser.Text, "USERNAME", "NGUOIDUNG") == false)
             {
                 lblAlert.Text = ("Tên đăng nhập chưa được tạo");
             }*/
                lblAlert.Text = "";
                if (txtOld_Password.Text != CheckPassword())
                {
                    lblAlert1.Text = "Mật khẩu cũ không đúng";
                    i++;
                }
                else
                    lblAlert1.Text = "";
                if (txtNew_Password.Text == "")
                {
                    lblAlert2.Text = "Vui lòng nhập password bạn muốn!!";
                    i++;
                }
                else
                    lblAlert2.Text = "";
                if (txtNew_Password.Text == txtOld_Password.Text)
                {
                    lblAlert2.Text = "Mật khẩu mới không hợp lệ!!";
                    i++;
                }
                else
                    lblAlert2.Text = "";
            if (txtNew_PasswordAgain.Text == "")
                {
                    lblAlert3.Text = "Mật không không khớp";
                    i++;
                }
                else
                    lblAlert3.Text = "";
                if (txtNew_PasswordAgain.Text != txtNew_Password.Text)
                {
                    lblAlert3.Text = "Mật không không khớp";
                    i++;
                }
                else
                    lblAlert3.Text = "";
                if (i != 0)
                    MessageBox.Show("Vui lòng thực hiện mọi yêu cầu!!");
                else
                {
                    try
                    {
                        cnn.Open();
                        sqlUpdate = @"exec Change_password @1= '" + txtUpdate_NameUser.Text + "' , @2 = '" + txtNew_Password.Text + "'";
                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cnn);
                        cmdUpdate.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thành công!");
                        cnn.Close();
                       // txtUpdate_NameUser.Text = "";
                        txtOld_Password.Text = "";
                        txtNew_Password.Text = "";
                        txtNew_PasswordAgain.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("Quá trình Sửa xảy ra lỗi, vui lòng thử lại!!!");
                    }
                }
        }
        private void LoadDataNV(string sql)
        {
            dgvInfo_NV.Rows.Clear();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvInfo_NV.Rows.Add();
                dgvInfo_NV.Rows[i].Cells[0].Value = dr.Field<string>(0);
                dgvInfo_NV.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvInfo_NV.Rows[i].Cells[2].Value = dr.Field<string>(4);
                dgvInfo_NV.Rows[i].Cells[3].Value = dr.Field<string>(2);
                dgvInfo_NV.Rows[i].Cells[4].Value = dr.Field<DateTime>(3).ToString("dd-MM-yyyy");
                dgvInfo_NV.Rows[i].Cells[5].Value = dr.Field<string>(5);
                i++;
            }
            cnn.Close();
        }
        private void dgvInfo_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dgvInfo_NV.CurrentCell.RowIndex;
                txtMANV.Text = dgvInfo_NV.Rows[rowindex].Cells[0].Value.ToString();
                txtNameNV.Text = dgvInfo_NV.Rows[rowindex].Cells[1].Value.ToString();
                txtAdressNV.Text = dgvInfo_NV.Rows[rowindex].Cells[2].Value.ToString();
                if (dgvInfo_NV.Rows[rowindex].Cells[3].Value.ToString() == "Nam")
                {
                    rbGender_Nam.Checked = true;
                    rbGender_Nu.Checked = false;
                }
                else
                {
                    rbGender_Nu.Checked = true;
                    rbGender_Nam.Checked = false;
                }
                DateTime dt = DateTime.ParseExact(dgvInfo_NV.Rows[rowindex].Cells[4].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                dprBirthDay.Value = dt;
                txtSDT_NV.Text = dgvInfo_NV.Rows[rowindex].Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dòng này không có dữ liêu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
            }
        }
            private void btnCancel_NS_Click(object sender, EventArgs e)
        {
            //txtUpdate_NameUser.Text = "";
            txtOld_Password.Text = "";
            txtNew_Password.Text = "";
            txtNew_PasswordAgain.Text = "";
            
        }

        private void btnSearch_NV_Click(object sender, EventArgs e)
        {
            if (rb_NV_TheoMa.Checked == true)
            {
                LoadDataNV(@"EXEC TK_NHANVIEN_THEOMA @MANV = '" + txt_searchNV.Text + "' ");
            }
            else
            {
                LoadDataNV("EXEC TK_NHANVIEN_THEOTEN @TENNV = N'" + txt_searchNV.Text + "' ");
            }
                

        }

        private void btnDelete_NV_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                int rowindex = dgvInfo_NV.CurrentCell.RowIndex;
                string manv = dgvInfo_NV.Rows[rowindex].Cells[0].Value.ToString();
                string sqlDelete = @"exec DELETE_NV @manv = '" + manv + "'";
                SqlCommand cmdDelete = new SqlCommand(sqlDelete, cnn);
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!");
                cnn.Close();
                LoadDataNV(@"select * from NHANVIEN");
                txtMANV.Text = "";
                txtNameNV.Text = "";
                txtAdressNV.Text = "";
                rbGender_Nu.Checked = false;
                rbGender_Nam.Checked = false;
                DateTime dt = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                dprBirthDay.Value = dt;
                txtSDT_NV.Text = "";
            }
            catch
            {
                MessageBox.Show("Quá trình Xóa xảy ra lỗi, vui lòng thử lại!!!");
            }
        }
        private int kt_tuoiNV(DateTime dateTime)
        {
            cnn.Open();
            string sql = @"exec TuoiNV @ngaysinh = '"+dateTime.ToString("yyyyMMdd")+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                MessageBox.Show(dr.Field<int>(0).ToString());
                if (dr.Field<int>(0) < 18)
                    i++;
            }
            cnn.Close();
            return i;
        }



        private void btnAdd_NV_Click(object sender, EventArgs e)
        {
            string sqlUpdate;
            string manv = txtMANV.Text;
            string tennv = txtNameNV.Text;
            string diachi = txtAdressNV.Text;
            string sdt = txtSDT_NV.Text;
            string gioitinh;
            if (rbGender_Nam.Checked == true)
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";
            DateTime birthday = dprBirthDay.Value;
            if (checkPrimaryKey(manv, "MANV", "NHANVIEN") == true)
            {
                MessageBox.Show("Nhân viên đã được thêm");
            }
            else
            {
                try
                {
                    cnn.Open();
                    sqlUpdate = @"exec insert_nv @manv = '" + manv + "',@tennv = N'" + tennv + "',@diachi = N'" + diachi + "',@gioitinh = N'" + gioitinh + "'," +
                                                "@ngaysinh = '" + birthday.ToString("yyyyMMdd") + "'," +
                                                "@sdt= '" + sdt + "'";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cnn);
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    cnn.Close();
                    LoadDataNV(@"select * from NHANVIEN");
                    txtMANV.Text = "";
                    txtNameNV.Text = "";
                    txtAdressNV.Text = "";
                    rbGender_Nu.Checked = false;
                    rbGender_Nam.Checked = false;
                    DateTime dt = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    dprBirthDay.Value = dt;
                    txtSDT_NV.Text = "";
                }
                catch 
                {
                    lbLalert_Tuoi.Text = "Vui lòng đổi lại ngày sinh";
                    MessageBox.Show("Yêu cầu nhân viên phải trên 18 tuổi");
                }
            }
        }
    }
}
