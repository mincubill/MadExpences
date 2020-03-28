using System;
using System.Collections.Generic;
using System.Text;

namespace MadExpences.Core
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Category> SubCategory { get; set; }
        public bool IsSubCategory { get; set; }
    }
}
