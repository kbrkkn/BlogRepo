namespace BookWorm.Migrations
{
    using BookWorm.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookWorm.DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookWorm.DAL.BlogContext context)
        {
            var authors = new List<Author>
            {
                new Author { FirstMidName = "Carson",   LastName = "Alexander", 
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Author { FirstMidName = "Meredith", LastName = "Alonso",    
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Author { FirstMidName = "Arturo",   LastName = "Anand",     
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Author { FirstMidName = "Gytis",    LastName = "Barzdukas", 
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Author { FirstMidName = "Yan",      LastName = "Li",        
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Author { FirstMidName = "Peggy",    LastName = "Justice",   
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Author { FirstMidName = "Laura",    LastName = "Norman",    
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Author { FirstMidName = "Nino",     LastName = "Olivetto",  
                    EnrollmentDate = DateTime.Parse("2005-08-11") }
            };
            authors.ForEach(s => context.Authors.AddOrUpdate(p => p.LastName, s));
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
            books.ForEach(s => context.Books.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { 
                    AuthorID = authors.Single(s => s.LastName == "Alexander").ID, 
                    BookID = books.Single(c => c.Title == "Chemistry" ).BookID, 
                    
                },
                 new Enrollment { 
                    AuthorID = authors.Single(s => s.LastName == "Alexander").ID,
                    BookID = books.Single(c => c.Title == "Microeconomics" ).BookID, 
                   
                 },                            
                 new Enrollment { 
                    AuthorID = authors.Single(s => s.LastName == "Alexander").ID,
                    BookID = books.Single(c => c.Title == "Macroeconomics" ).BookID, 
                   
                 },
                 new Enrollment { 
                     AuthorID = authors.Single(s => s.LastName == "Alonso").ID,
                    BookID = books.Single(c => c.Title == "Calculus" ).BookID, 
                
                 },
                 new Enrollment { 
                     AuthorID = authors.Single(s => s.LastName == "Alonso").ID,
                    BookID = books.Single(c => c.Title == "Trigonometry" ).BookID, 
                 
                 },
                 new Enrollment {
                    AuthorID = authors.Single(s => s.LastName == "Alonso").ID,
                    BookID = books.Single(c => c.Title == "Composition" ).BookID, 
                    
                 },
                 new Enrollment { 
                   AuthorID = authors.Single(s => s.LastName == "Anand").ID,
                    BookID = books.Single(c => c.Title == "Chemistry" ).BookID
                 },
                 new Enrollment { 
                   AuthorID = authors.Single(s => s.LastName == "Anand").ID,
                    BookID = books.Single(c => c.Title == "Microeconomics").BookID,
                          
                 },
                new Enrollment { 
                    AuthorID = authors.Single(s => s.LastName == "Barzdukas").ID,
                    BookID = books.Single(c => c.Title == "Chemistry").BookID,
                       
                 },
                 new Enrollment { 
                 AuthorID = authors.Single(s => s.LastName == "Li").ID,
                    BookID = books.Single(c => c.Title == "Composition").BookID,
                       
                 },
                 new Enrollment { 
                   AuthorID = authors.Single(s => s.LastName == "Justice").ID,
                    BookID = books.Single(c => c.Title == "Literature").BookID,
                        
                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Author.ID == e.AuthorID &&
                         s.Book.BookID == e.BookID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
