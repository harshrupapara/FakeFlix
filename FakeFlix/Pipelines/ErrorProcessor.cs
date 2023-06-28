using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Web;
using Sitecore;
using Sitecore.Data;

namespace FakeFlix.Pipelines
{
    public class ErrorProcessor : HttpRequestProcessor
    {
        protected HttpRequestArgs Args { get; set; }
        protected virtual bool LocalPathStartsWithSitecore => this.Args.LocalPath.StartsWith("/sitecore");
        protected virtual bool FilePathStartsWithSitecore => this.Args.Url.FilePath.StartsWith("/sitecore");

        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));

            if ((Context.Item != null) || (Context.Database == null))
                return;

            if (args.Url.FilePath.StartsWith("/~/"))
                return;

            var notFoundPage = Context.Database.GetItem("/sitecore/content/Horizontal/FakeFlix/Home/Generic Page");
            if (notFoundPage == null)
                return;

            args.ProcessorItem = notFoundPage;
            Context.Item = notFoundPage;
        }

        public Item GetError()
        {
            //getting the 404 page by item path
            var err404ItemPath = "/sitecore/content/Horizontal/FakeFlix/Home/Generic Page";
            var error404Item = Context.Database.GetItem(err404ItemPath);
            return error404Item;
        }

        public bool ShouldNotProcess(HttpRequestArgs args)
        {
            if (IsValidItem)
            {
                return true;
            }
            if (LocalPathStartsWithSitecore)
            {
                return true;
            }
            if (FilePathStartsWithSitecore)
            {
                return true;
            }
            if (Context.Site == null)
            {
                return true;
            }
            if (args.PermissionDenied)
            {
                return true;
            }
            return false;

        }

        protected virtual bool IsValidItem
        {
            get
            {
                if (Context.Item == null)
                {
                    return false;
                }
                if (Context.Item.Versions.Count <= 0)
                {
                    return false;
                }
                var tenant404 = GetError();
                if (Context.Item != null && tenant404 != null)
                {
                    if (Context.Item.ID == tenant404.ID)
                    {
                        return false;
                    }
                }
                return (Context.Item.Visualization.Layout != null)
                       || !string.IsNullOrEmpty(WebUtil.GetQueryString("Main"));
            }
        }
    }
}