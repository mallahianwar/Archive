using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;

namespace Archive.Models.Classes
{
    public class Connection
    {
        [Obsolete]
        public static OracleConnection GetConnection()
        {
            return new OracleConnection(Constants.getOraStr());
        }
        public static OracleConnection GetConnection(string dbuser,string dbpwd)
        {
            return new OracleConnection(Constants.getOraStr(dbuser,dbpwd));
        }

    }
}