using FakeFlix.Repositories;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeFlix.Controllers
{
    public class MovieListingController : Controller
    {
        public ActionResult MovieListingComponent()
        {
            var dataSourceItem = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            if (dataSourceItem != null)
            {
                ViewBag.DataSourceID = dataSourceItem?.ID.ToString();
            }
            ViewBag.PageId = PageContext.Current.Item?.ID.ToString();
            return View("~/Views/MovieListing/MovieListingComponent.cshtml");
        }

        [HttpGet]
        public JsonResult GetMovieListing(string DataSourceId, string PageId)
        {
            MovieListingRepository listingRepo = new MovieListingRepository();
            return listingRepo.GetMoviesListingData(DataSourceId, PageId);
        }

    }

}