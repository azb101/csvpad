using CsvPad.UI.Web.Forms.Config;
using System;
using System.Web;
using System.Web.Routing;

namespace CsvPad.UI.Web.Forms
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            CustomServiceLocator.Initialize(Server.MapPath("~/App_Data/csv"));
        }
    }
}