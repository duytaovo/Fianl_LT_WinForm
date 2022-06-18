namespace QuanLySinhVien_Final
{
    partial class frmReportMH
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
            this.reportViewerMH = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerMH
            // 
            this.reportViewerMH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerMH.Location = new System.Drawing.Point(0, 0);
            this.reportViewerMH.Name = "reportViewerMH";
            this.reportViewerMH.ServerReport.BearerToken = null;
            this.reportViewerMH.Size = new System.Drawing.Size(800, 450);
            this.reportViewerMH.TabIndex = 0;
            // 
            // frmReportMH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerMH);
            this.Name = "frmReportMH";
            this.Text = "frmReportMH";
            this.Load += new System.EventHandler(this.frmReportMH_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerMH;
    }
}