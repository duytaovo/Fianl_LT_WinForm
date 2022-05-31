using System;
using System.Data;

namespace QuanLySinhVien_Final.ClassQuanLy
{
    class SinhVien
    {
        private int maSinhVien;
        private string hoTen;
        private string email;
        private string matkhau;
        private string diaChi;
        private string gioiTinh;
        private string dienThoai;
        private int maLop;

        public SinhVien(int maSinhVien, string hoTen, string diaChi, string matkhau, string dienThoai, int maLop, string email, string gioiTinh)
        {
            this.maSinhVien = maSinhVien;
            this.hoTen = hoTen;
            this.email = email;
            this.matkhau= matkhau;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.maLop = maLop;
        }

        public SinhVien(DataRow row)
        {
            this.maSinhVien = (int)row["maSinhVien"];
            this.hoTen = row["hoTen"].ToString();
            this.email = row["email"].ToString();
            this.email = row["matkhau"].ToString();
            this.gioiTinh = row["gioiTinh"].ToString();
            this.diaChi = row["diaChi"].ToString();
            this.dienThoai = row["dienThoai"].ToString();
            this.maLop = (int)row["maLop"];
        }

        public int MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Email { get => email; set => email = value; }
        public string MatKhau { get => matkhau; set => matkhau = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public int MaLop { get => maLop; set => maLop = value; }
    }
}
