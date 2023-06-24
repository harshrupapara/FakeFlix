using FakeFlix.Models;
using Sitecore.Data;
using Sitecore.Links.UrlBuilders;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace FakeFlix.Repositories
{
    public class BreadCrumbRepository
    {
        public BreadCrumbModel BreadCrumbRepoData(string PageId)
        {
            BreadCrumbModel model = new BreadCrumbModel(); 
            Database webDB = Sitecore.Context.Database;
            Item PageItem = webDB.GetItem(PageId);
            List<Ancestors> AncestorsList = new List<Ancestors>();
            IEnumerable<Item> Ancestors = PageItem.Axes.GetAncestors().ToList();

            ItemUrlBuilderOptions options = new ItemUrlBuilderOptions
            {
                LowercaseUrls = true,
                SiteResolving = true,
                AlwaysIncludeServerUrl = false,
                LanguageEmbedding = LanguageEmbedding.Never
            };

            Ancestors CurrentItem = new Ancestors()
            {
                Name = PageItem.Name,
                URL = LinkManager.GetItemUrl(PageItem, options).Replace("/Horizontal/FakeFlix", ""),
                IsActive = PageId == PageItem.ID.ToString(),
            };

            AncestorsList.Add(CurrentItem);

            Item HomeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            foreach(Item Ancestor in Ancestors.Reverse())
            {
                if (Ancestor.ID.ToString() != HomeItem.ParentID.ToString())
                {
                    Ancestors AncestorItem = new Ancestors()
                    {
                        Name = Ancestor.Name,
                        URL = LinkManager.GetItemUrl(Ancestor, options).Replace("/Horizontal/FakeFlix", ""),
                        IsActive = PageId == Ancestor.ID.ToString(),
                    };
                    AncestorsList.Add(AncestorItem);
                }
                else
                {
                    break;
                }
            }
            AncestorsList.Reverse();
            model.AncestorsDetails = AncestorsList;

            return model;

        }
    }
}