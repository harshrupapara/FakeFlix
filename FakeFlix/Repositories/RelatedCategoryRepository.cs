using FakeFlix.Models;
using FakeFlix.Utilities.Utilities;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Repositories
{
    public class RelatedCategoryRepository
    {
        public RelatedCategoryModel GetRelatedCategoryData()
        {
            FieldConverter fieldConverter = new FieldConverter();
            Item dataSourceItem = RenderingContext.Current.Rendering.Item;
            try
            {
                if (dataSourceItem == null)
                {
                    Sitecore.Diagnostics.Log.Error("DATASOURCE ITEM IS NULL!", this);
                    return null;
                }
                RelatedCategoryModel model = new RelatedCategoryModel();
                MultilistField multilist = dataSourceItem.Fields["RelatedCategories"];
                if (multilist == null)
                {
                    Sitecore.Diagnostics.Log.Error("Multilist field is empty or null in Related Category Repo!", this);
                    return null;
                }
                Item[] relatedItems = multilist.GetItems();
                if(relatedItems == null)
                {
                    Sitecore.Diagnostics.Log.Error("Not able to get the items of multilist or is NULL!", this);
                    return null;
                }
                List<RelatedCategoryItems> list = new List<RelatedCategoryItems>();
                foreach (Item item in relatedItems)
                {
                    RelatedCategoryItems relatedCategoryItems = new RelatedCategoryItems()
                    {
                        CategoryItems = item,
                        CategoryItemUrl = fieldConverter.GetLinkUrl(item),
                    };
                    list.Add(relatedCategoryItems);
                }
                model.RelatedCategoyList = list;
                return model;
            }
            catch(Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("An error occured in Contact Us Repository", ex, typeof(RelatedCategoryModel));
                return null;
            }
        }
    }
}