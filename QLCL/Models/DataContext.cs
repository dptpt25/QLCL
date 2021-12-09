using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLCL.Models
{
    public class DataContext
    {
        public string ConnectionString { get; set; } // Biến thành viên

        public DataContext(string connectionstring)
        {
            this.ConnectionString = connectionstring;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public int sqlInsertDiemCachLy(DiemCachLyModels cachly)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into diemcachly values(@madiemcl, @tendiemcl,@diachicl)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("madiemcl", cachly.MaDiemCL);
                cmd.Parameters.AddWithValue("tendiemcl", cachly.TenDiemCL);
                cmd.Parameters.AddWithValue("diachicl", cachly.DiachiCL);
                return (cmd.ExecuteNonQuery());
            }
        }
        public List<object> Lietketrieuchung(int soTC)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select TenCongNhan, NamSinh, NuocVe, count(*) as SoTrieuChung " +
                  "from CONGNHAN cn join CN_TC cntc on cn.MaCongNhan = cntc.MaCongNhan " +
                  "group by TenCongNhan, NamSinh, NuocVe " +
                  "having count(*) >= @stc";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("stc", soTC);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            TenCongNhan = reader["TenCongNhan"].ToString(),
                            NamSinh = Convert.ToInt32(reader["NamSinh"]),
                            NuocVe = reader["NuocVe"].ToString(),
                            SoTrieuChung = Convert.ToInt32(reader["SoTrieuChung"]),
                        });
                    }
                    reader.Close();
                }
                return list;
            }

        }
        public List<object> slqSelectDiaDiem()
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * " +
                      "from DIEMCACHLY ";
                SqlCommand cmd = new SqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            MaDiemCL = reader["MaDiemCL"].ToString(),
                            TenDiemCL = reader["TenDiemCL"].ToString(),
                            DiachiCL = reader["DiaChiCL"].ToString(),
                        });
                    }
                    reader.Close();
                }
                return list;
            }
        }


        public List<object> sqlListCNByTenDCL(string MaDiemCL)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * " +
                      "from CONGNHAN " +
                      "where MaDiemCL = @MaDiemCL";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaDiemCL", MaDiemCL);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            MaCongNhan = reader["MaCongNhan"].ToString(),
                            TenCongNhan = reader["TenCongNhan"].ToString(),
                        });
                    }
                    reader.Close();
                }
                return list;
            }
        }

        public List<object> sqlSelectCNByMaCongNhan(string MaCongNhan)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * " +
                      "from CONGNHAN " +
                      "where MaCongNhan = @MaCongNhan";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaCongNhan", MaCongNhan);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            MaCongNhan = reader["MaCongNhan"].ToString(),
                            TenCongNhan = reader["TenCongNhan"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NamSinh = Convert.ToInt32(reader["NamSinh"]),
                            NuocVe = reader["NuocVe"].ToString(),
                        }); ;
                    }
                    reader.Close();
                }
                return list;
            }
        }

        public int sqlDeleteCongNhan(string MaCongNhan)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from CONGNHAN "
                    + "where MaCongNhan = @MaCongNhan";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaCongNhan", MaCongNhan);
                return (cmd.ExecuteNonQuery());
            }
        }
    }
}

