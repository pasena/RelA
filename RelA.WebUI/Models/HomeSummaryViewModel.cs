using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace RelA.WebUI.Models
{
    public class HomeSummaryViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime ChangeDate { get; set; }
        public Color Color { get; set; }
    }
}