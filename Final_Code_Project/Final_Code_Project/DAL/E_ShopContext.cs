using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Final_Code_Project.Models;

namespace Final_Code_Project.DAL
{
    public class E_ShopContext:DbContext
    {
        public E_ShopContext():base("E_ShopContext")
        {

        }
        //public DbSet<MainHeader> MainHeader { get; set; }

        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionCategory> SectionCategories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<SectionSize> SectionSizes { get; set; }
        public DbSet<CategorySize> CategorySizes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MainHeader> MainHeader { get; set; }
        public DbSet<ShopHeader> ShopHeader { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColorSize> ProductColorSize { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<_Admin> Admin { get; set; }
        public DbSet<GlobalSale> GlobalSales { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
   
}