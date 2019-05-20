using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class Category
    {
        public Category()
        {
            SectionCategories = new HashSet<SectionCategory>();
            CategorySizes = new HashSet<CategorySize>();
        }
       
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public virtual ICollection<SectionCategory> SectionCategories { get; set; }

        public virtual ICollection<CategorySize> CategorySizes { get; set; }
    }
}