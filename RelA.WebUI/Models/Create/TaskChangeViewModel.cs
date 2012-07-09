using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RelA.Domain.Entities;

namespace RelA.WebUI.Models.Create
{
    public class TaskChangeViewModel
    {
        public int TaskID { get; set; }
        public string TaskTitle { get; set; }
        public string ProjectName { get; set; }
        public Change Change { get; set; }
    }
}