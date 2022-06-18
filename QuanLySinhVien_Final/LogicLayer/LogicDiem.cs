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
    public class LogicDiem
    {
        DBMain db = null;
        private static LogicDiem instance;

        internal static LogicDiem Instance
        {
            get { if (instance == null) instance = new LogicDiem(); return LogicDiem.instance; }
            private set { instance = value; }
        }

        public LogicDiem()
        {
            db = new DBMain();
        }
        public DataTable LayDiem()
        {
            return db.ExcuteQueryDataSet("Select * From Diem where status = 0", CommandType.Text);
        }
        public bool ThemDiem(int maSV, int maMH, int maKhoa, float diemQT, float diemThi, ref string err)
        {
            string sqlString = null;

            sqlString = "Insert Into Diem Values('" +
                                             maSV + "','" +
                                             maMH + "','" +
                                             maKhoa + "','" + diemQT + "','"+diemThi+"')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatDiem(int maSV, int maMH, int maKhoa, float diemQT, float diemThi, ref string err)
        {
            string query = string.Format("Update Diem Set maMH = '{1}', " + " maKhoa='{2}' " + " diemQT='{3}' " + " diemThi='{4}' " +
                "                                           WHERE maSV = {0}", maSV,maMH,maKhoa,diemQT,diemThi);

            return db.MyExecuteNonQuery(query, CommandType.Text, ref err);
        }
        public bool XoaDiem(string maSV, ref string err)
        {
            string query = string.Format("Update Diem Set status = 1"  +
                "                                           WHERE maSV = {0}", maSV);

            return db.MyExecuteNonQuery(query, CommandType.Text, ref err);

        }
        public DataTable SearchSinhVienByGrade(string maSV)
        {
            string sqlString = "Select * From Diem Where maSV Like '%" + maSV + "%'";

            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}
