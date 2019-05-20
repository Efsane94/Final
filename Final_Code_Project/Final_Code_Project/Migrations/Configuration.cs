namespace Final_Code_Project.Migrations
{
    using Final_Code_Project.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<Final_Code_Project.DAL.E_ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Final_Code_Project.DAL.E_ShopContext context)
        {
            context.MainHeader.AddOrUpdate(s => s.Title,
                            new MainHeader { Title = "New Collection", Image = "bg-img/bg-1.jpg" }
                        );

            context.ShopHeader.AddOrUpdate(s => s.Title,
                new ShopHeader { Title = "DRESSES", Image = "bg-img/breadcumb.jpg" }
            );

            context.Sizes.AddOrUpdate(s => s.Name,
                new Size { Name = "S" },
                new Size { Name = "M" },
                new Size { Name = "26" },
                new Size { Name = "28" },
                new Size { Name = "1-2" },
                new Size { Name = "2-3" }
            );

            context.Colors.AddOrUpdate(c => c.Name,
                new Color { Name = "Black" },
                new Color { Name = "Blue" },
                new Color { Name = "Gray" }
            );

            context.Sections.AddOrUpdate(s => s.Name,
                new Section { Name = "Men", Image = "bg-img/bg-2.jpg" },
                new Section { Name = "Women", Image = "bg-img/bg-3.jpg" },
                new Section { Name = "Kids", Image = "bg-img/bg-2.jpg" }
            );

            context.Categories.AddOrUpdate(c => c.Name,
                new Category { Name = "Jeans" },
                new Category { Name = "Trousers" },
                new Category { Name = "Shirt" },
                new Category { Name = "T-Shirt" },
                new Category { Name = "Dress" },
                new Category { Name = "Skirt" },
                new Category { Name = "Coat" },
                new Category { Name = "Sweatshirt" },
                new Category { Name = "Jackets" }
           );

            context.Admin.AddOrUpdate(a=>a.Email,
                new _Admin
                {
                    Email = "admin@mail.ru",
                    Password = Crypto.HashPassword("admin").ToString(),
                }
            );

            context.GlobalSales.AddOrUpdate(a => a.Image,
                new GlobalSale { Image = "bg-img/bg-1.jpg" }
            );

            context.Contact.AddOrUpdate(c => c.Title,
                new Contact { Map = "<iframe id='gmap_canvas' src = 'https://maps.google.com/maps?q=baku%20af%20business%20house&t=&z=13&ie=UTF8&iwloc=&output=embed' frameborder = '0' scrolling = 'no' marginheight = '0' marginwidth = '0' ></ iframe >",
                    Title = "How to Find Us", Information= "Mauris viverra cursus ante laoreet eleifend. Donec vel fringilla ante. Aenean finibus velit id urna vehicula, nec maximus est sollicitudin.",
                    Address= " 10 Suffolk st Soho, London, UK", Number= " +12 34 567 890" } 
            );
        }
    }
}
