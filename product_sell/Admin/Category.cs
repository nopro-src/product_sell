using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace product_sell.Admin
{
    public class Category
    {
        public int category_id { get; set; }
        public string name { get; set; }

        public Category(int category_id, string name)
        {
            this.category_id = category_id;
            this.name = name;
        }

        public Category()
        {
        }
    }
}