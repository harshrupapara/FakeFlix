using Sitecore.Pipelines;
using System.Web.Routing;
using FakeFlix.App_Start;

namespace FakeFlix.Pipelines
{
    public class LoadRoutes
    {
        public void Process(PipelineArgs args)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}