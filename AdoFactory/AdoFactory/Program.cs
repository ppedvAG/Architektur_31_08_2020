using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStringSqlServer = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";
            var conStringOracle = "";

            DbProviderFactory factory = null;

            if (true)  //SQL Server
                factory = System.Data.SqlClient.SqlClientFactory.Instance;
            else //oracle
                factory = Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance;

            //using (var con = factory.CreateConnection())
            using (var con = new SqlConnection())
            {
                con.ConnectionString = conStringSqlServer;

                con.Open();

                using (var cmd = factory.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Employees";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            Console.WriteLine($"{reader.GetString(reader.GetOrdinal("LastName"))}");
                    }
                }
            }// con.Dispose();// -> con.Close();



            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
