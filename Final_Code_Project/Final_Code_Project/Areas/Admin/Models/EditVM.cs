using Final_Code_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Areas.Admin.Models
{
    public class EditVM
    {
        public Product Product { get; set; }

        public List<Section> Sections { get; set; }

        public List<Category> Categories { get; set; }
    }
}