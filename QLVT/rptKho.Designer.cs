
namespace QLVT
{
    partial class rptKho
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QUAN_LY_VAT_TUDataSet4 = new QLVT.QUAN_LY_VAT_TUDataSet4();
            this.KHOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KHOTableAdapter = new QLVT.QUAN_LY_VAT_TUDataSet4TableAdapters.KHOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_VAT_TUDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.KHOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLVT.ReportKho.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1068, 507);
            this.reportViewer1.TabIndex = 0;
            // 
            // QUAN_LY_VAT_TUDataSet4
            // 
            this.QUAN_LY_VAT_TUDataSet4.DataSetName = "QUAN_LY_VAT_TUDataSet4";
            this.QUAN_LY_VAT_TUDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // KHOBindingSource
            // 
            this.KHOBindingSource.DataMember = "KHO";
            this.KHOBindingSource.DataSource = this.QUAN_LY_VAT_TUDataSet4;
            // 
            // KHOTableAdapter
            // 
            this.KHOTableAdapter.ClearBeforeFill = true;
            // 
            // rptKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 507);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptKho";
            this.Text = "rptKho";
            this.Load += new System.EventHandler(this.rptKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_VAT_TUDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource KHOBindingSource;
        private QUAN_LY_VAT_TUDataSet4 QUAN_LY_VAT_TUDataSet4;
        private QUAN_LY_VAT_TUDataSet4TableAdapters.KHOTableAdapter KHOTableAdapter;
    }
}