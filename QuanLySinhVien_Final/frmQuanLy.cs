
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

using QuanLySinhVien_Final.DBLayer;
using QuanLySinhVien_Final.LogicLayer;
using QuanLySinhVien_Final.ClassQuanLy;

namespace QuanLySinhVien_Final
{
    public partial class frmQuanLy : Form
    {
        string err;
        bool Them;
        DataTable dtSinhVien = null;
        LogicSinhVien dbSinhVien = new LogicSinhVien();

        DataTable dtMonHoc = null;
        LogicMonHoc dbMonHoc = new LogicMonHoc();

        DataTable dtKhoa = null;
        LogicKhoa dbKhoa = new LogicKhoa();

        DataTable dtLop = null;
        LogicLop dbLop = new LogicLop();

        DataTable dtDiem = null;
        LogicDiem dbDiem = new LogicDiem();

        public frmQuanLy()
        {
            InitializeComponent();
        }


        #region SinhVien
        private void btnViewSinhViens_Click(object sender, EventArgs e)
        {
            loadSinhViens();
        }
        void loadSinhViens()
        {

            try
            {
                dtSinhVien = new DataTable();
                dtSinhVien.Clear();

                DataTable dataDisplay = dbSinhVien.LaySinhViens();
                dtSinhVien = dataDisplay;
                dtgvSV.DataSource = dtSinhVien;

                this.txtMaSV.ResetText();
                this.txtMaLop.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDienThoai.ResetText();
                this.txtEmail.ResetText();
                this.txtGioiTinh.ResetText();
                this.txtHoTenSV.ResetText();
                this.txtMatKhau.ResetText();

                dtgvSV_CellClick(null, null);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!" + ex);
            }
        }
        private void dtgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvSV.CurrentCell != null)
            {
                int r = dtgvSV.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                this.txtMaSV.Text = dtgvSV.Rows[r].Cells[0].Value.ToString();
                this.txtMaLop.Text = dtgvSV.Rows[r].Cells[1].Value.ToString();
                this.txtEmail.Text = dtgvSV.Rows[r].Cells[2].Value.ToString();
                this.txtMatKhau.Text = dtgvSV.Rows[r].Cells[3].Value.ToString();
                this.txtHoTenSV.Text = dtgvSV.Rows[r].Cells[4].Value.ToString();
                this.txtGioiTinh.Text = dtgvSV.Rows[r].Cells[5].Value.ToString();
                this.txtDienThoai.Text = dtgvSV.Rows[r].Cells[6].Value.ToString();
                this.txtDiaChi.Text = dtgvSV.Rows[r].Cells[7].Value.ToString();
            }
        }
        private void btnTaoMK_Click(object sender, EventArgs e)
        {
           string mk = DBMain.Instance.TaoMatKhauTuDong(true, true, 8);
            this.txtMatKhau.Text = mk; 
        }
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            Them = true;

            this.txtMaSV.Enabled = true;
            this.txtMaLop.Enabled = true;
            this.txtDiaChi.Enabled = true;
            this.txtDienThoai.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtGioiTinh.Enabled = true;
            this.txtMatKhau.Enabled = true;
            this.txtHoTenSV.Enabled = true;

            this.txtMaSV.ResetText();
            this.txtMaLop.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            this.txtEmail.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtHoTenSV.ResetText();
            this.txtMatKhau.ResetText();

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            btnThemSV.Enabled = false;
            btnSuaSV.Enabled = false;
            btnXoaSV.Enabled = false;

            txtMaSV.Focus();
        }

        private void btnLuu_SV_Click(object sender, EventArgs e)
        {
            if (!txtMaSV.Text.Trim().Equals(""))
            {
                if (Them)
                {
                    try
                    {
                        LogicSinhVien addSV = new LogicSinhVien();
                        addSV.ThemSinhVien(this.txtMaSV.Text, this.txtMaLop.Text, this.txtEmail.Text, this.txtMatKhau.Text, this.txtHoTenSinhVien.Text, this.txtGioiTinh.Text, this.txtDienThoai.Text, this.txtDiaChi.Text, ref err);
                        loadSinhViens();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    catch
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");

                    }
                }
                else
                {
                    try
                    {
                        LogicSinhVien capNhatSV = new LogicSinhVien();
                        capNhatSV.CapNhatSinhVien(this.txtMaSV.Text, this.txtMaLop.Text, this.txtEmail.Text, this.txtMatKhau.Text, this.txtHoTenSinhVien.Text, this.txtGioiTinh.Text, this.txtDienThoai.Text, this.txtDiaChi.Text, ref err);
                        loadSinhViens();
                        MessageBox.Show("Cập nhật sinh vien thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi khi cập nhật môn học");


                    }
                }
            }
            else
            {
                MessageBox.Show("Thành phố chưa có. Lỗi rồi!");
                txtMaSV.Focus();
            }
        }


        private void btnSuaSV_Click(object sender, EventArgs e)
        {
            if (this.txtMaSV.Text.Trim().Equals("") && this.txtEmail.Text.Trim().Equals("") && this.txtDiaChi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập thông tin ");
                txtMaSV.Focus();
            }
            else
            {
                try
                {
                    LogicSinhVien capNhatSV = new LogicSinhVien();
                    capNhatSV.CapNhatSinhVien(this.txtMaSV.Text, this.txtMaLop.Text, this.txtEmail.Text, this.txtMatKhau.Text, this.txtHoTenSinhVien.Text, this.txtGioiTinh.Text, this.txtDienThoai.Text, this.txtDiaChi.Text, ref err);
                    loadSinhViens();
                    MessageBox.Show("Cập nhật sinh vien thành công!");
                }
                catch
                {
                    MessageBox.Show("Có lỗi khi cập nhật môn học");


                }
            }
        }

        private void btnHuy_SV_Click(object sender, EventArgs e)
        {
            this.txtMaSV.ResetText();
            this.txtMaLop.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            this.txtEmail.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtHoTenSV.ResetText();
            this.txtMatKhau.ResetText();

            btnThemSV.Enabled = true;
            btnSuaSV.Enabled = true;
            btnXoaSV.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (traloi == DialogResult.OK)
            {
                try
                {
                    int r = dtgvSV.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strThanhPho =
                    dtgvSV.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    LogicSinhVien xoaSV = new LogicSinhVien();
                    xoaSV.XoaSinhVien(this.txtMaSV.Text, ref err);
                    // Thông báo
                    loadSinhViens();
                    MessageBox.Show("Đã xóa xong!");

                }
                catch
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
            }
        }

        private void txtTimKiemSV_TextChanged(object sender, EventArgs e)
        {
            LogicSinhVien searchSV = new LogicSinhVien();
            dtgvSV.DataSource = searchSV.SearchSinhVienByName(txtSearchSV.Text); ;
        }
        private void tpSinhVien_Click(object sender, EventArgs e)
        {

        }
        #endregion SinhVien




        #region MonHoc
        private void btnViewMonHoc_Click(object sender, EventArgs e)
        {
            loadMonHocs();
        }

        void loadMonHocs()
        {
            // monHocList.DataSource = LogicMonHoc.Instance.getMonHocs();

            try
            {
                dtMonHoc = new DataTable();
                dtMonHoc.Clear();

                DataTable dataDisplay = dbMonHoc.LayMonHocs();
                dtMonHoc = dataDisplay;
                dtgvMonHoc.DataSource = dtMonHoc;

                this.txtMaMonHoc.ResetText();
                this.txtTenMonHoc.ResetText();
                this.txtSoTinChiMonHoc.ResetText();

                dtgvMonHoc_CellClick(null, null);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table THANHPHO. Lỗi rồi!!!" + ex);
            }
        }

     

        /*private void loadMonHocBinding()
        {
            txtMaMonHoc.DataBindings.Add(new Binding("Text", dtgvMonHoc.DataSource, "maMonHoc", true, DataSourceUpdateMode.Never));
            txtTenMonHoc.DataBindings.Add(new Binding("Text", dtgvMonHoc.DataSource, "tenMonHoc", true, DataSourceUpdateMode.Never));
            txtSoTinChiMonHoc.DataBindings.Add(new Binding("Text", dtgvMonHoc.DataSource, "soTinChi", true, DataSourceUpdateMode.Never));
        }*/
        private void btnAddMonHoc_Click(object sender, EventArgs e)
        {
            Them = true;

            txtMaMonHoc.Enabled = true;
            txtTenMonHoc.Enabled = true;
            txtSoTinChiMonHoc.Enabled = true;

            txtMaMonHoc.ResetText();
            txtTenMonHoc.ResetText();
            txtSoTinChiMonHoc.ResetText();

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            btnAddMonHoc.Enabled = false;
            btnEditMonHoc.Enabled = false;
            btnDeleteMonHoc.Enabled = false;

            txtMaMonHoc.Focus();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!txtMaMonHoc.Text.Trim().Equals(""))
            {
                if (Them)
                {
                    try
                    {
                        int soTinChi = Convert.ToInt32(txtSoTinChiMonHoc.Text);
                        LogicMonHoc addMonHoc = new LogicMonHoc();
                        addMonHoc.ThemMonHoc(this.txtMaMonHoc.Text, this.txtTenMonHoc.Text, soTinChi, ref err);
                        loadMonHocs();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    catch
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");

                    }
                }
                else
                {
                    try
                    {
                        int soTinChi = Convert.ToInt32(txtSoTinChiMonHoc.Text);
                        LogicMonHoc capNhatMonHoc = new LogicMonHoc();
                        capNhatMonHoc.CapNhatMonHoc(this.txtMaMonHoc.Text, this.txtTenMonHoc.Text, soTinChi, ref err);
                        loadMonHocs();
                        MessageBox.Show("Cập nhật môn học thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi khi cập nhật môn học");


                    }
                }
            }
            else
            {
                MessageBox.Show("Thông tin chưa có. Lỗi rồi!");
                txtMaMonHoc.Focus();
            }
        }
        private void dtgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (dtgvMonHoc.CurrentCell != null)
            {
                int r = dtgvMonHoc.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                this.txtMaMonHoc.Text = dtgvMonHoc.Rows[r].Cells[0].Value.ToString();
                this.txtTenMonHoc.Text =
                dtgvMonHoc.Rows[r].Cells[1].Value.ToString();
                this.txtSoTinChiMonHoc.Text =
               dtgvMonHoc.Rows[r].Cells[2].Value.ToString();
            }
        }
        private void btnEditMonHoc_Click(object sender, EventArgs e)
        {
            Them = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnAddMonHoc.Enabled = false;
            btnEditMonHoc.Enabled = false;
            btnDeleteMonHoc.Enabled = false;

            txtMaMonHoc.Enabled = false;
            txtMaMonHoc.Focus();

        }
        private void btnDeleteMonHoc_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (traloi == DialogResult.OK)
            {
                try
                {
                    int r = dtgvMonHoc.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strThanhPho =
                    dtgvMonHoc.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    LogicMonHoc xoaMonHoc = new LogicMonHoc();
                    xoaMonHoc.XoaMonHoc(this.txtMaMonHoc.Text, ref err);
                    // Thông báo
                    loadMonHocs();
                    MessageBox.Show("Đã xóa xong!");

                }
                catch
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtMaMonHoc.ResetText();
            this.txtTenMonHoc.ResetText();
            this.txtSoTinChiMonHoc.ResetText();

            btnAddMonHoc.Enabled = true;
            btnEditMonHoc.Enabled = true;
            btnDeleteMonHoc.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void txtSearchMonHoc_TextChanged(object sender, EventArgs e)
        {
            LogicMonHoc searchMonHoc= new LogicMonHoc();
            dtgvMonHoc.DataSource = searchMonHoc.SearchMonHocByName(txtSearchMonHoc.Text); ;
        }
        private void btnSearchMonHoc_Click(object sender, EventArgs e)
        {
            
        }

        #endregion MonHoc

        private void btnXem_Click(object sender, EventArgs e)
        {

        }
        #region Khoa
        private void btnViewKhoa_Click(object sender, EventArgs e)
        {
            loadKhoa();
        }
        void loadKhoa()
        {

            try
            {
                dtKhoa = new DataTable();
                dtKhoa.Clear();

                DataTable dataDisplay = dbKhoa.LayKhoa();
                dtKhoa = dataDisplay;
                dtgvKhoa.DataSource = dtKhoa;

                this.txtIDKhoa.ResetText();
                this.txtTenKhoa.ResetText();
                this.textBox20.ResetText();
                this.textBox21.ResetText();

                dtgvKhoa_CellClick(null, null);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table THANHPHO. Lỗi rồi!!!" + ex);
            }
        }
        private void dtgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvKhoa.CurrentCell != null)
            {
                int r = dtgvKhoa.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                this.txtIDKhoa.Text = dtgvKhoa.Rows[r].Cells[0].Value.ToString();
                this.txtTenKhoa.Text =
                dtgvKhoa.Rows[r].Cells[1].Value.ToString();
                this.textBox20.Text =
               dtgvKhoa.Rows[r].Cells[2].Value.ToString();
                this.textBox21.Text =
               dtgvKhoa.Rows[r].Cells[3].Value.ToString();

            }
        }

        private void btnAddKhoa_Click(object sender, EventArgs e)
        {
            Them = true;

            txtIDKhoa.Enabled = true;
            txtTenKhoa.Enabled = true;
            textBox20.Enabled = true;
            textBox21.Enabled = true;

            this.txtIDKhoa.ResetText();
            this.txtTenKhoa.ResetText();
            this.textBox20.ResetText();
            this.textBox21.ResetText();

            btnHuy_Khoa.Enabled = true;
            btnLuu_Khoa.Enabled = true;

            btnAddKhoa.Enabled = false;
            btnEditKhoa.Enabled = false;
            BtnDeleteKhoa.Enabled = false;

            txtIDKhoa.Focus();
        }
        private void btnEditKhoa_Click(object sender, EventArgs e)
        {
            Them = false;

            btnLuu_Khoa.Enabled = true;
            btnHuy_Khoa.Enabled = true;
            btnAddKhoa.Enabled = false;
            btnEditKhoa.Enabled = false;
            BtnDeleteKhoa.Enabled = false;

            txtIDKhoa.Enabled = false;
            txtIDKhoa.Focus();
        }

        private void BtnDeleteKhoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (traloi == DialogResult.OK)
            {
                try
                {
                    int r = dtgvKhoa.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strThanhPho =
                    dtgvKhoa.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    LogicKhoa xoaKhoa = new LogicKhoa();
                    xoaKhoa.XoaKhoa(this.txtIDKhoa.Text, ref err);
                    // Thông báo
                    loadKhoa();
                    MessageBox.Show("Đã xóa xong!");

                }
                catch
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
            }
        }

        private void btnLuu_Khoa_Click(object sender, EventArgs e)
        {
            if (!txtIDKhoa.Text.Trim().Equals(""))
            {
                if (Them)
                {
                    try
                    {
                        int maKhoa = Convert.ToInt32(txtIDKhoa.Text);
                        int namBatDau = Convert.ToInt32(textBox20.Text);
                        int namKetThuc = Convert.ToInt32(textBox21.Text);
                        LogicKhoa addKhoa = new LogicKhoa();
                        addKhoa.ThemKhoa(maKhoa, this.txtTenKhoa.Text, namBatDau,namKetThuc, ref err);
                        loadKhoa();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    catch
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");

                    }
                }
                else
                {
                    try
                    {
                        int maKhoa = Convert.ToInt32(txtIDKhoa.Text);
                        int namBatDau = Convert.ToInt32(textBox20.Text);
                        int namKetThuc = Convert.ToInt32(textBox21.Text);
                        LogicKhoa capNhatKhoa = new LogicKhoa();
                        capNhatKhoa.CapNhatKhoa(maKhoa, this.txtTenKhoa.Text, namBatDau, namKetThuc, ref err);
                        loadKhoa();
                        MessageBox.Show("Cập nhật môn học thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi khi cập nhật môn học");


                    }
                }
            }
            else
            {
                MessageBox.Show("Thông tin chưa có. Lỗi rồi!");
                txtIDKhoa.Focus();
            }
        }

        private void btnHuy_Khoa_Click(object sender, EventArgs e)
        {
            this.txtIDKhoa.ResetText();
            this.txtTenKhoa.ResetText();
            this.textBox20.ResetText();
            this.textBox21.ResetText();

            btnAddKhoa.Enabled = true;
            btnEditKhoa.Enabled = true;
            BtnDeleteKhoa.Enabled = true;

            btnLuu_Khoa.Enabled = true;
            btnHuy_Khoa.Enabled = true;
        }


        #endregion

        #region Lop
        private void btnViewLop_Click(object sender, EventArgs e)
        {
            loadLop();
        }
        void loadLop()
        {
            // monHocList.DataSource = LogicMonHoc.Instance.getMonHocs();

            try
            {
                dtLop = new DataTable();
                dtLop.Clear();

                DataTable dataDisplay = dbLop.LayLop();
                dtLop = dataDisplay;
                dtgvLop.DataSource = dtLop;

                this.txtMa_Lop.ResetText();
                this.txtMaKhoa.ResetText();
                this.txtTenNganh.ResetText();
                this.txtTenLop.ResetText();

                dtgvLop_CellClick(null, null);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table THANHPHO. Lỗi rồi!!!" + ex);
            }
        }

        private void btnAddLop_Click(object sender, EventArgs e)
        {
            Them = true;

            txtMa_Lop.Enabled = true;
            txtMaKhoa.Enabled = true;
            txtTenNganh.Enabled = true;
            txtTenLop.Enabled = true;

            this.txtMa_Lop.ResetText();
            this.txtMaKhoa.ResetText();
            this.txtTenNganh.ResetText();
            this.txtTenLop.ResetText();

            btnHuy_Lop.Enabled = true;
            btnLuu_Lop.Enabled = true;

            btnAddLop.Enabled = false;
            btnEditLop.Enabled = false;
            btnDeleteLop.Enabled = false;

            txtMa_Lop.Focus();
        }

        private void btnEditLop_Click(object sender, EventArgs e)
        {
            Them = false;

            btnLuu_Lop.Enabled = true;
            btnHuy_Lop.Enabled = true;
            btnAddLop.Enabled = false;
            btnEditLop.Enabled = false;
            btnDeleteLop.Enabled = false;

            txtMa_Lop.Enabled = false;
            txtMa_Lop.Focus();
        }

        private void btnDeleteLop_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (traloi == DialogResult.OK)
            {
                try
                {
                    int r = dtgvLop.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strThanhPho =
                    dtgvLop.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    LogicLop xoaLop = new LogicLop();
                    xoaLop.XoaLop(this.txtMa_Lop.Text, ref err);
                    // Thông báo
                    loadLop();
                    MessageBox.Show("Đã xóa xong!");

                }
                catch
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
            }
        }

        private void btnLuu_Lop_Click(object sender, EventArgs e)
        {
            if (!txtMa_Lop.Text.Trim().Equals(""))
            {
                if (Them)
                {
                    try
                    {
                        int id = Convert.ToInt32(txtMa_Lop.Text);
                        int maKhoa = Convert.ToInt32(txtMaKhoa.Text);
                        LogicLop addLop = new LogicLop();
                        addLop.ThemLop(id,maKhoa, txtTenNganh.Text,txtTenLop.Text, ref err);
                        loadLop();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    catch
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");

                    }
                }
                else
                {
                    try
                    {
                        int id = Convert.ToInt32(txtMa_Lop.Text);
                        int maKhoa = Convert.ToInt32(txtMaKhoa.Text);
                        LogicLop capNhatLop = new LogicLop();
                        capNhatLop.CapNhatLop(id, maKhoa, txtTenNganh.Text, txtTenLop.Text, ref err);
                        loadLop();
                        MessageBox.Show("Cập nhật môn học thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi khi cập nhật môn học");
                    }
                }
            }
            else
            {
                MessageBox.Show("Thông tin chưa có. Lỗi rồi!");
                txtMa_Lop.Focus();
            }
        }

        private void btnHuy_Lop_Click(object sender, EventArgs e)
        {
            this.txtMa_Lop.ResetText();
            this.txtMaKhoa.ResetText();
            this.txtTenNganh.ResetText();
            this.txtTenLop.ResetText();

            btnAddLop.Enabled = true;
            btnEditLop.Enabled = true;
            btnDeleteLop.Enabled = true;

            btnLuu_Lop.Enabled = true;
            btnHuy_Lop.Enabled = true;
        }
        private void dtgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvLop.CurrentCell != null)
            {
                int r = dtgvLop.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                this.txtMa_Lop.Text = dtgvLop.Rows[r].Cells[0].Value.ToString();
                this.txtMaKhoa.Text = dtgvLop.Rows[r].Cells[1].Value.ToString();
                this.txtTenNganh.Text = dtgvLop.Rows[r].Cells[2].Value.ToString();
                this.txtTenLop.Text = dtgvLop.Rows[r].Cells[3].Value.ToString();

            }
        }
        #endregion
        #region Diem
        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            loadDiem();
        }
        void loadDiem()
        {

            try
            {
                dtDiem = new DataTable();
                dtDiem.Clear();

                DataTable dataDisplay = dbDiem.LayDiem();
                dtDiem = dataDisplay;
                dtgvDiem.DataSource = dtDiem;

                this.txtMSSV.ResetText();
                this.txtMaMH.ResetText();
                this.txtKhoa.ResetText();
                this.txtDiemQT.ResetText();
                this.txtDiemThi.ResetText();
                

                dtgvDiem_CellClick(null, null);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table. Lỗi rồi!!!" + ex);
            }
        }
        private void dtgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDiem.CurrentCell != null)
            {
                int r = dtgvDiem.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                this.txtMaMH.Text = dtgvDiem.Rows[r].Cells[0].Value.ToString();
                this.txtMSSV.Text =
                dtgvDiem.Rows[r].Cells[1].Value.ToString();
                this.txtKhoa.Text =dtgvDiem.Rows[r].Cells[2].Value.ToString();
                this.txtDiemQT.Text =
               dtgvDiem.Rows[r].Cells[3].Value.ToString();
                this.txtDiemThi.Text =
               dtgvDiem.Rows[r].Cells[4].Value.ToString();

            }
        }
        private void btnThemDiem_Click(object sender, EventArgs e)
        {
            Them = true;

            this.txtMSSV.Enabled = true;
            this.txtMaMH.Enabled = true;
            this.txtKhoa.Enabled = true;
            this.txtDiemQT.Enabled = true;
            this.txtDiemThi.Enabled = true;

            this.txtMSSV.ResetText();
            this.txtMaMH.ResetText();
            this.txtKhoa.ResetText();
            this.txtDiemQT.ResetText();
            this.txtDiemThi.ResetText();

            btnHuy_Diem.Enabled = true;
            btnLuu_Diem.Enabled = true;

            btnThemDiem.Enabled = false;
            btnSuaDiem.Enabled = false;
            btnXoaDiem.Enabled = false;

            txtMSSV.Focus();
        }

        private void btnSuaDiem_Click(object sender, EventArgs e)
        {
            Them = false;

            btnLuu_Diem.Enabled = true;
            btnHuy_Diem.Enabled = true;
            btnThemDiem.Enabled = false;
            btnSuaDiem.Enabled = false;
            btnXoaDiem.Enabled = false;

            txtMSSV.Enabled = false;
            txtMSSV.Focus();
        }

        private void btnXoaDiem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (traloi == DialogResult.OK)
            {
                try
                {
                    int r = dtgvDiem.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strThanhPho =
                    dtgvDiem.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    LogicDiem xoaDiem = new LogicDiem();
                    xoaDiem.XoaDiem(this.txtMSSV.Text, ref err);
                    // Thông báo
                    loadDiem();
                    MessageBox.Show("Đã xóa xong!");

                }
                catch
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                }
            }
        }

        private void btnLuu_Diem_Click(object sender, EventArgs e)
        {
            if (!txtMSSV.Text.Trim().Equals(""))
            {
                if (Them)
                {
                    try
                    {
                        int MSSV = Convert.ToInt32(txtMSSV.Text);
                        int diemQT = Convert.ToInt32(txtDiemQT.Text);
                        int diemThi = Convert.ToInt32(txtDiemThi.Text);

                        LogicDiem addDiem = new LogicDiem();
                        //addDiem.ThemDiem(MSSV, ..., diemQT,diemThi, ref err);
                        loadDiem();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    catch
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");

                    }
                }
                else
                {
                    try
                    {
                        int MSSV = Convert.ToInt32(txtMSSV.Text);
                        int diemQT = Convert.ToInt32(txtDiemQT.Text);
                        int diemThi = Convert.ToInt32(txtDiemThi.Text);
                        LogicDiem capNhatDiem = new LogicDiem();
                        //capNhatDiem.CapNhatDiem(MSSV, ..., diemQT, diemThi, ref err);
                        loadDiem();
                        MessageBox.Show("Cập nhật môn học thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi khi cập nhật môn học");
                    }
                }
            }
            else
            {
                MessageBox.Show("Thông tin chưa có. Lỗi rồi!");
                txtMa_Lop.Focus();
            }
        }

        private void btnHuy_Diem_Click(object sender, EventArgs e)
        {
            this.txtMSSV.ResetText();
            this.txtMaMH.ResetText();
            this.txtKhoa.ResetText();
            this.txtDiemQT.ResetText();
            this.txtDiemThi.ResetText();

            btnThemDiem.Enabled = true;
            btnSuaDiem.Enabled = true;
            btnXoaDiem.Enabled = true;

            btnLuu_Diem.Enabled = true;
            btnHuy_Diem.Enabled = true;
        }

        private void btnTimDiem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        private void tcAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
