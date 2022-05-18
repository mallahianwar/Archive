using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Archive.Models.Classes
{
    public class Constants
    {
        public static string dtSys = null;

        public static string DB_SERVER_ORA = null;
        public static string DB_NAME_ORA = null;
        public static string DB_USERNAME_ORA = null;
        public static string DB_PASSWORD_ORA = null;


        public static string conStrOra = null;
        public static string getOraStr()
        {
            return conStrOra = @"Data Source=(DESCRIPTION=" +
                                                 "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + Constants.DB_SERVER_ORA + " )(PORT=1521)))" +
                                                 "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + Constants.DB_NAME_ORA + ")));" +
                                                 "User Id=" + Constants.DB_USERNAME_ORA + " ;Password=" + Constants.DB_PASSWORD_ORA;
        }
        public static string getOraStr(string dbuser, string dbpwd)
        {
            return conStrOra = @"Data Source=(DESCRIPTION=" +
                                                 "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + Constants.DB_SERVER_ORA + " )(PORT=1521)))" +
                                                 "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + Constants.DB_NAME_ORA + ")));" +
                                                 "User Id=" + dbuser + " ;Password=" + dbpwd;
        }
        public class usrInfo
        {
            public int err_no { set; get; }
            public string err_desc { set; get; }
        }

        public enum DataType : byte
        {
            varchar2,
            int32,
            int16,
            refcursor,
            date,
        };
        public enum Direction : byte
        {
            input,
            output,
            inputoutput,
            returnvalue,
        };
        public class Obj
        {
            public string functionName { set; get; }
            public string nameCursor { set; get; }
            public bool hasCursor { set; get; }
            public bool hasReturn { set; get; }
            public bool hasCursorReturn { set; get; }
            public List<ObjTypes> Par_V { set; get; }
            public string retvalue { set; get; }
            public DataTable retcursor { set; get; }
            public class ObjTypes
            {
                public string par_n { set; get; }
                public string dataType { set; get; }
                public string direction { set; get; }
                public int size { set; get; }
                public string value { set; get; }

                public ObjTypes(string _par_n, string _dataType, string _direction, int _size, string _value)
                {
                    this.par_n = _par_n;
                    this.dataType = _dataType;
                    this.direction = _direction;
                    this.size = _size;
                    this.value = _value;
                }
            }

        }

    }

   
}