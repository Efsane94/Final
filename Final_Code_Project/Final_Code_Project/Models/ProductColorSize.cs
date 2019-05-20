using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class ProductColorSize
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        public int Amount { get; set; }

        public virtual Product Product { get; set; }

        public virtual Color Color { get; set; }

        public virtual Size Size { get; set; }

    }
}