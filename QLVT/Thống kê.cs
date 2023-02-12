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
    public partial class Thống_kê : Form
    {
        public Thống_kê()
        {
            InitializeComponent();
        }
        string loai = "";
        public Thống_kê(string loai)
        {
            InitializeComponent();
            this.loai = loai;
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=TUAN\MSSQLSERVER01;Initial Catalog=QUAN_LY_VAT_TU;Integrated Security=True");
        private void LoadDataKho()
        {
            dgvBC_Kho.Rows.Clear();
            cnn.Open();
            string sql = @"EXEC BC_Kho ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvBC_Kho.Rows.Add();
                dgvBC_Kho.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvBC_Kho.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvBC_Kho.Rows[i].Cells[2].Value = dr.Field<int>(2);
                dgvBC_Kho.Rows[i].Cells[3].Value = dr.Field<string>(3);
                i++;
            }
            cnn.Close();
        }
      
        private void LoadDataBaoCaoNhap()
        {
            dgvBC_Nhap.Rows.Clear();
            cnn.Open();
            string sql = @"EXEC BC_Nhap";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvBC_Nhap.Rows.Add();
                dgvBC_Nhap.Rows[i].Cells[0].Value = dr.Field<string>(0);
                dgvBC_Nhap.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvBC_Nhap.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvBC_Nhap.Rows[i].Cells[3].Value = dr.Field<int>(3);
                dgvBC_Nhap.Rows[i].Cells[5].Value = dr.Field<DateTime>(5);
                dgvBC_Nhap.Rows[i].Cells[4].Value = dr.Field<int>(4);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataBaoCaoXuat()
        {
            dgvBC_Xuat.Rows.Clear();
            cnn.Open();
            string sql = @"exec BC_XUAT";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvBC_Xuat.Rows.Add();
                dgvBC_Xuat.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvBC_Xuat.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvBC_Xuat.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvBC_Xuat.Rows[i].Cells[3].Value = dr.Field<int>(3);
                dgvBC_Xuat.Rows[i].Cells[5].Value = dr.Field<DateTime>(5);
                dgvBC_Xuat.Rows[i].Cells[4].Value = dr.Field<int>(4);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataNCC()
        {
            dgvTK_NCC.Rows.Clear();
            cnn.Open();
            string sql = @"EXEC TK_NCC ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvTK_NCC.Rows.Add();
                dgvTK_NCC.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvTK_NCC.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvTK_NCC.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvTK_NCC.Rows[i].Cells[3].Value = dr.Field<string>(3);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataKH()
        {
            dgvTK_Khach.Rows.Clear();
            cnn.Open();
            string sql = @"EXEC TK_KH ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvTK_Khach.Rows.Add();
                dgvTK_Khach.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvTK_Khach.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvTK_Khach.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvTK_Khach.Rows[i].Cells[3].Value = dr.Field<string>(3);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataCmb(ComboBox cmb1, string name, string table)
        {
            
            cnn.Open();
            string sql = @"Select "+name+" from "+table; 
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string[] tensp = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                try {
                    tensp[i] = dr.Field<int>(0).ToString(); //lấy trường đầu tiên trong DataTable
                    cmb1.Items.Add(tensp[i]);
                    i++;
                } catch {
                    tensp[i] = dr.Field<string>(0); //lấy trường đầu tiên trong DataTable
                    cmb1.Items.Add(tensp[i]);
                    i++;
                }
                
            }
            cnn.Close();
           
        }
        private void LoadDataLH()
        {
            dgvTK_LH.Rows.Clear();
            cnn.Open();
            string sql = @"EXEC TK_LH ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvTK_LH.Rows.Add();
                dgvTK_LH.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvTK_LH.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvTK_LH.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvTK_LH.Rows[i].Cells[3].Value = dr.Field<string>(3);
                i++;
            }
            cnn.Close();
        }
        private void LoadDataHH()
        {
            dgvTK_HH.Rows.Clear();
            cnn.Open();
            string sql = @"EXEC TK_HH ";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgvTK_HH.Rows.Add();
                dgvTK_HH.Rows[i].Cells[0].Value = dr.Field<int>(0);
                dgvTK_HH.Rows[i].Cells[1].Value = dr.Field<string>(1);
                dgvTK_HH.Rows[i].Cells[2].Value = dr.Field<string>(2);
                dgvTK_HH.Rows[i].Cells[3].Value = dr.Field<string>(3);
                dgvTK_HH.Rows[i].Cells[4].Value = dr.Field<string>(4);
                i++;
            }
            cnn.Close();
        }
        //PHÂN QUYỀN CHỈ ADMIN MỚI CÓ QUYỀN IN
        private void phanQuyen()
        {
            if (loai == "User")
            {
                btnInDSKH.Enabled = false;
                btnInHangHoa.Enabled = false;
                btnInLoaiHang.Enabled = false;
                btnInNCC.Enabled = false;
                guna2GradientButton1.Enabled = false;
                btnInBCN.Enabled = false;
                btnInBCX.Enabled = false;
            }
        }
        private void Thống_kê_Load(object sender, EventArgs e)
        {
            phanQuyen();
            LoadDataKho();
            LoadDataBaoCaoNhap();
            LoadDataBaoCaoXuat();
            LoadDataNCC();
            LoadDataKH();
            LoadDataLH();
            LoadDataHH();
            LoadDataCmb(cmbHoaDonN,"SO_HD_NHAP","HOADON_NHAP");
            LoadDataCmb(cmbHoaDonX, "SO_HD_XUAT", "HOADON_XUAT");
            LoadDataCmb(cmb1: cmbNCC_N, "TENNCC", "NHACUNGCAP");
            LoadDataCmb(cmb1: cmbNCC_X, "TENNCC", "NHACUNGCAP");
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            LoadDataBaoCaoXuat();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            LoadDataBaoCaoNhap();
        }

        private void btnInDSKH_Click(object sender, EventArgs e)
        {
            reportKhachHang kh = new reportKhachHang();
            kh.ShowDialog();
           
        }

        private void btnInNCC_Click(object sender, EventArgs e)
        {
            reportNCC ncc = new reportNCC();
            ncc.ShowDialog();
        }

        private void btnInLoaiHang_Click(object sender, EventArgs e)
        {
            frmReportLoaiHang lh = new frmReportLoaiHang();
            lh.ShowDialog();
        }

        private void btnInHangHoa_Click(object sender, EventArgs e)
        {
            frmReportHangHoa hh = new frmReportHangHoa();
            hh.ShowDialog();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            rptKho kho = new rptKho();
            kho.ShowDialog();
        }
    }
}
