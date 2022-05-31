﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLySinhVien_Final.ClassQuanLy;

using QuanLySinhVien_Final.DBLayer;

namespace QuanLySinhVien_Final.LogicLayer
{
    public class LogicSinhVien
    {
        DBMain db = null;
        private static LogicSinhVien instance;

        internal static LogicSinhVien Instance
        {
            get { if (instance == null) instance = new LogicSinhVien(); return LogicSinhVien.instance; }
            private set { instance = value; }
        }
        public LogicSinhVien()
        {
            db = new DBMain();
        }
        public DataTable LaySinhViens()
        {
            return db.ExcuteQueryDataSet("Select * From SinhVien", CommandType.Text);
        }

        public bool ThemSinhVien(string MaSV,string MaLop,string Email,string MatKhau,string HoTen, string GioiTinh, string SoDT, string DiaChi, ref string err)
        {
            //string query = string.Format("Insert Into MonHoc(maMH,tenMH,soTinChi) VALUES (N'{0}', N'{1}', N'{2}')", MaMonHoc, TenMonHoc, SoTinChi);

            string sqlString = "Insert Into SinhVien Values('" +
                                             MaSV + "',N'" +
                                             MaLop + "',N'" +
                                             Email + "',N'" +
                                             MatKhau+ "',N'" +
                                             HoTen + "',N'" +
                                             GioiTinh + "',N'" +
                                             SoDT + "',N'" +
                                             DiaChi + "',N'" +
                                             "0" + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatSinhVien(string MaSV, string MaLop, string Email, string MatKhau, string HoTen, string GioiTinh, string SoDT, string DiaChi, ref string err)
        {
            string query = string.Format("Update SinhVien Set maLop = N'{1}',email=N'{2}'," + " matKhau=N'{3}' " + " hoTen=N'{4}' "+" gioiTinh=N'{5}' " + " soDT=N'{6}' "+" diaChi=N'{7}' " + "WHERE maSV = {0}", 
                                                                            MaSV, MaLop, Email,MatKhau,HoTen,GioiTinh,SoDT,DiaChi);
            //string sqlString = "Update SinhVien Set maSV=N'" + MaSV + "',maLop=N'" + MaLop + "',email=N'" + Email + "',matKhau=N'" + MatKhau + "',hoTen=N'" + HoTen + "',gioiTinh=N'" + GioiTinh + "',soDT=N'" + SoDT + "',diaChi=N'" + DiaChi + "',status=N'" + "0" + "Where maSV = '" + MaSV + "'";
            string query2 = string.Format("Update SinhVien Set maLop = N'{1}', " + " email=N'{2}' " + " matKhau=N'{3}' " + " hoTen=N'{4}' " + " gioiTinh=N'{5}' " + " soDT=N'{6}' " + " diaChi=N'{7}' " +
                "                                           WHERE maSV = {0}", MaSV, MaLop, Email, MatKhau, HoTen, GioiTinh, SoDT, DiaChi);
            return db.MyExecuteNonQuery(query, CommandType.Text, ref err);
        }

        public bool XoaSinhVien(string MaSV, ref string err)
        {
            //string query = string.Format("Delete From MonHoc Where maMH = {0}", MaMonHoc);
            string sqlString = "Delete From SinhVien Where maSV='" + MaSV + "'";

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }

        public DataTable SearchSinhVienByName(string HoTenc)
        {
            string sqlString = "Select * From SinhVien Where hoTen Like '%" + HoTenc + "%'";
            //string query = string.Format("SELECT * FROM MonHoc WHERE tenMH LIKE N'%' + N'{0}' + '%'", TenMonHoc);

            return db.ExcuteQueryDataSet(sqlString, CommandType.Text);
        }

    }
}