using System;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace QuanLySinhVien_Final
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void ckbHienthimk_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienthimk.Checked)
            {
                txtPass.PasswordChar = (char)0;
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn Hủy ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strConnectionString = @"Data Source = DESKTOP-12J6D6C;" +
                                        "Initial Catalog = QLSinhVien;"
                                        + "Integrated Security=True";
            //dt ket noi db
            SqlConnection conn = new SqlConnection(strConnectionString);

            try
            {
                conn.Open();
                string sqlString = "select * from Admin where tenDangNhap='" + this.txtUser.Text + "' and matKhau='" + this.txtPass.Text + "' ";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader data = cmd.ExecuteReader();
                /*BSDangNhap blDn = new BSDangNhap();
                bool checkDangNhap = blDn.DocDuLieu(this.txtTenDN.Text, this.txtMK.Text,ref err);*/
                if (data.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    frmMain.bIsLogin = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!");
                }
            }
            catch
            {

            }
        }
    }
}
