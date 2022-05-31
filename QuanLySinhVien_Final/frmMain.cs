using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien_Final
{
    public partial class frmMain : Form
    {
        public static bool bIsLogin = false;
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void DangNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmDangNhap = new frmLogin();
            frmDangNhap.ShowDialog();

            if (frmMain.bIsLogin == true)
            {
                DangNhapToolStripMenuItem.Enabled = false;
                DangXuatToolStripMenuItem.Enabled = true;
                pan_Main.Enabled = true;
                quanlyTK_ToolStripMenuItem.Enabled = true;
                TacVuToolStripMenuItem.Enabled = true;
                báoCáoToolStripMenuItem.Enabled = true;
                grBoxLeftMenu.Enabled = true;
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            grBoxLeftMenu.Enabled = false;
            menuStrip1.Visible = true;
            TacVuToolStripMenuItem.Enabled = false;
            báoCáoToolStripMenuItem.Enabled = false;

        }

        private void quanliSV_L_MH_NGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLy frmQuanLy = new frmQuanLy();
            frmQuanLy.Show();
        }

        private void btnQLDIEM_ex_Click(object sender, EventArgs e)
        {

        }
    }
}
