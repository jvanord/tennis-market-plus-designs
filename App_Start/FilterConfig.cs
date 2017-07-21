using System.Web;
using System.Web.Mvc;

namespace tennis_market_plus_designs
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
