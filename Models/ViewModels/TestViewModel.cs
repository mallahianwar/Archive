
using Archive.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archive.Models.ViewModels
{
    public class TestViewModel: MainModel
    {
        public IEnumerable<SelectListItem> DList { get; set; }
        public string DListV { get; set; }

        public IEnumerable<string> LboxV { get; set; }
        public IEnumerable<SelectListItem> Lbox { get; set; }

    }
}