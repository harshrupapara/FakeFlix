using FakeFlix.Models;
using FakeFlix.Repositories;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace FakeFlix.Controllers
{
    public class CategoryListingController : Controller
    {
        public ActionResult CategoryListing()
        {
            var dataSourceItem = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            if(dataSourceItem != null)
            {
                ViewBag.DataSourceId = dataSourceItem?.ID.ToString();
            }
            ViewBag.PageId = PageContext.Current.Item.ID.ToString();
            return View();
        }

        [HttpGet]
        public JsonResult GetCategoryData(string dataSourceId, string pageId)
        {
            CategoryListingRepository categoryRepo = new CategoryListingRepository();
            return categoryRepo.GetCategoryListingData(dataSourceId, pageId);
        }
    }
}