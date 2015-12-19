using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Data
    {
        private static string connectionString;
        public Data()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LokalUserDB"].ConnectionString;
        }


        //public static void GetTask(ref string condition, ref string code)
        //{
        //    using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
        //    {
        //        var command = connection.CreateCommand();
        //        command.CommandText = "SELECT * FROM dbo.[Tasks]";
        //        connection.Open();
        //        var read = command.ExecuteReader();
        //        while (read.Read())
        //        {
        //            condition = (string)read["Condition"];
        //            code = (string)read["Code"];
        //        }

        //    }
        //}

        public static void GetTask(ref string condition, ref string code, int idLev, int id, int level)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM dbo.[Table] WHERE id=@id AND idLev=@idLev AND level=@level";
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@idLev", idLev));
                command.Parameters.Add(new SqlParameter("@level", level));
                connection.Open();
                var read = command.ExecuteReader();
                while (read.Read())
                {
                    condition = (string)read["Condition"];
                    code = (string)read["Code"];
                }
            }
        }
    }
}
