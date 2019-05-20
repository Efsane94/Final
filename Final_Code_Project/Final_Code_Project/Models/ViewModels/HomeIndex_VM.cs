using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models.ViewModels
{
    public class HomeIndex_VM
    {
        public MainHeader MainHeader { get; set; }
        public IEnumerable<Section> Sections { get; set; }
        public GlobalSale GlobalSale { get; set; }

    }
}



//context.MainHeader.AddOrUpdate(s => s.Title,
//                new MainHeader { Title = "New Collection", Image = "bg-img/bg-1.jpg" }
//            );

//            context.ShopHeader.AddOrUpdate(s => s.Title,
//                new ShopHeader { Title = "DRESSES", Image = "bg-img/breadcumb.jpg" }
//            );

//            context.Sizes.AddOrUpdate(s => s.Name,
//                new Size { Name = "S" },
//                new Size { Name = "M" },
//                new Size { Name = "26" },
//                new Size { Name = "28" },   
//                new Size { Name = "1-2" },
//                new Size { Name = "2-3" }
//  
//            );

//            context.Colors.AddOrUpdate(c => c.Name,
//                new Color { Name = "Black" },
//                new Color { Name = "Blue" },
//                new Color { Name = "Gray" }
//            );

//            context.Sections.AddOrUpdate(s => s.Name,
//                new Section { Name = "Men", Image= "bg-img/bg-2.jpg" },
//                new Section { Name = "Women" , Image= "bg-img/bg-3.jpg" },
//                new Section { Name = "Kids" , Image= "bg-img/bg-2.jpg" }
//            );

//            context.Categories.AddOrUpdate(c => c.Name,
//                new Category { Name = "Jeans" },
//                new Category { Name = "Trousers" },
//                new Category { Name = "Shirt" },
//                new Category { Name = "T-Shirt" },
//                new Category { Name = "Dress" },
//                new Category { Name = "Skirt" },
//                new Category { Name = "Coat" },
//                new Category { Name = "Sweatshirt" },
//                new Category { Name = "Jackets" }
//           );