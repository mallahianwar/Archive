using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Resources;
using System.Windows;

namespace Archive.Models.Classes
{
    public class MainFunctions : MainModel
    {
        public IEnumerable<SelectListItem> fillDropList(string namefunc, string _where)
        {
            DataTable dtable = new DataTable();
            //dtable = dt.DropListFn(namefunc, _where);

            ///////////////for example///////////////
            dtable.Columns.Add("Value");
            dtable.Columns.Add("Text");
            DataRow _ravi = dtable.NewRow();
            _ravi["Value"] = "500";
            _ravi["Text"] = "ravi";
            dtable.Rows.Add(_ravi);

            DataRow _ravi2 = dtable.NewRow();
            _ravi2["Value"] = "300";
            _ravi2["Text"] = "ravi2";
            dtable.Rows.Add(_ravi2);

            DataRow _ravi3 = dtable.NewRow();
            _ravi3["Value"] = "600";
            _ravi3["Text"] = "ravi3";
            dtable.Rows.Add(_ravi3);
            ////////////////////////////////////////

            IEnumerable<SelectListItem> dropList = dtable.AsEnumerable().Select(x => new SelectListItem()
            {
                Value = x.Field<string>("Value"),
                Text = x.Field<string>("Text")
            }).ToList();
            return dropList;
        }

        public IEnumerable<SelectListItem> fillListBox(string namefunc, string _where)
        {
            DataTable dtable = new DataTable();
            //dtable = dt.DropListFn(namefunc, _where);

            ///////////////////for example///////
            dtable.Columns.Add("Value");
            dtable.Columns.Add("Text");
            DataRow _ravi = dtable.NewRow();
            _ravi["Value"] = "Anwar";
            _ravi["Text"] = "1995";
            dtable.Rows.Add(_ravi);
            DataRow _ravi2 = dtable.NewRow();
            _ravi2["Value"] = "Anwar2";
            _ravi2["Text"] = "1995";
            dtable.Rows.Add(_ravi2);
            DataRow _ravi3 = dtable.NewRow();
            _ravi3["Value"] = "Anwar3";
            _ravi3["Text"] = "1995";
            dtable.Rows.Add(_ravi3);
            ////////////////////////////////////

            IEnumerable<SelectListItem> dropList = dtable.AsEnumerable().Select(x => new SelectListItem()
            {
                Value = x.Field<string>("Value"),
                Text = x.Field<string>("Text")
            }).ToList();
            return dropList;
        }

        public static List<Dictionary<string, object>> DataTableToList(DataTable dtData)
        {

            List<Dictionary<string, object>>
            lstRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictRow = null;

            foreach (DataRow dr in dtData.Rows)
            {
                dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtData.Columns)
                {
                    dictRow.Add(col.ColumnName, dr[col]);
                }
                lstRows.Add(dictRow);
            }
            return lstRows;
        }

        public DataTable getCursor(string namecursor, string _where)
        {
            DataTable dtable = new DataTable();
            dtable = GetCursorFn(namecursor, _where);
            return dtable;
        }
    }
}