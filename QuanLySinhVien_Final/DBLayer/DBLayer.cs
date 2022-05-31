using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;


namespace QuanLySinhVien_Final.DBLayer
{
    class DBMain
    {
        private static DBMain instance;
        internal static DBMain Instance
        {
            get { if (instance == null) instance = new DBMain(); return DBMain.instance; }
            private set { instance = value; }
        }

        string strConnectionString = "Data Source = DESKTOP-12J6D6C;" + "Initial Catalog = QLSinhVien;" + "Integrated Security=True";
        //dt ket noi db
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter dataView = null;
        DataTable dataDisplayView = null;

        public DBMain()
        {
            conn = new SqlConnection(strConnectionString);
            comm = conn.CreateCommand();
        }

        public DataTable ExcuteQueryDataSet(string strSQL, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            dataView = new SqlDataAdapter(comm);

            dataDisplayView = new DataTable();

            dataView.Fill(dataDisplayView);
            return dataDisplayView;
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            bool flag = false;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            try
            {
                comm.ExecuteNonQuery();
                flag = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;

        }

        public bool MyExecuteReaderr(string strSQL, ref string error)
        {
            bool flag = false;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            comm.CommandText = strSQL;
            try
            {
                SqlDataReader data = comm.ExecuteReader();
                if (data.Read())
                {
                    flag = true;
                }
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;

        }

        public string TaoMatKhauTuDong(bool useNumbers, bool useSpecial,int passwordSize)
        {
            const string NUMBERS = "123456789";
            const string SPECIALS = @"!@£$%^&*()#€";
            char[] _password = new char[passwordSize];
            string charSet = "";
            System.Random _random = new Random();
            int counter;


            if (useNumbers) charSet += NUMBERS;

            if (useSpecial) charSet += SPECIALS;

            for (counter = 0; counter < passwordSize; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return string.Join(null, _password);

        }
    }
}
