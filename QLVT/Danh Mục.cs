using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class Danh_Mục : Form
    {
        public Danh_Mục()
        {
            InitializeComponent();
        }
        string loai = "";
        public Danh_Mục(string loai)
        {
            InitializeComponent();
            this.loai = loai;
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=TUAN\MSSQLSERVER01;Initial Catalog=QUAN_LY_VAT_TU;Integrated Security=True");
        private void label39_Click(object sender, EventArgs e)
        {

        }
        public string[] GetTTHDN()
        {
            string[] HDN = new string[10];
            HDN[0] = txtHĐN.Text;
            return HDN;
        }
        private void LoadDataKH(string sql)
        {
            dgvKhachHang.Rows.Clear();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvKhachHang.Rows.Add();
                dgvKhachHang.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvKhachHang.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvKhachHang.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvKhachHang.Rows[i].Cells[3].Value = dr.Field<string>(3);
                dgvKhachHang.Rows[i].Cells[4].Value = dr.Field<string>(4);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataHD_X()
        {
            dgvHD_X.Rows.Clear();
            cnn.Open();
            string sql = @"exec LoadDataHD_X";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvHD_X.Rows.Add();
                dgvHD_X.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvHD_X.Rows[i].Cells[1].Value = dr.Field<DateTime>(1).ToString("dd-MM-yyyy");
                dgvHD_X.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvHD_X.Rows[i].Cells[3].Value = dr.Field<string>(3);
                dgvHD_X.Rows[i].Cells[4].Value = dr.Field<string>(4);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataLoaiHang(string sql)
        {
            dgvLoaiHang.Rows.Clear();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvLoaiHang.Rows.Add();
                dgvLoaiHang.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvLoaiHang.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvLoaiHang.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvLoaiHang.Rows[i].Cells[3].Value = dr.Field<string>(3);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataNCC(string sql)
        {
            dgvNCC.Rows.Clear();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvNCC.Rows.Add();
                dgvNCC.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvNCC.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvNCC.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvNCC.Rows[i].Cells[3].Value = dr.Field<string>(3);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataKho()
        {
            dgvKho.Rows.Clear();
            cnn.Open();
            string sql = @"exec LoadData_Kho";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvKho.Rows.Add();
                dgvKho.Rows[i].Cells[0].Value = dr.Field<string>(0);
                dgvKho.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvKho.Rows[i].Cells[2].Value = dr.Field<int>(2);
                dgvKho.Rows[i].Cells[3].Value = dr.Field<string>(3);
                i++;
            }
            cnn.Close();
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (txtSO_HD_X.Text != "")
            {
                if (checkPrimaryKey(txtSO_HD_X.Text, "SO_HD_XUAT", "HOADON_XUAT") == true)
                {
                    Chi_Tiết_Hóa_Đơn_Xuất xuat = new Chi_Tiết_Hóa_Đơn_Xuất(txtSO_HD_X.Text);
                    xuat.StartPosition = FormStartPosition.CenterScreen;
                    xuat.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Số hóa đơn không khớp vui lòng nhập lại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn bạn muốn thay đổi");
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (txtHĐN.Text != "")
            {
                if (checkPrimaryKey(txtHĐN.Text, "SO_HD_NHAP", "HOADON_NHAP") == true)
                {
                    Chi_tiết_hóa_đơn_nhập nhap = new Chi_tiết_hóa_đơn_nhập(txtHĐN.Text);
                    nhap.StartPosition = FormStartPosition.CenterScreen;
                    nhap.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Số hóa đơn không khớp vui lòng nhập lại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn bạn muốn thay đổi");
            }
        }
        private void LoadDataCmb(ComboBox cmb1, string name, string table)
        {
            cmb1.Refresh();
            cnn.Open();
            string sql = @"Select " + name + " from " + table;
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string[] tensp = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {

                try
                {
                    tensp[i] = dr.Field<int>(0).ToString(); //lấy trường đầu tiên trong DataTable
                    cmb1.Items.Add(tensp[i]);
                    i++;
                }
                catch
                {
                    tensp[i] = dr.Field<string>(0); //lấy trường đầu tiên trong DataTable
                    cmb1.Items.Add(tensp[i]);
                    i++;
                }
            }
            cnn.Close();
        }
        private void LoadDataHH(string sql)
        {
            dgvHang.Rows.Clear();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvHang.Rows.Add();
                dgvHang.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvHang.Rows[i].Cells[1].Value = dr.Field<int>(1);
                dgvHang.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvHang.Rows[i].Cells[3].Value = dr.Field<string>(3);
                dgvHang.Rows[i].Cells[4].Value = dr.Field<string>(4);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataHD_N()
        {
            dgvHD_N.Rows.Clear();
            cnn.Open();
            string sql = @"exec LoadDataHD_N";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvHD_N.Rows.Add();
                dgvHD_N.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvHD_N.Rows[i].Cells[1].Value = dr.Field<DateTime>(1).ToString("dd-MM-yyyy");
                dgvHD_N.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvHD_N.Rows[i].Cells[3].Value = dr.Field<string>(3);
                dgvHD_N.Rows[i].Cells[4].Value = dr.Field<string>(4);
                i++;
            }
            cnn.Close();
        }
        //Phân quyền
        private void phanQuyen()
        {
            if (loai == "User")
            {
                //Nhà cung cấp
                btnAdd_NCC.Enabled = false;
                btnUpdate_NCC.Enabled = false;
                btnDelete_NCC.Enabled = false;
                //loại hàng
                btnAdd_LH.Enabled = false;
                btnUpdate_LH.Enabled = false;
                btnDelete_LH.Enabled = false;
                //hàng hóa
                btnAdd_HH.Enabled = false;
                btnUpdate_HH.Enabled = false;
                btnDelete_HH.Enabled = false;
                //
            }
        }
        private void Danh_Mục_Load(object sender, EventArgs e)
        {
            phanQuyen();
            LoadDataKH(@"select * from KHACHHANG");
            LoadDataHD_X();
            LoadDataLoaiHang(@"select * from loaihang");
            LoadDataNCC(@"select * from NHACUNGCAP");
            LoadDataHH(@"exec LoadData_HH");
            LoadDataHD_N();
            LoadDataKho();
            LoadDataCmb(cmbNameKH_HD_X, "TENKH", "KHACHHANG");
            LoadDataCmb(cmbNameNV_HDX, "TENNV", "NHANVIEN");
            LoadDataCmb(cmbLoaihang, "TENLOAI", "LOAIHANG");
            LoadDataCmb(cmbNhaCungCap, "TENNCC", "NHACUNGCAP");
            LoadDataCmb(cmbNameNV_HDN, "TENNV", "NHANVIEN");
            LoadDataCmb(cmbID_LH, "MALOAI", "LOAIHANG");
        }
        private void InsertKH()
        {
            string makh = txtMAKH.Text;
            string tenkh = txtName_KH.Text;
            string diachi = txtAdress_KH.Text;
            string sdt = txtSDT_KH.Text;
            string gender = "";
            if (rbGenderKH_Nam.Checked == true)
                gender = "Nam";
            if (rbGenderKH_Nu.Checked == true)
                gender = "Nữ";
            
            //Add dữ liệu vào sql

            cnn.Open();
            string insertSql = @"insert into KHACHHANG values (N'"+tenkh+"',N'"+gender+"',N'"+diachi+"','"+sdt+"')";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(insertSql, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();
            LoadDataKH(@"select * from KHACHHANG");
            txtMAKH.ResetText();
            txtName_KH.ResetText();
            txtAdress_KH.ResetText();
            rbGenderKH_Nam.Checked = false;
            rbGenderKH_Nu.Checked = false;
            txtSDT_KH.ResetText();
        }
        private void btnAdd_KH_Click(object sender, EventArgs e)
        {
            int count = 0;
            string messenger = "";
            if (txtName_KH.Text == "")
            {
                messenger = messenger + "\nVui lòng nhập Tên !!";
                count++;
            }
            else
                messenger = messenger + "";
            if (txtAdress_KH.Text == "")
            {
                messenger = messenger + "\nVui lòng nhập địa chỉ";
                count++;
            }
            else
                messenger = messenger + "";
            if (txtSDT_KH.Text == "")
            {
                messenger = messenger + "\nVui lòng nhập SĐT";
                count++;
            }
            else
                messenger = messenger + "";
            if (rbGenderKH_Nam.Checked != true && rbGenderKH_Nu.Checked != true)
            {
                messenger = messenger + "\nVui lòng chọn một trong hai";
                count++;
            }
            else
                messenger = messenger + "";
            if (checkPrimaryKey(txtMAKH.Text, "MAKH", "KHACHHANG") == true)
            {
                messenger = messenger + "\nMã nhân viên không được trùng nhau, Vui lòng nhập mã nhân viên khác";
                count++;
            }
            if (count != 0)
            {
                MessageBox.Show(messenger);
            }
            if (count == 0)
                try
                {
                    InsertKH();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                }
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
        private void btnSearchKH_Click(object sender, EventArgs e)
        {
            if (rbSearch_ID_KH.Checked == true)
            {
                LoadDataKH(@"exec Search_ID_KH @Search = '"+txtSearch_KH.Text+"'");
                int rowindex = 0;
                txtMAKH.Text = dgvKhachHang.Rows[rowindex].Cells[0].Value.ToString();
                txtName_KH.Text = dgvKhachHang.Rows[rowindex].Cells[1].Value.ToString();
                txtAdress_KH.Text = dgvKhachHang.Rows[rowindex].Cells[3].Value.ToString();
                txtSDT_KH.Text = dgvKhachHang.Rows[rowindex].Cells[4].Value.ToString();
                if (dgvKhachHang.Rows[rowindex].Cells[2].Value.ToString() == "Nam")
                {
                    rbGenderKH_Nam.Checked = true;
                    rbGenderKH_Nu.Refresh();
                }
                if (dgvKhachHang.Rows[rowindex].Cells[2].Value.ToString() == "Nữ")
                {
                    rbGenderKH_Nam.Checked = true;
                    rbGenderKH_Nu.Refresh();
                }
            }
            else
            {
                LoadDataKH(@"exec Search_Ten_KH @Search = N'"+txtSearch_KH.Text+"'");
                int rowindex = 0;
                txtMAKH.Text = dgvKhachHang.Rows[rowindex].Cells[0].Value.ToString();
                txtName_KH.Text = dgvKhachHang.Rows[rowindex].Cells[1].Value.ToString();
                txtAdress_KH.Text = dgvKhachHang.Rows[rowindex].Cells[3].Value.ToString();
                txtSDT_KH.Text = dgvKhachHang.Rows[rowindex].Cells[4].Value.ToString();
                if (dgvKhachHang.Rows[rowindex].Cells[2].Value.ToString() == "Nam")
                {
                    rbGenderKH_Nam.Checked = true;
                    rbGenderKH_Nu.Refresh();
                }
                if (dgvKhachHang.Rows[rowindex].Cells[2].Value.ToString() == "Nữ")
                {
                    rbGenderKH_Nam.Checked = true;
                    rbGenderKH_Nu.Refresh();
                }
            }
        }
        private void InsertHD_X()
        {
            string ID = txtSO_HD_X.Text;
            string tenkh = cmbNameKH_HD_X.Text;
            string tennv = cmbNameNV_HDX.Text;
            DateTime d1 = dpNgayLap_HD_X.Value;
            string trangthai = "";
            if (cbFinish_HD_X.Checked == true)
                trangthai = "Đã hoàn thành";
            else
                trangthai = "Chưa hoàn thành";

            //Add dữ liệu vào sql

            cnn.Open();
            string insertSql = @"exec insert_HDX @Sohd = '"+ID+"',@tenkh = N'"+tenkh+ "',@tennv= N'"+tennv+ "', @ngaylap = '"+d1.ToString("yyyyMMdd")+ "',@trangthai = N'"+trangthai+"'";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(insertSql, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();
            LoadDataHD_X();
            txtSO_HD_X.ResetText();
            cmbNameNV_HDX.ResetText();
            cbFinish_HD_X.Checked = false;
            cmbNameKH_HD_X.ResetText();
            d1= DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dpNgayLap_HD_X.Value = d1;
        }
        private void btnAddHD_X_Click(object sender, EventArgs e)
        {
            string messager = "\n";
            int count = 0;
            if (txtSO_HD_X.Text == "")
            {
                messager = messager + "\n Mã hóa đơn được để trống\n" ;
                count++;
            }
            else
                messager = messager + "";
            MessageBox.Show(txtSO_HD_X.Text);
            if (checkPrimaryKey(txtSO_HD_X.Text, "SO_HD_XUAT", "HOADON_XUAT") == true)
            {
                messager = messager + "\nMã hóa đơn không được trùng nhau, Vui lòng nhập mã hóa đơn khác\n";
                count++;
            }
            else
                messager = messager + "";
            if (cmbNameKH_HD_X.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên khách hàng!!\n";
                count++;
            }
            else
                messager = messager + "";
            if (cmbNameNV_HDX.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên nhân viên\n";
                count++;
            }
            else
                messager = messager + "";
            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
                try
                {
                    InsertHD_X();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                }
        }
        private int kt_tuoiNV(DateTime dateTime)
        {
            cnn.Open();
            string sql = @"exec TuoiNV @ngaysinh = '" + dateTime.ToString("yyyyMMdd") + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                MessageBox.Show(dr.Field<int>(0).ToString());
                if (dr.Field<int>(0) < 0)
                    i = -1;
                else if (dr.Field<int>(0) > 0)
                    i = 1;
            }
            cnn.Close();
            return i;
        }
        private void btbUpdate_KH_Click(object sender, EventArgs e)
        {
            string messager = "";
            int count = 0;
            
            if (txtName_KH.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên !!";
                count++;
            }
            else
                messager = messager + "";
            if (txtAdress_KH.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ";
                count++;
            }
            else
                messager = messager + "";
            if (txtSDT_KH.Text == "")
            {
                messager = messager + "\nVui lòng nhập SĐT";
                count++;
            }
            else
                messager = messager + "";
            if (rbGenderKH_Nam.Checked != true && rbGenderKH_Nu.Checked != true)
            {
                messager = messager + "\nVui lòng chọn một trong hai";
                count++;
            }
            else
                messager = messager + "";

            string makh = txtMAKH.Text;
            string tenkh = txtName_KH.Text;
            string diachi = txtAdress_KH.Text;
            string sdt = txtSDT_KH.Text;
            string gender = "";
            if (rbGenderKH_Nam.Checked == true)
                gender = "Nam";
            if (rbGenderKH_Nu.Checked == true)
                gender = "Nữ";

            //Add dữ liệu vào sql

            
            if (checkPrimaryKey(txtMAKH.Text, "MAKH", "KHACHHANG") == false)
            {
                messager = messager + "\nKhach hang này chưa được tạo ";
                count++;
            }
            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
            {
                cnn.Open();
                string insertSql = @"exec update_KH @makh = '" + makh + "',@tenkh = N'" + tenkh + "',@diachi = N'" + diachi + "',@gioitinh = N'" + gender + "',@sdt= '" + sdt + "'";
                SqlCommand cmdNGUOIDUNG = new SqlCommand(insertSql, cnn);
                cmdNGUOIDUNG.ExecuteNonQuery();
                cnn.Close();
                LoadDataKH(@"select * from KHACHHANG");
                txtMAKH.ResetText();
                txtName_KH.ResetText();
                txtAdress_KH.ResetText();
                rbGenderKH_Nam.Checked = false;
                rbGenderKH_Nu.Checked = false;
                txtSDT_KH.ResetText();
            } 
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dgvKhachHang.CurrentCell.RowIndex;
                txtMAKH.Text = dgvKhachHang.Rows[rowindex].Cells[0].Value.ToString();
                txtName_KH.Text = dgvKhachHang.Rows[rowindex].Cells[1].Value.ToString();
                txtAdress_KH.Text = dgvKhachHang.Rows[rowindex].Cells[3].Value.ToString();
                txtSDT_KH.Text = dgvKhachHang.Rows[rowindex].Cells[4].Value.ToString();
                if (dgvKhachHang.Rows[rowindex].Cells[2].Value.ToString() == "Nam")
                {
                    rbGenderKH_Nam.Checked = true;
                    rbGenderKH_Nu.Refresh();
                }
                if (dgvKhachHang.Rows[rowindex].Cells[2].Value.ToString() == "Nữ")
                {
                    rbGenderKH_Nam.Checked = true;
                    rbGenderKH_Nu.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Quá trình xóa xảy ra lỗi, vui lòng thử lại!!!");
                cnn.Close();
            }
        }

        private void btnDelete_KH_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                int rowindex = dgvKhachHang.CurrentCell.RowIndex;
                string makh = dgvKhachHang.Rows[rowindex].Cells[0].Value.ToString();
                string sqlDelete = @"DELETe from KHACHHANG where makh = '" + makh + "'";
                SqlCommand cmdDelete = new SqlCommand(sqlDelete, cnn);
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!");
                cnn.Close();
                LoadDataKH(@"select * from KHACHHANG");
                txtMAKH.ResetText();
                txtName_KH.ResetText();
                txtAdress_KH.ResetText();
                rbGenderKH_Nam.Checked = false;
                rbGenderKH_Nu.Checked = false;
                txtSDT_KH.ResetText();
            }
            catch
            {
                MessageBox.Show("Quá trình xóa xảy ra lỗi, vui lòng thử lại!!!");
                cnn.Close();
            }
        }

        private void btnDeleteHD_X_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = txtSO_HD_X.Text;
                cnn.Open();
                string Sql = @"delete from HOADON_XUAT where SO_HD_XUAT = '" + Id + "'";
                SqlCommand cmddelete = new SqlCommand(Sql, cnn);
                cmddelete.ExecuteNonQuery();
                cnn.Close();
                LoadDataHD_X();
                txtSO_HD_X.ResetText();
                cmbNameNV_HDX.ResetText();
                cbFinish_HD_X.Checked = false;
                cmbNameKH_HD_X.ResetText();
                dpNgayLap_HD_X.Value = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Quá trình xóa xảy ra lỗi, vui lòng thử lại!!!");
                cnn.Close();
            }
        }

        private void dgvHD_X_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dgvHD_X.CurrentCell.RowIndex;
                txtSO_HD_X.Text = dgvHD_X.Rows[rowindex].Cells[0].Value.ToString();
                cmbNameKH_HD_X.Text = dgvHD_X.Rows[rowindex].Cells[2].Value.ToString();
                cmbNameNV_HDX.Text = dgvHD_X.Rows[rowindex].Cells[3].Value.ToString();
                dpNgayLap_HD_X.Value = DateTime.ParseExact(dgvHD_X.Rows[rowindex].Cells[1].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                if (dgvHD_X.Rows[rowindex].Cells[4].Value.ToString() == "Đã hoàn thành")
                {
                    cbFinish_HD_X.Checked = true;
                }
                if (dgvHD_X.Rows[rowindex].Cells[4].Value.ToString() == "Chưa hoàn thành")
                {
                    cbFinish_HD_X.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dòng này không có dữ liêu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
            }
        }

        private void btnUpdateHD_X_Click(object sender, EventArgs e)
        {
            string messager = "";
            int count = 0;
            if (checkPrimaryKey(txtSO_HD_X.Text, "SO_HD_XUAT", "HOADON_XUAT") == false)
            {
                messager = messager + "\nHóa đon này chưa được tạo ";
                count++;
            }
            if (cmbNameKH_HD_X.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên khách hàng !!";
                count++;
            }
            else
                messager = messager + "";
            if (cmbNameNV_HDX.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ";
                count++;
            }
            else
                messager = messager + "";
            string tenkh = cmbNameKH_HD_X.Text;
            string tennv = cmbNameNV_HDX.Text;
            DateTime d1 = dpNgayLap_HD_X.Value;
            string trangthai = "";
            if (cbFinish_HD_X.Checked == true)
                trangthai = "Đã hoàn thành";
            if (cbFinish_HD_X.Checked == true)
                trangthai = "Chưa hoàn thành";

            //Add dữ liệu vào sql

           

            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
                try
                {
                    cnn.Open();
                    string Sql = @"exec update_hdx @sohd='" + txtSO_HD_X.Text + "', @tenkh = N'" + tenkh + "',@tenNV = N'" + tennv + "',@ngaylap = '" + d1.ToString("yyyyMMdd") + "', @trangthai=N'" + trangthai + "'";
                    SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
                    cmdNGUOIDUNG.ExecuteNonQuery();
                    cnn.Close();
                    LoadDataHD_X();
                     txtSO_HD_X.ResetText();
                    cmbNameNV_HDX.ResetText();
                    cbFinish_HD_X.Checked = false;
                    cmbNameKH_HD_X.ResetText();
                    dpNgayLap_HD_X.Value = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
            
        }

        private void cmbLoaihang_SelectedValueChanged(object sender, EventArgs e)
        {
            
            dgvKho.Rows.Clear();
            cnn.Open();
            string sql = @"exec Hang_LoaiHang @tenloai = N'"+cmbLoaihang.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvKho.Rows.Add();
                dgvKho.Rows[i].Cells[0].Value = dr.Field<string>(0);
                dgvKho.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvKho.Rows[i].Cells[2].Value = dr.Field<int>(2);
                dgvKho.Rows[i].Cells[3].Value = dr.Field<string>(3);
                i++;
            }
            cnn.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataKho();
        }
        private void Insert_NCC()
        {
            string mancc = txtID_NCC.Text;
            string tenncc = txtName_NCC.Text;
            string adress = txtAdress_NCC.Text;
            string sdt = txtSDT_NCC.Text;

            cnn.Open();
            string Sql = @"insert into NHACUNGCAP values ('"+mancc+ "',N'"+tenncc+ "',N'"+adress+ "','"+sdt+"')";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();

        }
        private void Insert_LH()
        {
            string malh = txtId_LH.Text;
            string tenlh = txtName_LH.Text;
            string adress = txtCT_LH.Text;
            string trangthai;
            if (cbTrangThai_LoaiHang.Checked == true)
                trangthai = "Còn Kinh Doanh";
            else
                trangthai = "Đã Hết Kinh Doanh";
            cnn.Open();
            string Sql = @"insert into LOAIHANG values ('" + malh + "',N'" + tenlh + "',N'" + adress + "','" + trangthai + "')";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();

        }
        private void Insert_HH()
        {
            string mahh = txtID_HH.Text;
            string tenhh = txtTen_HH.Text;
            string dvt = txtDVT_HH.Text;
            string xuatxu = txtMade_HH.Text;
            string trangthai = cmbID_LH.Text;
            
            cnn.Open();
            string Sql = @"insert into HANGHOA (MAHH, TENHH, DONVI_TINH,XUATXU, MALOAI) values ('" + mahh + "',N'" + tenhh + "',N'" + dvt + "',N'" + xuatxu + "','"+trangthai+"')";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();

        }
        private void btnAdd_NCC_Click(object sender, EventArgs e)
        {
            string messager = "";
            int count = 0;
            if (txtID_NCC.Text == "")
            {
                messager = messager + "\n Mã nhà cung cấp không được để trống\n";
                count++;
            }
            else
                messager = messager + "";
            if (checkPrimaryKey(txtID_NCC.Text, "MANCC", "NHACUNGCAP") == true)
            {
                messager = messager + "\nMã nhà cung cấp không được trùng nhau, Vui lòng nhập mã nhà cung cấp khác\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtName_NCC.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên nhà cung cấp!!\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtAdress_NCC.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtSDT_NCC.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";

            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
                try
            {
                Insert_NCC();
                LoadDataNCC(@"select * from NHACUNGCAP");
                txtID_NCC.ResetText();
                txtName_NCC.ResetText();
                txtAdress_NCC.ResetText();
                txtSDT_NCC.ResetText();
            }
            catch
            {
                MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
            }
        }
        private void InsertHD_N()
        {
            string ID = txtHĐN.Text;
            string tenncc = cmbNhaCungCap.Text;
            string tennv = cmbNameNV_HDN.Text;
            DateTime d1 = dtpNgayLapNhap.Value;
            string trangthai = "";
            if (cbFinish_HDN.Checked == true)
                trangthai = "Đã hoàn thành";
            else
                trangthai = "Chưa hoàn thành";

            //Add dữ liệu vào sql

            cnn.Open();
            string insertSql = @"exec insert_HDN @Sohd = '" + ID + "',@tenncc = N'" + tenncc + "',@tennv= N'" + tennv + "', @ngaylap = '" + d1.ToString("yyyyMMdd") + "',@trangthai = N'" + trangthai + "'";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(insertSql, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();
            LoadDataHD_N();
            txtHĐN.ResetText();
            cmbNameNV_HDN.ResetText();
            cbFinish_HDN.Checked = false;
            cmbNhaCungCap.ResetText();
            d1 = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dtpNgayLapNhap.Value = d1;
        }
        private void btnAdd_HDN_Click(object sender, EventArgs e)
        {
            string messager = "\n";
            int count = 0;
            if (txtHĐN.Text == "")
            {
                messager = messager + "\n Mã hóa đơn được để trống\n";
                count++;
            }
            else
                messager = messager + "";
            if (checkPrimaryKey(txtHĐN.Text, "SO_HD_NHAP", "HOADON_NHAP") == true)
            {
                messager = messager + "\nMã hóa đơn không được trùng nhau, Vui lòng nhập mã hóa đơn khác\n";
                count++;
            }
            else
                messager = messager + "";
            if (cmbNhaCungCap.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên nhà cung cấp!!\n";
                count++;
            }
            else
                messager = messager + "";
            if (cmbNameNV_HDN.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên nhân viên\n";
                count++;
            }
            else
                messager = messager + "";
            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
                try
                {
                    InsertHD_N();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                }
                
        }

        private void dgvHD_N_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dgvHD_N.CurrentCell.RowIndex;
                txtHĐN.Text = dgvHD_N.Rows[rowindex].Cells[0].Value.ToString();
                cmbNhaCungCap.Text = dgvHD_N.Rows[rowindex].Cells[2].Value.ToString();
                cmbNameNV_HDN.Text = dgvHD_N.Rows[rowindex].Cells[3].Value.ToString();
                dtpNgayLapNhap.Value = DateTime.ParseExact(dgvHD_X.Rows[rowindex].Cells[1].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                if (dgvHD_N.Rows[rowindex].Cells[4].Value.ToString() == "Đã hoàn thành")
                {
                    cbFinish_HDN.Checked = true;
                }
                if (dgvHD_N.Rows[rowindex].Cells[4].Value.ToString() == "Chưa hoàn thành")
                {
                    cbFinish_HDN.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dòng này không có dữ liêu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
            }
        }

        private void btnDelete_HDN_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = txtHĐN.Text;
                cnn.Open();
                string Sql = @"delete from HOADON_NHAP where SO_HD_NHAP = '" + Id + "'";
                SqlCommand cmddelete = new SqlCommand(Sql, cnn);
                cmddelete.ExecuteNonQuery();
                cnn.Close();
                LoadDataHD_N();
                txtHĐN.ResetText();
                cmbNameNV_HDN.ResetText();
                cbFinish_HDN.Checked = false;
                cmbNhaCungCap.ResetText();
                dtpNgayLapNhap.Value = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Quá trình xóa xảy ra lỗi, vui lòng thử lại!!!");
                cnn.Close();
            }
        }

        private void btnUpdate_HDN_Click(object sender, EventArgs e)
        {
            string messager = "";
            int count = 0;
            if (checkPrimaryKey(txtHĐN.Text, "SO_HD_NHAP", "HOADON_NHAP") == false)
            {
                messager = messager + "\nHóa đon này chưa được tạo ";
                count++;
            }
            if (cmbNhaCungCap.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên khách hàng !!";
                count++;
            }
            else
                messager = messager + "";
            if (cmbNameNV_HDN.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ";
                count++;
            }
            else
                messager = messager + "";
            string tenkh = cmbNhaCungCap.Text;
            string tennv = cmbNameNV_HDN.Text;
            DateTime d1 = dtpNgayLapNhap.Value;
            string trangthai = "";
            if (cbFinish_HDN.Checked == true)
                trangthai = "Đã hoàn thành";
            if (cbFinish_HDN.Checked == true)
                trangthai = "Chưa hoàn thành";

            //Add dữ liệu vào sql

            

            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
               
                    cnn.Open();
                    string Sql = @"exec update_hdn @sohd='" + txtHĐN.Text + "', @tenncc = N'" + tenkh + "',@tenNV = N'" + tennv + "',@ngaylap = '" + d1.ToString("yyyyMMdd") + "', @trangthai=N'" + trangthai + "'";
                    SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
                    cmdNGUOIDUNG.ExecuteNonQuery();
                    cnn.Close();
                    LoadDataHD_N();
                    txtHĐN.ResetText();
                    cmbNameNV_HDN.ResetText();
                    cbFinish_HDN.Checked = false;
                    cmbNhaCungCap.ResetText();
                    dtpNgayLapNhap.Value = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
               
        }

        private void btnAdd_LH_Click(object sender, EventArgs e)
        {
            string messager = "";
            int count = 0;
            if (txtId_LH.Text == "")
            {
                messager = messager + "\n Mã loại hàng không được để trống\n";
                count++;
            }
            else
                messager = messager + "";
            if (checkPrimaryKey(txtId_LH.Text, "MALOAI", "LOAIHANG") == true)
            {
                messager = messager + "\nMã loại hàng không được trùng nhau, Vui lòng nhập mã loại hàng khác\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtName_LH.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên loại hàng!!\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtCT_LH.Text == "")
            {
                messager = messager + "\nVui lòng nhập chi tiết loại hàng\n";
                count++;
            }
            else
                messager = messager + "";
            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
                try
                {
                    Insert_LH();
                    LoadDataLoaiHang(@"select * from loaihang");
                    txtId_LH.ResetText();
                    txtName_LH.ResetText();
                    txtCT_LH.ResetText();
                    cbTrangThai_LoaiHang.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                }
        }

        private void btnAdd_HH_Click(object sender, EventArgs e)
        {
            string messager = "";
            int count = 0;
            if (txtID_HH.Text == "")
            {
                messager = messager + "\n Mã nhà cung cấp không được để trống\n";
                count++;
            }
            else
                messager = messager + "";
            if (checkPrimaryKey(txtID_HH.Text, "MAHH", "HANGHOA") == true)
            {
                messager = messager + "\nMã nhà cung cấp không được trùng nhau, Vui lòng nhập mã nhà cung cấp khác\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtTen_HH.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên nhà cung cấp!!\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtDVT_HH.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtMade_HH.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";
            if (cmbID_LH.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";

            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
                try
                {
                    Insert_HH();
                    LoadDataHH(@"exec LoadData_HH");
                    txtID_HH.ResetText();
                    txtTen_HH.ResetText();
                    txtDVT_HH.ResetText();
                    txtMade_HH.ResetText();
                    cmbID_LH.ResetText();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                }
        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dgvHang.CurrentCell.RowIndex;
                txtID_HH.Text = dgvHang.Rows[rowindex].Cells[1].Value.ToString();
                txtTen_HH.Text = dgvHang.Rows[rowindex].Cells[2].Value.ToString();
                txtDVT_HH.Text = dgvHang.Rows[rowindex].Cells[3].Value.ToString();
                txtMade_HH.Text = dgvHang.Rows[rowindex].Cells[4].Value.ToString();
                cmbID_LH.Text = dgvHang.Rows[rowindex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dòng này không có dữ liêu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
            }
        }

        private void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dgvLoaiHang.CurrentCell.RowIndex;
                txtId_LH.Text = dgvLoaiHang.Rows[rowindex].Cells[0].Value.ToString();
                txtName_LH.Text = dgvLoaiHang.Rows[rowindex].Cells[1].Value.ToString();
                txtCT_LH.Text = dgvLoaiHang.Rows[rowindex].Cells[2].Value.ToString();
                if (dgvLoaiHang.Rows[rowindex].Cells[3].Value.ToString() == "Còn Kinh Doanh")
                {
                    cbTrangThai_LoaiHang.Checked = true;
                }
                if (dgvLoaiHang.Rows[rowindex].Cells[3].Value.ToString() == "Đã Hết Kinh Doanh")
                {
                    cbTrangThai_LoaiHang.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dòng này không có dữ liêu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
            }
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dgvNCC.CurrentCell.RowIndex;
                txtID_NCC.Text = dgvNCC.Rows[rowindex].Cells[0].Value.ToString();
                txtName_NCC.Text = dgvNCC.Rows[rowindex].Cells[1].Value.ToString();
                txtAdress_NCC.Text = dgvNCC.Rows[rowindex].Cells[2].Value.ToString();
                txtSDT_NCC.Text = dgvNCC.Rows[rowindex].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dòng này không có dữ liêu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
            }
        }

        private void btnDelete_NCC_Click(object sender, EventArgs e)
        {
            string ID = txtID_NCC.Text;
            int count =0;
            if (checkPrimaryKey(ID, "MANCC", "NHACUNGCAP") == false)
            {
                count++;
            }
            else
                count = 0;
            if(count == 1)
                MessageBox.Show("Nhà cung cấp này chưa được tạo, Vui lòng nhập mã nhà cung cấp khác");
            if (count == 0)

                try
                {
                    cnn.Open();
                    string Sql = @"delete from NHACUNGCAP where MANCC = '" + ID + "'";
                    SqlCommand cmd = new SqlCommand(Sql, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    LoadDataNCC(@"select * from NHACUNGCAP");
                    txtID_NCC.ResetText();
                    txtName_NCC.ResetText();
                    txtAdress_NCC.ResetText();
                    txtSDT_NCC.ResetText();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
        }

        private void btnDelete_LH_Click(object sender, EventArgs e)
        {
            string ID = txtId_LH.Text;
            int count = 0;
            if (checkPrimaryKey(ID, "MALOAI", "LOAIHANG") == false)
            {
                count++;
            }
            if (count == 1)
                MessageBox.Show("Loại hàng này chưa được tạo, Vui lòng nhập mã loại hàng khác");
            if (count == 0)

                try
                {
                    cnn.Open();
                    string Sql = @"delete from LOAIHANG where MALOAI = '" + ID + "'";
                    SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
                    cmdNGUOIDUNG.ExecuteNonQuery();
                    cnn.Close();
                    LoadDataLoaiHang(@"select * from loaihang");
                    txtId_LH.ResetText();
                    txtName_LH.ResetText();
                    txtCT_LH.ResetText();
                    cbTrangThai_LoaiHang.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
        }

        private void btnDelete_HH_Click(object sender, EventArgs e)
        {
            string ID = txtID_HH.Text;
            int count = 0;
            if (checkPrimaryKey(ID, "MAHH", "HANGHOA") == false)
            {
                count++;
            }
            if (count == 1)
                MessageBox.Show("Hang này chưa được tạo, Vui lòng nhập mã nhà cung cấp khác");
            if (count == 0)
                try
                {
                    cnn.Open();
                    string Sql = @"delete from HANGHOA where MAHH = '" + ID + "'";
                    SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
                    cmdNGUOIDUNG.ExecuteNonQuery();
                    cnn.Close();
                    LoadDataHH(@"exec LoadData_HH");
                    txtID_HH.ResetText();
                    txtTen_HH.ResetText();
                    txtDVT_HH.ResetText();
                    txtMade_HH.ResetText();
                    cmbID_LH.ResetText();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
        }
        private void Update_NCC()
        {
            string mancc = txtID_NCC.Text;
            string tenncc = txtName_NCC.Text;
            string adress = txtAdress_NCC.Text;
            string sdt = txtSDT_NCC.Text;

            cnn.Open();
            string Sql = @"update NHACUNGCAP set TENNCC = N'" + tenncc + "',DIACHI = N'" + adress + "',SDT = '" + sdt + "' where  MANCC ='" + mancc + "'";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();

        }
        private void Update_LH()
        {
            string malh = txtId_LH.Text;
            string tenlh = txtName_LH.Text;
            string adress = txtCT_LH.Text;
            string trangthai;
            if (cbTrangThai_LoaiHang.Checked == true)
                trangthai = "Còn Kinh Doanh";
            else
                trangthai = "Đã Hết Kinh Doanh";
            cnn.Open();
            string Sql = @"update LOAIHANG set TENLOAI = N'" + tenlh + "',DIENGIAI =  N'" + adress + "',FLAG =  N'" + trangthai + "' where MALOAI= '" + malh + "'";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();

        }
        private void Update_HH()
        {
            string mahh = txtID_HH.Text;
            string tenhh = txtTen_HH.Text;
            string dvt = txtDVT_HH.Text;
            string xuatxu = txtMade_HH.Text;
            string trangthai = cmbID_LH.Text;

            cnn.Open();
            string Sql = @"update HANGHOA set TENHH = N'" + tenhh + "',DVT = N'" + dvt + "',XUATXU = N'" + xuatxu + "',MALOAI = '" + trangthai + "' where MAHH ='" + mahh + "'";
            SqlCommand cmdNGUOIDUNG = new SqlCommand(Sql, cnn);
            cmdNGUOIDUNG.ExecuteNonQuery();
            cnn.Close();

        }
        private void btnUpdate_NCC_Click(object sender, EventArgs e)
        {
            string messager = "";
            int count = 0;
            if (txtID_NCC.Text == "")
            {
                messager = messager + "\n Mã nhà cung cấp không được để trống\n";
                count++;
            }
            else
                messager = messager + "";
            if (checkPrimaryKey(txtID_NCC.Text, "MANCC", "NHACUNGCAP") == false)
            {
                messager = messager + "\nMã nhà cung cấp chưa được tạo, Vui lòng nhập mã nhà cung cấp khác\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtName_NCC.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên nhà cung cấp!!\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtAdress_NCC.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtSDT_NCC.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";

            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
                try
                {
                    Update_NCC();
                    LoadDataNCC(@"select * from NHACUNGCAP");
                    txtID_NCC.ResetText();
                    txtName_NCC.ResetText();
                    txtAdress_NCC.ResetText();
                    txtSDT_NCC.ResetText();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
        }

        private void btnUpdate_LH_Click(object sender, EventArgs e)
        {
            string messager = "";
            int count = 0;
            if (txtId_LH.Text == "")
            {
                messager = messager + "\n Mã loại hàng không được để trống\n";
                count++;
            }
            else
                messager = messager + "";
            if (checkPrimaryKey(txtId_LH.Text, "MALOAI", "LOAIHANG") == false)
            {
                messager = messager + "\nMã loại hàng chưa được tạo, Vui lòng nhập mã loại hàng khác\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtName_LH.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên loại hàng!!\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtCT_LH.Text == "")
            {
                messager = messager + "\nVui lòng nhập chi tiết loại hàng\n";
                count++;
            }
            else
                messager = messager + "";
            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
                try
                {
                    Update_LH();
                    LoadDataLoaiHang(@"select * from loaihang");
                    txtId_LH.ResetText();
                    txtName_LH.ResetText();
                    txtCT_LH.ResetText();
                    cbTrangThai_LoaiHang.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
        }

        private void btnUpdate_HH_Click(object sender, EventArgs e)
        {
            string messager = "";
            int count = 0;
            if (txtID_HH.Text == "")
            {
                messager = messager + "\n Mã nhà cung cấp không được để trống\n";
                count++;
            }
            else
                messager = messager + "";
            if (checkPrimaryKey(txtID_HH.Text, "MAHH", "HANGHOA") == false)
            {
                messager = messager + "\nMã Hàng này chưa được tạo, Vui lòng nhập mã nhà cung cấp khác\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtTen_HH.Text == "")
            {
                messager = messager + "\nVui lòng nhập Tên nhà cung cấp!!\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtDVT_HH.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";
            if (txtMade_HH.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";
            if (cmbID_LH.Text == "")
            {
                messager = messager + "\nVui lòng nhập địa chỉ nhà cung cấp\n";
                count++;
            }
            else
                messager = messager + "";

            if (count != 0)
            {
                MessageBox.Show(messager);
            }
            if (count == 0)
                try
                {
                    Update_HH();
                    LoadDataHH(@"exec LoadData_HH");
                    txtID_HH.ResetText();
                    txtTen_HH.ResetText();
                    txtDVT_HH.ResetText();
                    txtMade_HH.ResetText();
                    cmbID_LH.ResetText();
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!! Vui lòng thử lại!");
                    cnn.Close();
                }
        }

        private void btnSearch_NCC_Click(object sender, EventArgs e)
        {
            if (rbSearch_Ten_NCC.Checked == true)
            {
                LoadDataNCC(@"EXEC TK_NHACUNGCAP_THEOTEN @TENCC = N'" + txtSearch_NCC.Text + "'");
                int rowindex = 0;
                txtID_NCC.Text = dgvNCC.Rows[rowindex].Cells[0].Value.ToString();
                txtName_NCC.Text = dgvNCC.Rows[rowindex].Cells[1].Value.ToString();
                txtAdress_NCC.Text = dgvNCC.Rows[rowindex].Cells[2].Value.ToString();
                txtSDT_NCC.Text = dgvNCC.Rows[rowindex].Cells[3].Value.ToString();
            }
            else
            {
                LoadDataNCC(@"EXEC TK_NHACUNGCAP_THEOMA @MANCC = '" + txtSearch_NCC.Text + "'");
                int rowindex = 0;
                txtID_NCC.Text = dgvNCC.Rows[rowindex].Cells[0].Value.ToString();
                txtName_NCC.Text = dgvNCC.Rows[rowindex].Cells[1].Value.ToString();
                txtAdress_NCC.Text = dgvNCC.Rows[rowindex].Cells[2].Value.ToString();
                txtSDT_NCC.Text = dgvNCC.Rows[rowindex].Cells[3].Value.ToString();
            }
        }

        private void btnSearch_LH_Click(object sender, EventArgs e)
        {
            if (rbSearch_ID_LH.Checked == true)
            {
                LoadDataLoaiHang(@"exec TK_LOAIHANG_THEOMA @MALH ='"+txtSearch_LH.Text+"'");
                int rowindex = 0;
                txtId_LH.Text = dgvLoaiHang.Rows[rowindex].Cells[0].Value.ToString();
                txtName_LH.Text = dgvLoaiHang.Rows[rowindex].Cells[1].Value.ToString();
                txtCT_LH.Text = dgvLoaiHang.Rows[rowindex].Cells[2].Value.ToString();
                if (dgvLoaiHang.Rows[rowindex].Cells[3].Value.ToString() == "Còn Kinh Doanh")
                {
                    cbTrangThai_LoaiHang.Checked = true;
                }
                if (dgvLoaiHang.Rows[rowindex].Cells[3].Value.ToString() == "Đã Hết Kinh Doanh")
                {
                    cbTrangThai_LoaiHang.Checked = false;
                }
            }
            else
            {
                LoadDataLoaiHang(@"exec TK_LOAIHANG_THEOTEN @TENLH = N'"+txtSearch_LH.Text+"'");
                int rowindex = 0;
                txtId_LH.Text = dgvLoaiHang.Rows[rowindex].Cells[0].Value.ToString();
                txtName_LH.Text = dgvLoaiHang.Rows[rowindex].Cells[1].Value.ToString();
                txtCT_LH.Text = dgvLoaiHang.Rows[rowindex].Cells[2].Value.ToString();
                if (dgvLoaiHang.Rows[rowindex].Cells[3].Value.ToString() == "Còn Kinh Doanh")
                {
                    cbTrangThai_LoaiHang.Checked = true;
                }
                if (dgvLoaiHang.Rows[rowindex].Cells[3].Value.ToString() == "Đã Hết Kinh Doanh")
                {
                    cbTrangThai_LoaiHang.Checked = false;
                }
            }
        }

        private void btnSearch_HH_Click(object sender, EventArgs e)
        {
            if (rbSearch_ID_HH.Checked == true)
            {
                LoadDataHH(@"exec TK_HANGHOA_THEOMA @MAHH ='" + txtSearch_HH.Text + "'");
                int rowindex = 0;
                txtID_HH.Text = dgvHang.Rows[rowindex].Cells[1].Value.ToString();
                txtTen_HH.Text = dgvHang.Rows[rowindex].Cells[2].Value.ToString();
                txtDVT_HH.Text = dgvHang.Rows[rowindex].Cells[3].Value.ToString();
                txtMade_HH.Text = dgvHang.Rows[rowindex].Cells[4].Value.ToString();
                cmbID_LH.Text = dgvHang.Rows[rowindex].Cells[0].Value.ToString();
            }
            else
            {
                LoadDataHH(@"exec TK_HANGHOA_THEOTEN @TENHH =N'"+txtSearch_HH.Text+"'");
                int rowindex = 0;
                txtID_HH.Text = dgvHang.Rows[rowindex].Cells[1].Value.ToString();
                txtTen_HH.Text = dgvHang.Rows[rowindex].Cells[2].Value.ToString();
                txtDVT_HH.Text = dgvHang.Rows[rowindex].Cells[3].Value.ToString();
                txtMade_HH.Text = dgvHang.Rows[rowindex].Cells[4].Value.ToString();
                cmbID_LH.Text = dgvHang.Rows[rowindex].Cells[0].Value.ToString();
            }
            
        }
    }
}
