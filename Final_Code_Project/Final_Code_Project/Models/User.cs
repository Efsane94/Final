using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class User
    {
        public User()
        {
            this.Favorities = new HashSet<Favorite>();
        }
        public virtual ICollection<Favorite> Favorities { get; set; }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        //[Index("UN_Email", IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [StringLength(300),MinLength(5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [MinLength(5)]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}