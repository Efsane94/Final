using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models.ViewModels
{
    public class Shop_VM
    {
        public ICollection<Product> Products { get; set; }

        public User User { get; set; }
        public List<Favorite> Favorites { get; set; }
        public ShopHeader ShopHeader { get; set; }
    }
}