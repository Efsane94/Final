using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class Product
    {
        public Product()
        {
            ProductColorSizes = new HashSet<ProductColorSize>();
            Images = new HashSet<Image>();
            this.Favorities = new HashSet<Favorite>();

        }

        public virtual ICollection<Favorite> Favorities { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime AdditionDate { get; set; }
        
        public int SectionCategoryId { get; set; }

        public virtual SectionCategory SectionCategory { get; set; }

        public virtual ICollection<ProductColorSize> ProductColorSizes { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}