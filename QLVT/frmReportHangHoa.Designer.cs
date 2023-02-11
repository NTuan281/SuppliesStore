
namespace QLVT
{
    partial class frmReportHangHoa
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
            this.HANGHOABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLVT_HangHoa = new QLVT.QLVT_HangHoa();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HANGHOATableAdapter = new QLVT.QLVT_HangHoaTableAdapters.HANGHOATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HANGHOABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVT_HangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // HANGHOABindingSource
            // 
            this.HANGHOABindingSource.DataMember = "HANGHOA";
            this.HANGHOABindingSource.DataSource = this.QLVT_HangHoa;
            // 
            // QLVT_HangHoa
            // 
            this.QLVT_HangHoa.DataSetName = "QLVT_HangHoa";
            this.QLVT_HangHoa.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dtbreportHangHoa";
            reportDataSource1.Value = this.HANGHOABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLVT.reportHangHoa.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1089, 590);
            this.reportViewer1.TabIndex = 0;
            // 
            // HANGHOATableAdapter
            // 
            this.HANGHOATableAdapter.ClearBeforeFill = true;
            // 
            // frmReportHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 590);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportHangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo danh sách hàng hóa";
            this.Load += new System.EventHandler(this.frmReportHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HANGHOABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLVT_HangHoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource HANGHOABindingSource;
        private QLVT_HangHoa QLVT_HangHoa;
        private QLVT_HangHoaTableAdapters.HANGHOATableAdapter HANGHOATableAdapter;
    }
}