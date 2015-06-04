using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookWorm.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string BAuthor { get; set; }
        public DateTime Date { get; set; }


        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}