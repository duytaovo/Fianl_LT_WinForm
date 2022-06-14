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
            return db.ExcuteQueryDataSet("Select * From Khoa", CommandType.Text);
        }

        public bool ThemKhoa(int MaKhoa, string TenKhoa, int namBatDau, int namKetThuc, ref string err)
        {
            string sqlString = null;
            //string query = string.Format("Insert Into MonHoc(maMH,tenMH,soTinChi) VALUES (N'{0}', N'{1}', N'{2}')", MaMonHoc, TenMonHoc, SoTinChi);

            sqlString = "Insert Into Khoa Values('" +
                                             MaKhoa + "',N'" +
                                             TenKhoa + "','" +
                                             namBatDau + "','"+ namKetThuc+"')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaKhoa(string MaKhoa, ref string err)
        {
            //string query = string.Format("Delete From MonHoc Where maMH = {0}", MaMonHoc);
            string sqlString = "Delete From Khoa Where maKhoa='" + MaKhoa + "'";

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }

        public DataTable SearchMonHocByName(string TenMonHoc)
        {
            string sqlString = "Select * From MonHoc Where tenMH Like '%" + TenMonHoc + "%'";
            //string query = string.Format("SELECT * FROM MonHoc WHERE tenMH LIKE N'%' + N'{0}' + '%'", TenMonHoc);

            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}
