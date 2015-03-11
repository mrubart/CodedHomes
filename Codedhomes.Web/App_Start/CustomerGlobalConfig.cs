using System.CodeDom;
using System.Web.Http;
using CodedHomes.Web.Filters;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Validation.Providers;

namespace CodedHomes.Web
{
	public class CustomerGlobalConfig
	{
		public static void Customize(HttpConfiguration config)
		{
			config.Services.RemoveAll(typeof (System.Web.Http.Validation.ModelValidatorProvider),
				v => v is InvalidModelValidatorProvider);

			config.Formatters.Remove(config.Formatters.XmlFormatter);

			var json = config.Formatters.JsonFormatter;
			json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			config.Filters.Add(new ValidationActionFilter());
		}
	}
}