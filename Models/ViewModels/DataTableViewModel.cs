using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archive.Models.ViewModels
{
    public class DataTableViewModel
    {
        public decimal start { get; set; }
        public decimal length { get; set; }
        public decimal sEcho { get; set; }
        public string sortColumn { get; set; }
        public string sortColumnDir { get; set; }


    }
}