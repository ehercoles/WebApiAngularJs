using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAngularJs.Models;

namespace WebApiAngularJs.Controllers
{
    public class BookController : ApiController
    {
        BookDbContext db = new BookDbContext();

        // GET api/book  
        [ActionName("get"), HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return db.Books.ToList();
        }
        // GET api/book/5  
        public Book Get(int id)
        {
            return db.Books.Find(id);
        }
        // POST api/book  
        public HttpResponseMessage Post(Book model)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(model);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // PUT api/book/5  
        public HttpResponseMessage Put(Book model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        // DELETE api/book/5  
        public HttpResponseMessage Delete(int id)
        {
            Book emp = db.Books.Find(id);
            if (emp == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Books.Remove(emp);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, emp);
        }
    }
}
