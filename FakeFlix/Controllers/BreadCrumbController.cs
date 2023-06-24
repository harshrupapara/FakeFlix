using FakeFlix.Repositories;
using System;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using FakeFlix.Models;

namespace FakeFlix.Controllers
{
    public class BreadCrumbController : Controller
    {
        public ActionResult BreadCrumbComponent()
        {
            BreadCrumbRepository breadCrumbRepository = new BreadCrumbRepository();
            BreadCrumbModel model = breadCrumbRepository.BreadCrumbRepoData(PageContext.Current.Item.ID.ToString());
            return View("~/Views/BreadCrumb/BreadCrumbComponent.cshtml",model);
        }
    }
}