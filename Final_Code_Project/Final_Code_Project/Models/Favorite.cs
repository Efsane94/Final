using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}