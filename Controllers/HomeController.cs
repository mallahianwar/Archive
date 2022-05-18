using Archive.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Archive.Models.Classes;
using Archive.Models.ViewModels;

namespace Archive.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            Models.ViewModels.TestViewModel m = new Models.ViewModels.TestViewModel();
            Models.Classes.MainFunctions L = new Models.Classes.MainFunctions();

            m.DList = L.fillDropList("", "");
            m.Lbox = L.fillListBox("", "");
            return View(m);
        }
        public ActionResult Manage(DataTableViewModel  param)
        {
            param.sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + 
                "][name]").FirstOrDefault();
            param.sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //int start = 1;
            //int length = 10;
            var totalRowsCount = 0;
            param.length = (param.start + param.length); 


            ///////////////////for example///////
            DataTable dtable = new DataTable();
            dtable.Columns.Add("Value");
            dtable.Columns.Add("Text");
            DataRow _ravi = dtable.NewRow();
            _ravi["Value"] = "Anwar";
            _ravi["Text"] = "1994";
            dtable.Rows.Add(_ravi);
            DataRow _ravi2 = dtable.NewRow();
            _ravi2["Value"] = "Anwar3";
            _ravi2["Text"] = "1995";
            dtable.Rows.Add(_ravi2);
            DataRow _ravi3 = dtable.NewRow();
            _ravi3["Value"] = "Anwar2";
            _ravi3["Text"] = "1993";
            dtable.Rows.Add(_ravi3);
            //////////////////////////////////// 

            List<Dictionary<string, object>> data = MainFunctions.DataTableToList(dtable);
            var aaData = new object();
            aaData = from c in data
                     select new[] {
                                   c["Value"].ToString(),
                                   c["Text"].ToString()
                     };
            return Json(new
            {
                sEcho = param.sEcho,
                aaData = aaData,
                iTotalRecords = Convert.ToInt32(totalRowsCount),
                iTotalDisplayRecords = Convert.ToInt32(totalRowsCount),
            }, JsonRequestBehavior.AllowGet);
        }

         
    }
}