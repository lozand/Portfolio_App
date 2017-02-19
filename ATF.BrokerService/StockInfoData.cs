using StockInfoService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockInfoService
{
    public class StockInfoData
    {
        public StockInfoData()
        {
            connectionString = ConfigurationManager.AppSettings["StockRepositoryConnectionString"];
        }

        string connectionString;

        public List<StockInfo> SearchForStock(string query)
        {
            List<StockInfo> infos = new List<StockInfo>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_SearchForStock", conn);
                using (var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        StockInfo info = new StockInfo();
                        info.StockName = reader["StockSymbol"].ToString();
                        infos.Add(info);
                    }
                }
            }
            return infos;
        }

        public void SaveStock(string stockSymbol, string companyName, string description)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_SaveStock", conn);
                command.Parameters.AddWithValue("@StockSymbol", stockSymbol);
                command.Parameters.AddWithValue("@Companyname", companyName);
                command.Parameters.AddWithValue("@Description", description);
                command.ExecuteNonQuery();
            }
        }
    }
}