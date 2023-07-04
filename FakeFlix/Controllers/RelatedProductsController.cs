using FakeFlix.Models;
using FakeFlix.Repositories;
using Sitecore.Mvc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeFlix.Controllers
{
    public class RelatedProductsController : Controller
    {
        public ActionResult RelatedProductsComponent()
        {
            RelatedProductsRepository relatedProductsRepository = new RelatedProductsRepository();
            RelatedProductsModel model = relatedProductsRepository.GetRelatedProductsData();
            return View("~/Views/RelatedProducts/RelatedProductsComponent.cshtml",model);
        }
    }
}