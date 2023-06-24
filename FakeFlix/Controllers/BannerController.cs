using FakeFlix.Models;
using FakeFlix.Repositories;
using System.Web.Mvc;

namespace FakeFlix.Controllers
{
    public class BannerController : Controller
    {
        public ActionResult BannerComponent()
        {
            BannerRepository bannerData = new BannerRepository();
            BannerModel model = bannerData.GetBannerData();
            return View("~/Views/Banner/BannerComponent.cshtml", model);
        }
    }
}