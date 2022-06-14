using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien_Final.ClassQuanLy
{
    public class Lop
    {
        private int maLop;
        private int maKhoa;
        private string tenNganh;
        private string tenLop;

        public int MaLop { get => maLop; set => maLop = value; }
        public int MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string TenNganh { get => tenNganh; set => tenNganh = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        
        public Lop(int maLop, int maKhoa, string tenNganh, string tenLop)
        {
            this.maLop = maLop;
            this.maKhoa = maKhoa;
            this.tenNganh = tenNganh;
            this.tenLop = tenLop;
        }
        public Lop(DataRow row)
        {
            this.maLop = (int)row["maLop"];
            this.maKhoa = (int)row["maKhoa"];
            this.tenNganh = row["tenNganh"].ToString();
            this.tenLop = row["tenLop"].ToString();
        }
    }
}
