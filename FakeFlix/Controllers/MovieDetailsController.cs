using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeFlix.Repositories;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Syndication;

namespace FakeFlix.Controllers
{
    public class MovieDetailsController : Controller
    {
        MovieDetailsRepository repository = new MovieDetailsRepository();
        public ActionResult MovieDetailsComponent()
        {
            Item pageItem = Sitecore.Context.Item;
            if (pageItem != null)
            {
                var model = repository.GetMovieDetails(pageItem);
                return View("~/Views/MovieDetails/MovieDetailsComponent.cshtml", model);
            }
            else
            {
                Sitecore.Diagnostics.Log.Error("PAGE ITEM IS NULL!", this);
                return null;
            }

        }
    }
}