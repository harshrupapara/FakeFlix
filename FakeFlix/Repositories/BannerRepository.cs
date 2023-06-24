using FakeFlix.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using Sitecore.Shell.Applications.ContentEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Repositories
{
    public class BannerRepository
    {
        public BannerModel GetBannerData()
        {
            try
            {
                Item dataSourceItem = RenderingContext.Current.Rendering.Item;
                MultilistField multilist = dataSourceItem.Fields["BannerItems"];
                Item[] bannerItems = multilist.GetItems();
                List<BannerItems> listItems = new List<BannerItems>();
                foreach (Item iterator in bannerItems)
                {
                    BannerItems list = new BannerItems
                    {
                        BannerItem = iterator,
                    };
                    listItems.Add(list);
                }
                BannerModel model = new BannerModel
                {
                    BannerList = listItems
                };
                return model;
            }
            catch (Exception ex)
            {
                Log.Error("An error occured in BannerRepository", ex, typeof(BannerModel));
                return null;
            }
        }
    }
}