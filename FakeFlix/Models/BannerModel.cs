using Sitecore.Express;
using System;
using System.Collections.Generic;

using Sitecore.Data.Items;

namespace FakeFlix.Models
{
    public class BannerModel
    {
        public List<BannerItems> BannerList { get; set; }
    }
    public class BannerItems
    {
        public Item BannerItem { get; set; }
    }
}