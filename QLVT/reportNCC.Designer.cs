
namespace QLVT
{
    partial class reportNCC
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
            this.NHACUNGCAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportNhaCungCap = new QLVT.reportNhaCungCap();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.NHACUNGCAPTableAdapter = new QLVT.reportNhaCungCapTableAdapters.NHACUNGCAPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.NHACUNGCAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportNhaCungCap)).BeginInit();
            this.SuspendLayout();
            // 
            // NHACUNGCAPBindingSource
            // 
            this.NHACUNGCAPBindingSource.DataMember = "NHACUNGCAP";
            this.NHACUNGCAPBindingSource.DataSource = this.reportNhaCungCap;
            // 
            // reportNhaCungCap
            // 
            this.reportNhaCungCap.DataSetName = "reportNhaCungCap";
            this.reportNhaCungCap.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "reportNCC";
            reportDataSource1.Value = this.NHACUNGCAPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLVT.reportNCC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1102, 595);
            this.reportViewer1.TabIndex = 0;
            // 
            // NHACUNGCAPTableAdapter
            // 
            this.NHACUNGCAPTableAdapter.ClearBeforeFill = true;
            // 
            // reportNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 595);
            this.Controls.Add(this.reportViewer1);
            this.Name = "reportNCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo danh sách nhà cung cấp";
            this.Load += new System.EventHandler(this.reportNCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NHACUNGCAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportNhaCungCap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource NHACUNGCAPBindingSource;
        private reportNhaCungCap reportNhaCungCap;
        private reportNhaCungCapTableAdapters.NHACUNGCAPTableAdapter NHACUNGCAPTableAdapter;
    }
}