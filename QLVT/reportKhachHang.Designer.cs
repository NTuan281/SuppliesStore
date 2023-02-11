
namespace QLVT
{
    partial class reportKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.KHACHHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUAN_LY_VAT_TUDataSet = new QLVT.QUAN_LY_VAT_TUDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.KHACHHANGTableAdapter = new QLVT.QUAN_LY_VAT_TUDataSetTableAdapters.KHACHHANGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.KHACHHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_VAT_TUDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // KHACHHANGBindingSource
            // 
            this.KHACHHANGBindingSource.DataMember = "KHACHHANG";
            this.KHACHHANGBindingSource.DataSource = this.QUAN_LY_VAT_TUDataSet;
            // 
            // QUAN_LY_VAT_TUDataSet
            // 
            this.QUAN_LY_VAT_TUDataSet.DataSetName = "QUAN_LY_VAT_TUDataSet";
            this.QUAN_LY_VAT_TUDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dtbKhachHang";
            reportDataSource1.Value = this.KHACHHANGBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLVT.reportKhachHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1108, 670);
            this.reportViewer1.TabIndex = 0;
            // 
            // KHACHHANGTableAdapter
            // 
            this.KHACHHANGTableAdapter.ClearBeforeFill = true;
            // 
            // reportKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 670);
            this.Controls.Add(this.reportViewer1);
            this.Name = "reportKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo danh sách khách hàng";
            this.Load += new System.EventHandler(this.reportKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KHACHHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_VAT_TUDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource KHACHHANGBindingSource;
        private QUAN_LY_VAT_TUDataSet QUAN_LY_VAT_TUDataSet;
        private QUAN_LY_VAT_TUDataSetTableAdapters.KHACHHANGTableAdapter KHACHHANGTableAdapter;
    }
}