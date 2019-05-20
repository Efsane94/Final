using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models.ViewModels
{
    public class Details_VM
    {
        public ProductColorSize ProductSize { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public ICollection<Color> Colors { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }

        public User User { get; set; }

        public List<Favorite> Favorites { get; set; }

    }
}