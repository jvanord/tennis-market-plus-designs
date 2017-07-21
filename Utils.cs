using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tennis_market_plus_designs
{
	public static class Utils
	{
		private static string _themeCode;
		public static string ThemeCode
		{
			get
			{
				if (_themeCode == null)
					_themeCode = HttpContext.Current.Session["theme"] as string ?? string.Empty;
				return _themeCode;
			}
			set
			{
				HttpContext.Current.Session["theme"] = _themeCode = value;
			}
		}
		public static IHtmlString IfUrlContains(this HtmlHelper html, string stringToMatch, string stringToWrite, bool raw = false)
		{
			if (string.IsNullOrWhiteSpace(stringToMatch)) return MvcHtmlString.Empty;
			if (!HttpContext.Current.Request.Path.ToLower().Contains(stringToMatch.Trim().ToLower())) return MvcHtmlString.Empty;
			if (raw) return html.Raw(stringToWrite);
			return MvcHtmlString.Create(stringToWrite);
		}

		public static IHtmlString If(this HtmlHelper html, bool condition, string stringToWrite, string stringToWriteIfFalse = null, bool raw = false)
		{
			var text = condition ? stringToWrite : stringToWriteIfFalse;
			if (string.IsNullOrEmpty(text)) return MvcHtmlString.Empty;
			if (raw) return html.Raw(text);
			return MvcHtmlString.Create(text);
		}

		public static IHtmlString IfHomePage(this HtmlHelper html, string stringToWrite, bool raw = false)
		{
			var url = HttpContext.Current.Request.Path.ToLower();
			if (string.IsNullOrWhiteSpace(url) || url == "/")
			{
				if (raw) return html.Raw(stringToWrite);
				return MvcHtmlString.Create(stringToWrite);
			}
			return MvcHtmlString.Empty;
		}
	}

	public class DesignPageAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			switch (filterContext.HttpContext.Request.QueryString["theme"])
			{
				case "bold":
					Utils.ThemeCode = "1"; break;
				case "alt":
					Utils.ThemeCode = "2"; break;
				case "basic":
				case "light":
				case "":
					Utils.ThemeCode = string.Empty; break;
				default: break;
			}
		}
	}
}