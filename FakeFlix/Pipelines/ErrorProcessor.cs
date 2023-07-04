using Sitecore.Pipelines.HttpRequest;
using Sitecore.Diagnostics;
using Sitecore;
using Sitecore.Data;

namespace FakeFlix.Pipelines
{
    public class ErrorProcessor : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));

            if ((Context.Item != null) || (Context.Database == null))
                return;

            if (args.Url.FilePath.StartsWith("/~/"))
                return;

            var notFoundPage = Context.Database.GetItem("/sitecore/content/Horizontal/FakeFlix/Home/{1346A16E-BF47-443D-A959-5087CCEA3A78}");
            if (notFoundPage == null)
                return;

            args.ProcessorItem = notFoundPage;
            Context.Item = notFoundPage;
        }

    }
}