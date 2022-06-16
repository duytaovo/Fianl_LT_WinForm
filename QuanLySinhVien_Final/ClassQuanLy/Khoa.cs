using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien_Final.ClassQuanLy
{
    public class Khoa
    {
        private int maKhoa;
        private string tenKhoa;
        private int namBatDau;
        private int namKetThuc;

        public int MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string TenKhoa { get => tenKhoa; set => tenKhoa = value; }
        public int NamBatDau { get => namBatDau; set => namBatDau = value; }
        public int NamKetThuc { get => namKetThuc; set => namKetThuc = value; }

        public Khoa(int maKhoa, string tenKhoa, int namBatDau, int namKetThuc)
        {
            this.maKhoa = maKhoa;
            this.TenKhoa = tenKhoa;
            this.NamBatDau = namBatDau;
            this.NamKetThuc = namKetThuc;
        }
        public Khoa(DataRow row)
        {
            this.maKhoa = (int)row["maKhoa"];
            this.TenKhoa = row["tenKhoa"].ToString();
            this.NamBatDau = (int)row["namBatDau"];
            this.NamKetThuc = (int)row["namKetThuc"];
        }
    }
}
