using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BiblioWebServicesCore.Model;

namespace BiblioWebServicesCore.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        public IRepository Books { get; set; } 

        public BooksController(IRepository books)
        {
            Books =books;
           // Books.Add(new Book{Title="tpmp",Autor="hanouna",Typebook=Type.humour });
        }
        
        // GET api/books
        [HttpGet]
        public ActionResult GetAll()
        {
            
            List<Book> list = Books.GetAll().ToList();

            return Json(Books.GetAll().ToList());
           //return Json(new { foo = "bar", baz = "Blech" });  
            //return Content("<xml>This is poorly formatted xml.</xml>", "text/xml");
        }

        // GET api/books/Search
        [HttpGet("{search}")]
        public IActionResult GetBook(string search ,[Bind(Prefix ="query")] string chaine)
        {
           
            //return new ObjectResult(Books.Find(id)); 
           return  Json(Books.GetAll().Where(a => (a.Title).StartsWith(chaine,StringComparison.OrdinalIgnoreCase)).Select(p=>new {id = p.Key ,label = p.Title } ));
        }
        // GET api/books/GetBookType
        [HttpGet("{GetBookType}")]
        public IActionResult GetBookTypes()
        {

            //return List of BookTypes for select tag; 
            return Json(Books.GetTypes());
        }
        //add book
        // POST api/books
        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
          

            if (book==null)
            {

                BadRequest();

            }
           
            Books.Add(book);

            return Ok(book);
            //return Json(new { key = book.Key , title = book.Title, autor = book.Author,type=book.Types.ToString() }); 

        }
        // POST api/books/Note
        [HttpPost("{Note}")]
        public IActionResult Note([FromBody] Book book)
        {


            if (book == null)
            {

                BadRequest();

            }

            Books.Add(book);

            return Ok(book);
            //return Json(new { key = book.Key , title = book.Title, autor = book.Author,type=book.Types.ToString() }); 

        }
        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]bool isread)
        {
            Books.Update(id,isread);
            
            return Ok("OK");
        }
        [HttpPut]
        public void Update([FromBody]Book book)
        {
            Books.Update(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            
            string[] myids =id.Split('+');
            long[] mykeys = new long[myids.Count()-1];
            for (int i = 1 ; i < myids.Count();i++ )
            {
                mykeys[i-1] = int.Parse(myids[i]);
            }
            Books.Remove(mykeys);
            return mykeys.Count();
        }
    }
}
