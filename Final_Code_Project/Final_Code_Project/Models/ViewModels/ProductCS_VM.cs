using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Code_Project.Models;

namespace Final_Code_Project.Models.ViewModels
{
    public class ProductCS_VM
    {
        public IEnumerable<Size> Sizes { get; set; }

        public ProductColorSize ProductSize { get; set; }

    }
}