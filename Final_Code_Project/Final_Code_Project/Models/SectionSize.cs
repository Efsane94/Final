using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Code_Project.Models
{
    public class SectionSize
    {
        public int Id { get; set; }

        public int SectionId { get; set; }

        public int SizeId { get; set; }

        public virtual Section Sections { get; set; }

        public virtual Size Sizes { get; set; }
    }
}