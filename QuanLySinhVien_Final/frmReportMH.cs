using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLySinhVien_Final.LogicLayer;

namespace QuanLySinhVien_Final
{
    public partial class frmReportMH : Form
    {
        public frmReportMH()
        {
            InitializeComponent();
        }

        private void frmReportMH_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewerMH.LocalReport.ReportEmbeddedResource = "QuanLySinhVien_Final.ReportMH.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = LogicMonHoc.Instance.LayMonHocs();
                reportViewerMH.LocalReport.DataSources.Add(reportDataSource);

                this.reportViewerMH.RefreshReport();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
