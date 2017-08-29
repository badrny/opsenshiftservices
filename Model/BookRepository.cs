using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BiblioWebServicesCore.Model
{
    public class BookRepository : IRepository
    { 
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
            
            //_context.Database.EnsureCreated();//Creation Database 
            //if (context.Books.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //Add(new Book { Autor = "Moliere",Title="Miserable",Typebook=Type.Amour});
                                   
          

        }
    
        public void Add(Book item)
        {
            _context.Books.Add(item);
            _context.SaveChanges();
          
        }

        public Book Find(long key)
        {
           return _context.Books.Find(key);
        }

        public IEnumerable<Book> GetAll()
        {
            _context.Books.Load();
            _context.Types.Load();
            _context.BookTypes.Load();

            return _context.Books; 
        }
        public IEnumerable<BookType> GetBookTypes()
        {
            return _context.BookTypes;
        }
        public IEnumerable<Type> GetTypes()
        {
            return _context.Types.ToList();
        }

        public void Remove(long []keys)
        {
            foreach (var item in keys)
            {
                var entity = _context.Books.First(t => t.Key == item);
                _context.Books.Remove(entity);
                _context.SaveChanges();
            }
          
        }

        public void Update(Book item)
        {
            _context.Books.Update(item);
            _context.SaveChanges();
        }
        public void Update(int id, bool isread )
        {
            //imperatifly find item to update him
            Book mybook = _context.Books.FirstOrDefault(t => t.Key == id);
            mybook.IsRead = !isread;
            _context.Books.Update(mybook);
            _context.SaveChanges();
        }

    }
}
