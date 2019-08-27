using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using WebApplication1.DAL.Filters;
using WebApplication1.Models;

namespace WebApplication1.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString SortLink(this HtmlHelper html,
            string linkText,
            string sortExpression,
            string action,
            string controller,
            RouteValueDictionary routeValues)
        {
            routeValues = routeValues ?? new RouteValueDictionary();
            SortDirection? sort = null;
            var sortDirectionStr = html.ViewContext.HttpContext.Request["SortDirection"];
            if ( !string.IsNullOrEmpty(sortDirectionStr) && 
                html.ViewContext.HttpContext.Request["SortExpression"] == sortExpression)
            {
                SortDirection s;
                if (Enum.TryParse(sortDirectionStr, out s))
                {
                    sort = s;
                }
            }
            routeValues["SortExpression"] = sortExpression;
            routeValues["SortDirection"] = sort.HasValue && sort.Value == SortDirection.Asc ?
                SortDirection.Desc :
                SortDirection.Asc;
            return html.Partial("SortLink", new SortLinkModel {
                Action = action,
                Controller = controller,
                SortDirection = sort,
                RouteValues = routeValues,
                LinkText = linkText
            });
        }
    }
}