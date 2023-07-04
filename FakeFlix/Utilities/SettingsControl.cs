using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Utilities
{
    public class SettingsControl
    {
        public static Item GetSettingsControlItem()
        {
            Item settingItems = Sitecore.Context.Database.GetItem("/sitecore/content/Horizontal/FakeFlix/Settings Control");
            return settingItems;
        }
    }
}