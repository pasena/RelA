using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace RelA.WebUI.Models
{
    public class HomeViewModel
    {
        public IList<HomeSummaryViewModel> Requested { get; set; }
        public IList<HomeSummaryViewModel> Concluded { get; set; }
        public IList<HomeSummaryViewModel> Developing { get; set; }
        public IList<HomeSummaryViewModel> Others { get; set; }

        public Color Color { get; set; }
        public Color TextColor { get; set; }

    }
}
