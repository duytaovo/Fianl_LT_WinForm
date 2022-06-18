using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien_Final.ClassQuanLy
{
    public class Diem
    {
        private int maSV;
        private int maMH;
        private int maKhoa;
        private float diemQT;
        private float diemThi;

        public int MaSV { get => maSV; set => maSV = value; }
        public int MaMH { get => maMH; set => maMH = value; }
        public int MaKhoa { get => maKhoa; set => maKhoa = value; }
        public float DiemQT { get => diemQT; set => diemQT = value; }
        public float DiemThi { get => diemThi; set => diemThi = value; }
        public Diem(int maSV, int maMH, int maKhoa, float diemQT, float diemThi)
        {
            this.maSV = maSV;
            this.MaMH = maMH;
            this.MaKhoa = maKhoa;
            this.diemQT = diemQT;
            this.diemThi = diemThi;
        }
        public Diem(DataRow row)
        {
            this.maSV = (int)row["maSV"];
            this.maMH = (int)row["maMH"];
            this.maKhoa = (int)row["maKhoa"];
            this.diemQT = (float)row["diemQT"];
            this.diemThi = (float)row["diemThi"];

        }
    }
}
