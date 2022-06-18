using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLySinhVien_Final.DBLayer;
using QuanLySinhVien_Final.ClassQuanLy;

namespace QuanLySinhVien_Final.LogicLayer
{
    public class LogicKhoa
    {
        DBMain db = null;
        private static LogicKhoa instance;

        internal static LogicKhoa Instance
        {
            get { if (instance == null) instance = new LogicKhoa(); return LogicKhoa.instance; }
            private set { instance = value; }
        }

        public LogicKhoa()
        {
            db = new DBMain();
        }

        public DataTable LayKhoa()
        {
            return db.ExcuteQueryDataSet("Select maKhoa,tenKhoa,namBatDau,namKetThuc From Khoa where status = 0", CommandType.Text);
        }

        public bool ThemKhoa(int MaKhoa, string TenKhoa, int namBatDau, int namKetThuc, ref string err)
        {
            string sqlString = null;

            sqlString = "Insert Into Khoa Values('" +
                                             MaKhoa + "',N'" +
                                             TenKhoa + "','" +
                                             namBatDau + "','"+ namKetThuc+"')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatKhoa(int MaKhoa, string TenKhoa, int namBatDau, int namKetThuc, ref string err)
        {
            string query = string.Format("Update Khoa Set tenKhoa = N'{1}', " + " namBatDau='{2}' " + " namKetThuc='{3}' "+
                "                                           WHERE maKhoa = {0}", MaKhoa, TenKhoa, namBatDau,namKetThuc);

            return db.MyExecuteNonQuery(query, CommandType.Text, ref err);
        }
        public bool XoaKhoa(string MaKhoa, ref string err)
        {
            string sqlString = "Update Khoa Set status=N'" +
           "1" + "' Where maKhoa='" + MaKhoa + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }

        
    }
}
