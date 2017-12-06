using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DrinkAlcool.Models
{
    public class DataBase
    {
        private static readonly string CONNECTION_STRING = @"Data Source=angularalcool.database.windows.net;Initial Catalog=ProjetAlcool;Integrated Security=False;User ID=adminAlcool;Password=alcool8/12;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(DataBase.CONNECTION_STRING);
        }


    }
}