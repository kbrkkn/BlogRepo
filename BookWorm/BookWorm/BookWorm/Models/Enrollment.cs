using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorm.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int BookID { get; set; }
        public int AuthorID { get; set; }


        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}