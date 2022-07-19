using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicationTestMacroPay.Models;

namespace AplicationTestMacroPay.Controllers
{
    public class BooksController : Controller
    {
        private readonly testContext _context;

        public BooksController(testContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var lista = new List<DataFull>();
            using (var context = new testContext())
            {
                var query = from a in context.Books
                            join b in context.Ratings on a.Id equals b.BookId
                            join c in context.Reviewers on b.ReviewerId equals c.Id
                            select new DataFull
                            {
                                name = c.Name,
                                title = a.Title,
                                rating = b.Rating1,
                                rating_date = b.RatingDate
                            };
                lista = query.OrderBy(x => x.name).ThenBy(z => z.title).ThenBy(c => c.rating).ToList();
            }
            return View(lista);
        }
    }
}
