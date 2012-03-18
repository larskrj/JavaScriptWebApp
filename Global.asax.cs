using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JavaScriptWebApp
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class JavaScriptWebAppApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{resource}.html/");
			routes.MapPageRoute("index", string.Empty, "~/index.html");

			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			
		}

		public static void RegisterHttpRoutes(HttpRouteCollection routes)
		{
			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
			
			var config = GlobalConfiguration.Configuration;
			
			// Replace the default JsonFormatter with our custom one
			ConfigureApi(config);

			BundleTable.Bundles.RegisterTemplateBundles();
		}

		public static void ConfigureApi(HttpConfiguration config)
		{
			var index = config.Formatters.IndexOf(config.Formatters.JsonFormatter);
			config.Formatters[index] = new JsonCamelCaseFormatter();

			config.MessageHandlers.Add(new CorsHandler());
		}
	}
}