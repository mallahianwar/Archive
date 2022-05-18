using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace Archive.Models.Classes
{
    public class MainModel : Connection
    {
        private DataTable dt = null;
        //private OracleTransaction transOra = null;

        [Obsolete]
        public DataTable DropListFn(string namefunc, string _where)
        {
            OracleConnection conn = GetConnection();
            try
            {
                OracleParameter op = null;
                OracleDataReader d = null;
                DataTable dt = new DataTable();

                conn.Open();
                OracleCommand cmd = conn.CreateCommand();

                cmd.CommandText = "EGS_PKG.GET_DROP_LIST_FN";
                cmd.CommandType = CommandType.StoredProcedure;


                op = new OracleParameter("returnVal", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.ReturnValue;
                op.Size = 32767;
                cmd.Parameters.Add(op);

                op = new OracleParameter("DROPLIST_NAME_IN", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.Input;
                op.Value = namefunc;
                cmd.Parameters.Add(op);

                op = new OracleParameter("WHERE_STATMENT_IN", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.Input;
                op.Value = _where;
                cmd.Parameters.Add(op);

                op = new OracleParameter("INFO_REF_OUT", OracleDbType.RefCursor);
                op.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(op);

                cmd.BindByName = true;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();

                string str = cmd.Parameters["returnVal"].Value.ToString();

                if (!str.Equals(""))
                {
                    Oracle.DataAccess.Types.OracleRefCursor t = (Oracle.DataAccess.Types.OracleRefCursor)cmd.Parameters["info_ref_out"].Value;
                    d = t.GetDataReader();
                    dt.Load(d);
                    /*
                    dt.Columns.Add("drop_value", typeof(string));
                    dt.Columns.Add("drop_text", typeof(string));

                    while (d.Read())
                    {
                        dt.Rows.Add(d["drop_value"].ToString(), d["drop_text"].ToString());
                    }*/
                }



                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }

        [Obsolete]
        public DataTable GetCursorFn(string namecursor, string _cols, string _where, string _group, string _order)
        {
            OracleConnection conn = GetConnection();
            try
            {
                OracleParameter op = null;
                OracleDataReader d = null;
                DataTable dt = new DataTable();

                conn.Open();
                OracleCommand cmd = conn.CreateCommand();

                cmd.CommandText = "EGS_PKG.GET_REFCURSOR_QU_FN";
                cmd.CommandType = CommandType.StoredProcedure;


                op = new OracleParameter("returnVal", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.ReturnValue;
                op.Size = 32767;
                cmd.Parameters.Add(op);

                op = new OracleParameter("CURSOR_NAME_IN", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.Input;
                op.Value = namecursor;
                cmd.Parameters.Add(op);

                op = new OracleParameter("COLS_IN", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.Input;
                op.Value = _cols;
                cmd.Parameters.Add(op);

                op = new OracleParameter("WHERE_STATMENT_IN", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.Input;
                op.Value = _where;
                cmd.Parameters.Add(op);

                op = new OracleParameter("GROUP_IN", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.Input;
                op.Value = _group;
                cmd.Parameters.Add(op);

                op = new OracleParameter("ORDER_IN", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.Input;
                op.Value = _order;
                cmd.Parameters.Add(op);

                op = new OracleParameter("INFO_REF_OUT", OracleDbType.RefCursor);
                op.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(op);

                cmd.BindByName = true;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();


                string str = cmd.Parameters["returnVal"].Value.ToString();

                if (!str.Equals(""))
                {
                    Oracle.DataAccess.Types.OracleRefCursor t = (Oracle.DataAccess.Types.OracleRefCursor)cmd.Parameters["info_ref_out"].Value;
                    d = t.GetDataReader();
                    dt.Load(d);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable GetCursorFn(string namecursor, string _where)
        {
            OracleConnection conn = GetConnection();
            try
            {
                OracleParameter op = null;
                OracleDataReader d = null;
                DataTable dt = new DataTable();

                conn.Open();
                OracleCommand cmd = conn.CreateCommand();

                cmd.CommandText = "EGS_PKG.GET_REFCURSOR_FN";
                cmd.CommandType = CommandType.StoredProcedure;


                op = new OracleParameter("returnVal", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.ReturnValue;
                op.Size = 32767;
                cmd.Parameters.Add(op);

                op = new OracleParameter("CURSOR_NAME_IN", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.Input;
                op.Value = namecursor;
                cmd.Parameters.Add(op);

                op = new OracleParameter("WHERE_STATMENT_IN", OracleDbType.Varchar2);
                op.Direction = ParameterDirection.Input;
                op.Value = _where;
                cmd.Parameters.Add(op);

                op = new OracleParameter("INFO_REF_OUT", OracleDbType.RefCursor);
                op.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(op);

                cmd.BindByName = true;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();


                string str = cmd.Parameters["returnVal"].Value.ToString();

                if (!str.Equals(""))
                {
                    Oracle.DataAccess.Types.OracleRefCursor t = (Oracle.DataAccess.Types.OracleRefCursor)cmd.Parameters["info_ref_out"].Value;
                    d = t.GetDataReader();
                    dt.Load(d);
                    /*
                    dt.Columns.Add("drop_value", typeof(string));
                    dt.Columns.Add("drop_text", typeof(string));

                    while (d.Read())
                    {
                        dt.Rows.Add(d["drop_value"].ToString(), d["drop_text"].ToString());
                    }*/
                }



                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }

        [Obsolete]
        public int JobFn(Constants.Obj p)
        {
            OracleConnection conn = GetConnection();
            try
            {
                OracleParameter op = null;

                conn.Open();
                OracleCommand cmd = conn.CreateCommand();

                cmd.CommandText = p.functionName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (p.Par_V.Count > 0)
                {
                    this.getParV(p.Par_V, cmd, op);
                }
                cmd.BindByName = true;
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();

                this.getOutputFn(p, cmd);

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        private OracleCommand getParV(List<Constants.Obj.ObjTypes> p, OracleCommand cmd, OracleParameter op)
        {
            foreach (var a in p)
            {
                op = new OracleParameter(a.par_n, this.getDataType(a.dataType));
                op.Direction = this.getDirection(a.direction);
                if (!a.value.Equals(""))
                    op.Value = a.value;
                if (a.size > 0)
                    op.Size = a.size;

                cmd.Parameters.Add(op);
            }
            return cmd;
        }
        private void getOutputFn(Constants.Obj p, OracleCommand cmd)
        {
            List<Constants.Obj.ObjTypes> Par_V = new List<Constants.Obj.ObjTypes>();
            DataTable dtable = new DataTable();
            if (p.hasReturn && !p.hasCursorReturn)
                p.retvalue = cmd.Parameters["returnVal"].Value.ToString();

            if (p.Par_V.Count > 0)
            {
                int i = 0;
                Par_V = p.Par_V;
                foreach (var a in Par_V.ToList())
                {
                    if ((a.direction.Equals(Constants.Direction.output.ToString())
                        || a.direction.Equals(Constants.Direction.inputoutput.ToString()))
                        && (!a.dataType.Equals(Constants.DataType.refcursor.ToString())))
                    {
                        p.Par_V[i].value = cmd.Parameters[a.par_n].Value.ToString();
                    }
                    i++;
                }
            }

            if (p.hasCursor)
            {
                Oracle.DataAccess.Types.OracleRefCursor t = (Oracle.DataAccess.Types.OracleRefCursor)cmd.Parameters[p.nameCursor].Value;
                OracleDataReader rd = t.GetDataReader();
                dtable.Load(rd);
                p.retcursor = dtable;
            }
        }
        private OracleDbType getDataType(string datatype)
        {
            switch (datatype)
            {
                case "varchar2":
                    return OracleDbType.Varchar2;
                case "int32":
                    return OracleDbType.Int32;
                case "int16":
                    return OracleDbType.Int16;

                case "date":
                    return OracleDbType.Date;
                case "refcursor":
                    return OracleDbType.RefCursor;
            }
            return OracleDbType.Varchar2;
        }
        private ParameterDirection getDirection(string direction)
        {
            switch (direction)
            {
                case "input":
                    return ParameterDirection.Input;
                case "output":
                    return ParameterDirection.Output;
                case "inputoutput":
                    return ParameterDirection.InputOutput;
                case "returnvalue":
                    return ParameterDirection.ReturnValue;
            }
            return ParameterDirection.ReturnValue;
        }

    }
}