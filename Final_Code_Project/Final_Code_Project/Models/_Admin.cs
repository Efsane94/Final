using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class _Admin
    {
        public int Id { get; set; }
         
        [Required]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(300), MinLength(5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [MinLength(5)]
        [StringLength(300)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [StringLength(400)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}