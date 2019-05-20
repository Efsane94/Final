using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class Section
    {
        public Section()
        {
            SectionCategories = new HashSet<SectionCategory>();
            SectionSizes = new HashSet<SectionSize>();
            CategorySizes = new HashSet<CategorySize>();
        }
     
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        public virtual ICollection<SectionCategory> SectionCategories { get; set; }

        public virtual ICollection<SectionSize> SectionSizes { get; set; }

        public virtual ICollection<CategorySize> CategorySizes { get; set; }
    }
}