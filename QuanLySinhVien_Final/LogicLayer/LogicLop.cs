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
    public class LogicLop
    {
        DBMain db = null;
        private static LogicLop instance;

        internal static LogicLop Instance
        {
            get { if (instance == null) instance = new LogicLop(); return LogicLop.instance; }
            private set { instance = value; }
        }

        public LogicLop()
        {
            db = new DBMain();
        }
        public DataTable LayLop()
        {
            return db.ExcuteQueryDataSet("Select * From Lop", CommandType.Text);
        }

        public bool ThemLop(int MaLop, int maNganh, string tenNganh, string tenLop, ref string err)
        {
            string sqlString = null;

            sqlString = "Insert Into Lop Values('" +
                                             MaLop + "','" +
                                             maNganh + "',N'" +
                                             tenNganh + "',N'" + tenLop + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatLop(int MaLop, int maNganh, string tenNganh, string tenLop, ref string err)
        {
            string query = string.Format("Update Lop Set maNganh = '{1}', " + " tenNganh=N'{2}' " + " tenLop=N'{3}' " +
                "                                           WHERE maLop = {0}", MaLop, maNganh, tenNganh, tenLop);

            return db.MyExecuteNonQuery(query, CommandType.Text, ref err);
        }
        public bool XoaLop(string MaLop, ref string err)
        {
            string sqlString = "Delete From Lop Where maLop='" + MaLop + "'";

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }
    }
}
