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
    public partial class frmReportDSSV : Form
    {
        public frmReportDSSV()
        {
            InitializeComponent();
        }

        private void frmReportDSSV_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewerDSSV.LocalReport.ReportEmbeddedResource = "QuanLySinhVien_Final.ReportDSSV.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet2";
                reportDataSource.Value = LogicSinhVien.Instance.LaySinhViens();
                reportViewerDSSV.LocalReport.DataSources.Add(reportDataSource);

                this.reportViewerDSSV.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
