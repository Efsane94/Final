using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class Color
    {
        public Color()
        {
            ProductColorSizes = new HashSet<ProductColorSize>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ProductColorSize> ProductColorSizes { get; set; }

    }
}