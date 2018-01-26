using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class Product
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Category { set; get; }
        public decimal Price { set; get; }
    }
}