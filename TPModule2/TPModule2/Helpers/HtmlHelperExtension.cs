using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Linq;
using System.Web.Routing;

namespace TPModule2.Helpers
{
    public static class HtmlHelperExtension
    {
        /// <summary>
        /// Transforme une liste de chaîne de charactères en list HTML ul / li
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static MvcHtmlString ToUlLi(this HtmlHelper htmlHelper, IEnumerable<string> items, string id)
        {
            var result = new StringBuilder(string.Format("<ul{0}>", string.IsNullOrEmpty(id) ? string.Empty : string.Format(" id={0}", id)));

            foreach (var item in items)
            {
                result.AppendFormat("<li>{0}</li>", htmlHelper.Encode(item));
            }

            result.Append("</ul>");
            return MvcHtmlString.Create(result.ToString());
        }

        /// <summary>
        /// Transforme une liste de chaîne de charactères en list HTML ul / li
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static MvcHtmlString ToUlLi(this HtmlHelper htmlHelper, IEnumerable<MvcHtmlString> items, string id, string cssClass)
        {
            var result = new StringBuilder(
                string.Format("<ul{0}{1}>", 
                string.IsNullOrEmpty(id) ? string.Empty : string.Format(" id={0}", id), 
                string.IsNullOrEmpty(cssClass) ? string.Empty : string.Format(" class={0}", cssClass)));

            foreach (var item in items)
            {
                result.AppendFormat("<li>{0}</li>", item.ToHtmlString());//, string.IsNullOrEmpty(cssClass) ? string.Empty : string.Format(" class={0}", cssClass));
            }

            result.Append("</ul>");
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString ToLink(this HtmlHelper htmlHelper, string url, string text)
        {
            var link = new TagBuilder("a");
            link.Attributes.Add("href", url);
            link.SetInnerText(text);
            //link.MergeAttribute(new RouteValueDictionary(htmlAttributes)); htmlAttributes = object => objet anonyme
            return MvcHtmlString.Create(link.ToString());
            //return MvcHtmlString.Create(string.Format("<a href='{0}'>{1}</a>", url, text));
        }
    }
}