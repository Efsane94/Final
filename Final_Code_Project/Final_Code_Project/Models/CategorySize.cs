using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class CategorySize
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int SectionId { get; set; }

        public int SizeId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Section Section { get; set; }

        public virtual Size Size { get; set; }
    }
}