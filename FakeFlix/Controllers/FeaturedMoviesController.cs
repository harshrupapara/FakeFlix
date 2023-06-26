using FakeFlix.Models;
using FakeFlix.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace FakeFlix.Controllers
{
    public class FeaturedMoviesController : Controller
    {
        public ActionResult FeaturedMoviesComponent()
        {
            FeaturedMoviesRepository featuredMoviesRepository = new FeaturedMoviesRepository();
            FeaturedMoviesModel model = featuredMoviesRepository.GetFeaturedMoviesData();
            return View("~/Views/Featured Movies/FeaturedMoviesComponent.cshtml", model);
        }
    }
}