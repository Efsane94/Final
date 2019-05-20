using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Code_Project.DAL;

namespace Final_Code_Project.Models.ViewModels
{
    public class Layout_VM
    {
        public IEnumerable<Section> Sections { get; set; }
        public IEnumerable<SectionCategory> SectionCategories { get; set; }

        public User User { get; set; }
    }
}