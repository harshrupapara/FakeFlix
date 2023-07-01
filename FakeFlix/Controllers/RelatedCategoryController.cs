using FakeFlix.Models;
using FakeFlix.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeFlix.Controllers
{
    public class RelatedCategoryController : Controller
    {
        public ActionResult RelatedCategoryComponent()
        {
            RelatedCategoryRepository relatedCategoryRepository = new RelatedCategoryRepository();
            RelatedCategoryModel model = relatedCategoryRepository.GetRelatedCategoryData();
            return View("~/Views/RelatedCategory/RelatedCategoryComponent.cshtml", model);
        }   
        
    }
}