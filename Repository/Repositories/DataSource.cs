﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Repository.Repositories
{
    public class DataSource
    {
        public static string getConnectionString(string name)
        {
            //return System.Web.Configuration.WebConfigurationManager.ConnectionStrings[name].ConnectionString;
            return null;
        }
    }
}
