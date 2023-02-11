
namespace QLVT
{
    partial class frmReportLoaiHang
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
            this.LOAIHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLVT_LoaiHang = new QLVT.QLVT_LoaiHang();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LOAIHANGTableAdapter = new QLVT.QLVT_LoaiHangTableAdapters.LOAIHANGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.LOAIHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVT_LoaiHang)).BeginInit();
            this.SuspendLayout();
            // 
            // LOAIHANGBindingSource
            // 
            this.LOAIHANGBindingSource.DataMember = "LOAIHANG";
            this.LOAIHANGBindingSource.DataSource = this.QLVT_LoaiHang;
            // 
            // QLVT_LoaiHang
            // 
            this.QLVT_LoaiHang.DataSetName = "QLVT_LoaiHang";
            this.QLVT_LoaiHang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "QLVT_LoaiHang";
            reportDataSource1.Value = this.LOAIHANGBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLVT.ReportLoaiHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1197, 574);
            this.reportViewer1.TabIndex = 0;
            // 
            // LOAIHANGTableAdapter
            // 
            this.LOAIHANGTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportLoaiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 574);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportLoaiHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo danh danh sách loại hạng";
            this.Load += new System.EventHandler(this.frmReportLoaiHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOAIHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVT_LoaiHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource LOAIHANGBindingSource;
        private QLVT_LoaiHang QLVT_LoaiHang;
        private QLVT_LoaiHangTableAdapters.LOAIHANGTableAdapter LOAIHANGTableAdapter;
    }
}