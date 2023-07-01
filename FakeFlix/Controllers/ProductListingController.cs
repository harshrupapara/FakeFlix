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
            Database dB = Sitecore.Context.Database;
            var dataSourceItem = dB.GetItem(RenderingContext.Current.Rendering.DataSource);
            if (dataSourceItem != null)
            {
                ViewBag.DataSourceID = dataSourceItem?.ID.ToString();
            }
            
            return View("~/Views/ProductListing/ProductListingComponent.cshtml");
            
        }
        [HttpGet]
        public JsonResult GetProductListing(string DataSourceId)
        {
            string ITEM__ID = "{2D4553E4-7062-436D-BAC4-CB4C2099D15A}";
            ProductListingRepository productListingRepository = new ProductListingRepository();
            return productListingRepository.GetProductListingData(DataSourceId, ITEM__ID);

        }
    }
}