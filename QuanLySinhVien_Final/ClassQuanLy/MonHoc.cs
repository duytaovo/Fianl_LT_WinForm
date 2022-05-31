using System.Data;

namespace QuanLySinhVien_Final.ClassQuanLy
{
    public class MonHoc
    {
        private int maMonHoc;
        private string tenMonHoc;
        private int soTinChi;
        public MonHoc(int maMonHoc, string tenMonHoc, int soTinChi)
        {
            this.maMonHoc = maMonHoc;
            this.TenMonHoc = tenMonHoc;
            this.SoTinChi = soTinChi;
        }

        public MonHoc(DataRow row)
        {
            this.maMonHoc = (int)row["maMH"];
            this.TenMonHoc = row["tenMH"].ToString();
            this.SoTinChi = (int)row["soTinChi"];
        }
        public int MaMonHoc { get => maMonHoc; set => maMonHoc = value; }
        public string TenMonHoc { get => tenMonHoc; set => tenMonHoc = value; }
        public int SoTinChi { get => soTinChi; set => soTinChi = value; }
    }
}
