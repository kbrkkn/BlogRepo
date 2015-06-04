using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorm.DAL
{
    public class BlogInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var authors = new List<Author>
            {
            new Author{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Author{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Author{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Author{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Author{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Author{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Author{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Author{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            authors.ForEach(s => context.Authors.Add(s));
            context.SaveChanges();
            var books = new List<Book>
            {
            new Book{BookID=1050,Title="Chemistry",Content="ch",Date=DateTime.Parse("2005-09-01"),BAuthor="df"},
            new Book{BookID=4022,Title="Microeconomics",Content="ch",Date=DateTime.Parse("2005-09-01"),BAuthor="df"},
            new Book{BookID=4041,Title="Macroeconomics",Content="ch",Date=DateTime.Parse("2005-09-01"),BAuthor="df"},
            new Book{BookID=1045,Title="Calculus",Content="ch",Date=DateTime.Parse("2005-09-01"),BAuthor="df"},
            new Book{BookID=3141,Title="Trigonometry",Content="ch",Date=DateTime.Parse("2005-09-01"),BAuthor="df"},
            new Book{BookID=2021,Title="Composition",Content="ch",Date=DateTime.Parse("2005-09-01"),BAuthor="df"},
            new Book{BookID=2042,Title="Literature",Content="ch",Date=DateTime.Parse("2005-09-01"),BAuthor="df"}
            };
            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{AuthorID=1,BookID=1050},
            new Enrollment{AuthorID=1,BookID=4022},
            new Enrollment{AuthorID=1,BookID=4041},
            new Enrollment{AuthorID=2,BookID=1045},
            new Enrollment{AuthorID=2,BookID=3141},
            new Enrollment{AuthorID=2,BookID=2021},
            new Enrollment{AuthorID=3,BookID=1050},
            new Enrollment{AuthorID=4,BookID=1050},
            new Enrollment{AuthorID=4,BookID=4022},
            new Enrollment{AuthorID=5,BookID=4041},
            new Enrollment{AuthorID=6,BookID=1045},
            new Enrollment{AuthorID=7,BookID=3141},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}