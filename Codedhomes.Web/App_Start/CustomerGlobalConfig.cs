using System.Web.Http;
using CodedHomes.Web.Filters;

namespace CodedHomes.Web
{
	public class CustomerGlobalConfig
	{
		public static void Customize(HttpConfiguration config)
		{
			config.Filters.Add(new ValidationActionFilter());
		}
	}
}