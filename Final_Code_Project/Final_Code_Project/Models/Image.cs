using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class Image
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string ImageSource { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product{ get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}