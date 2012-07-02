using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelA.WebUI.Models.Filters
{
    public class TaskFilter
    {
        public string Title { get; set; }
        public DateTime? RequestDateFrom { get; set; }
        public DateTime? RequestDateTo { get; set; }
        public int ProjectID { get; set; }
    }
}