using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace RelA.WebUI.Util
{
    public static class OpositeColor
    {
        public static Color GetReadableForeColor(this Color c)
        {
            return (((c.R + c.B + c.G) / 3) > 128) ? Color.Black : Color.White;
        }
    }
}