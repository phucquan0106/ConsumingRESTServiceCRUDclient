using ConsumingRESTServiceCRUD_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsumingRESTServiceCRUD_client.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private MyBookServices.BookServicesClient mbsClient = new MyBookServices.BookServicesClient();

        public ActionResult Index()
        {
            //BookServiceClient bsc = new BookServiceClient();
            //MyBookServices.BookServicesClient mbsClient = new MyBookServices.BookServicesClient();
            ViewBag.listBooks = mbsClient.GetBookList();
            //ViewBag.listBooks = bsc.getAllBook();
            return View();
        }

        public ActionResult AddBook(string Title, string ISBN, string id)
        {
            //MyBookServices.BookServicesClient mbsClient = new MyBookServices.BookServicesClient();
            MyBookServices.Book book = new MyBookServices.Book { Title = Title, ISBN = ISBN };
            mbsClient.AddBook(book, id);
            return RedirectToAction("Index");
        }
        
        public ActionResult GetBookById(string id)
        {
            return View("Detail", mbsClient.GetBookById(id));
        }

        public ActionResult UpdateBook(string Title, string ISBN, string id)
        {
            MyBookServices.Book book = new MyBookServices.Book { Title = Title, ISBN = ISBN, BookId = Convert.ToInt32(id) };
            mbsClient.UpdateBook(book, id);
            return RedirectToAction("Index");
            
        }

        public ActionResult DeleteBook(string id)
        {
            mbsClient.DeleteBook(id);
            return RedirectToAction("Index");

        }

    }
}