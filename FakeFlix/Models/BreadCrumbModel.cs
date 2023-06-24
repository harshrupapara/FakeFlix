using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeFlix.Models
{
    public class BreadCrumbModel
    {
        public List<Ancestors> AncestorsDetails { get; set; }
    }
    public class Ancestors
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public Boolean IsActive { get; set; }
    }
}