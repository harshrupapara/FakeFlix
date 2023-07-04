using FakeFlix.Repositories;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeFlix.Controllers
{
    public class ProductListingController : Controller
    {
        public ActionResult ProductListingComponent()
        {

            Item pageItem = PageContext.Current.Item;
            string pageId = pageItem?.ID.ToString();
            if(pageId != null)
            {
                ViewBag.PageId = pageId;
            }

            Database dB = Sitecore.Context.Database;
            var dataSourceItem = dB.GetItem(RenderingContext.Current.Rendering.DataSource);
            if (dataSourceItem != null)
            {
                ViewBag.DataSourceID = dataSourceItem?.ID.ToString();
            }

            return View("~/Views/ProductListing/ProductListingComponent.cshtml");            
        }
        [HttpGet]
        public JsonResult GetProductListing(string PageId, string DataSourceId)
        {
           
            ProductListingRepository productListingRepository = new ProductListingRepository();
            return productListingRepository.GetProductListingData(DataSourceId, PageId);

        }
    }
}