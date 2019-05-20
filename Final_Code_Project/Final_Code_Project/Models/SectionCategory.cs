using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class SectionCategory
    {
        public SectionCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int SectionId { get; set; }
        public virtual Section Section { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}