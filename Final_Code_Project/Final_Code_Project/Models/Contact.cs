using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Information { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(10)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        [Required]
        public string Map { get; set; }
    }
}