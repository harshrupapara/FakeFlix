using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;

namespace FakeFlix.Utilities.Utilities
{
    public class FieldConverter
    {
        public string GetLinkUrl(Item dataItem, string fieldName)
        {
            var options = new UrlOptions
            {
                LowercaseUrls = true,
                SiteResolving = true,
                AlwaysIncludeServerUrl = false,
                LanguageEmbedding = LanguageEmbedding.Never
            };

            Sitecore.Data.Fields.LinkField linkItem = dataItem.Fields[fieldName];
            return linkItem == null ? "/" : LinkManager.GetItemUrl(linkItem.TargetItem, options).Replace("/horizontal/fakeflix/home", "");
        }
        public string GetLinkUrl(Item dataItem)
        {
            var options = new UrlOptions
            {
                LowercaseUrls = true,
                SiteResolving = true,
                AlwaysIncludeServerUrl = false,
                LanguageEmbedding = LanguageEmbedding.Never
            };
            var PageUrl = LinkManager.GetItemUrl(dataItem, options).Replace("/horizontal/fakeflix/home", "");
            return PageUrl == null ? "/" : PageUrl;
        }
        public string GetLinkUrl(Item dataItem, bool serverUrlInclude)
        {
            var options = new UrlOptions
            {
                LowercaseUrls = true,
                SiteResolving = true,
                AlwaysIncludeServerUrl = serverUrlInclude,
                LanguageEmbedding = LanguageEmbedding.Never
            };
            var PageUrl = LinkManager.GetItemUrl(dataItem, options).Replace("/horizontal/fakeflix/home", "");
            return PageUrl == null ? "/" : PageUrl;
        }

        public string GetImageUrl(Item dataItem, string fieldName)
        {
            Sitecore.Data.Fields.ImageField imageItem = dataItem.Fields[fieldName];
            if(imageItem == null) { return null; }
            return MediaManager.GetMediaUrl(imageItem.MediaItem);
        }
    }
}