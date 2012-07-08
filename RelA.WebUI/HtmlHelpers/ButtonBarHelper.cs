using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace RelA.WebUI.HtmlHelpers
{
    public static class ButtonBarHelper
    {
        public static MvcHtmlString ButtonBar(this HtmlHelper html, IEnumerable<ButtonBarItem> buttons)
        {
            StringBuilder result = new StringBuilder();

            TagBuilder div = new TagBuilder("div");

            div.AddCssClass("toolBar");

            foreach (ButtonBarItem button in buttons)
            {
                TagBuilder alink = new TagBuilder("a");
                alink.MergeAttribute("href", string.Format("/{0}/{1}", button.Controller, button.Action));
                alink.InnerHtml = button.Name;

                div.InnerHtml += alink.ToString();
            }

            result.Append(div.ToString());

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString ButtonBar(this HtmlHelper html, string controller, bool showEdit, bool showDelete, bool showCancel)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder div = new TagBuilder("div");

            TagBuilder form = null;
            TagBuilder alink = null;

            div.AddCssClass("toolBar");
            
            if (showCancel)
            {
                form = new TagBuilder("form");

                alink = new TagBuilder("a");
                alink.MergeAttribute("href", string.Format("/{0}/{1}", controller, "Index"));
                alink.InnerHtml = "Cancelar";
                div.InnerHtml += alink.ToString();
            }

            if (showEdit)
            {
                alink = new TagBuilder("a");
                alink.MergeAttribute("href", string.Format("/{0}/{1}", controller, "Edit"));
                alink.InnerHtml = "Cancelar";
                div.InnerHtml += alink.ToString();
            }
            

            result.Append(div.ToString());
                        

            return MvcHtmlString.Create(result.ToString());
        }
    }

    public class ButtonBarItem
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}