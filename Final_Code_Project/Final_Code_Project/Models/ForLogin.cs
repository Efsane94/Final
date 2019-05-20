using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class ForLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        [Index("UN_Email", IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


    }
}