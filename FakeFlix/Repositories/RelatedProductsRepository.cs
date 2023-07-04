using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeFlix.Models;
using Sitecore.Data.Fields;
using System.Runtime.Remoting.Proxies;
using FakeFlix.Utilities.Utilities;

namespace FakeFlix.Repositories
{
    public class RelatedProductsRepository
    {
        public RelatedProductsModel GetRelatedProductsData()
        {
            FieldConverter fieldConverter = new FieldConverter();
            Item pageItem = PageContext.Current.Item;
            try
            {
                if (pageItem == null)
                {
                    Sitecore.Diagnostics.Log.Error("DATASOURCE ITEM IS NULL!", this);
                    return null;
                }
                RelatedProductsModel model = new RelatedProductsModel();
                MultilistField multilist = pageItem.Fields["RelatedProducts"];
                List<RelatedProductsItems> list = new List<RelatedProductsItems>();
                if (multilist != null)
                {
                    Item[] relatedItems = multilist.GetItems();
                    if (relatedItems == null)
                    {
                        Sitecore.Diagnostics.Log.Error("NO ITEMS FOUND IN RELATED PRODUCTS MULTILIST", this);
                        return null;
                    }
                    foreach (Item item in relatedItems)
                    {
                        RelatedProductsItems relatedProductsItems = new RelatedProductsItems()
                        {
                            ProductItem = item,
                            ProductItemURL = fieldConverter.GetLinkUrl(item),
                            ProductGenre = item.Parent.Name
                        };
                        list.Add(relatedProductsItems);
                    }
                    model.RelatedProductList = list;
                }
                return model;
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("An error occured in Related Products Repository", ex, typeof(RelatedProductsModel));
                return null;
            }
        }
    }
}
