using FakeFlix.Models;
using FakeFlix.Utilities;
using FakeFlix.Utilities.Utilities;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.Design;

namespace FakeFlix.Repositories
{
    public class CategoryListingRepository
    {
        public JsonResult GetCategoryListingData(string dataSourceId, string pageId)
        {
            CategoryListingModel model = new CategoryListingModel();
            List<Categories> categories = new List<Categories>();
            FieldConverter fC = new FieldConverter();

            try
            {
                if (dataSourceId == null)
                {
                    return new JsonResult()
                    {
                        Data = "Datasource ID is null! Provide a Datasource",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                if (pageId == null)
                {
                    return new JsonResult()
                    {
                        Data = "Page ID is null! Provide a Datasource",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                Database contextDB = Sitecore.Configuration.Factory.GetDatabase(Sitecore.Context.Database.Name);

                if (contextDB == null)
                {
                    return new JsonResult()
                    {
                        Data = "Failed to retrieve the Context DB!",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                Item categoryItems = contextDB.GetItem(dataSourceId);
                Item pageItem = contextDB.GetItem(pageId);

                if (categoryItems != null)
                {
                    model.CategoryListTitle = categoryItems["CL-Title"];
                    model.CategoryListDescription = categoryItems["CL-Desc"];
                    model.DefaultResult = Int32.Parse(categoryItems["CL-DefaultResult"]);
                    model.ResultPerLoadMore = Int32.Parse(categoryItems["CL-ResultsPerLoad"]);
                }

                //Getting Category List from Page Id//
                if (pageItem != null && pageItem.HasChildren)
                {
                    foreach (Item items in pageItem.Children)
                    {
                        Categories categoryListItems = new Categories()
                        {
                            CategoryTitle = items["CategoryTitle"],
                            CategoryCTALink = fC.GetLinkUrl(items),
                            CategoryImageLink = fC.GetImageUrl(items, "CategoryImage")
                        };
                        categories.Add(categoryListItems);
                    }
                }
                model.CategoriesList = categories;
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{DateTime.Now.ToShortTimeString()}  Error:{ex.Message}", this);
                return new JsonResult()
                {
                    Data = ex.Message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return new JsonResult()
            {
                Data = model,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}