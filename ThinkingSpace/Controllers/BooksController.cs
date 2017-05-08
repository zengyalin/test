using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using DAL;
namespace ThinkingSpace.Controllers
{
    public class BooksController : Controller
    {
        private MvcBookStoreEntities db = new MvcBookStoreEntities();

        // GET: Books
        public ActionResult Index()
        {
            BooksService book = new BooksService();
            var books = book.LoadEntites(u=>true);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BooksService book = new BooksService();
            Books books = book.LoadEntites(u=>u.BookId==id).Single();
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Books/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,CategoryId,Title,Price,BookCoverUrl,Authors")] Books books)
        {
            if (ModelState.IsValid)
            {
                BooksService book = new BooksService();
                book.AddEntity(books);                 
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", books.CategoryId);
            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BooksService book = new BooksService();
            Books books = book.LoadEntites(u => u.BookId == id).Single();

            if (books == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", books.CategoryId);
            return View(books);
        }

        // POST: Books/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,CategoryId,Title,Price,BookCoverUrl,Authors")] Books books)
        {
            if (ModelState.IsValid)
            {
                BooksService book = new BooksService();
                book.EditEntity(books);
                //Class1.EditEntity(books);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", books.CategoryId);
            return View(books);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BooksService book = new BooksService();
            Books books = book.LoadEntites(u=>u.BookId==id).Single();
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            BooksService book = new BooksService();
            Books books = book.LoadEntites(u=>u.BookId==id).Single();
            book.DeleteEntity(books);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
