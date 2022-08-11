using Microsoft.AspNetCore.Mvc;
using ASP_MVC_Test.Models;
using System.Linq;
using ASP_MVC_Test.Data;

namespace ASP_MVC_Test.Controllers
{
    public class TestController : Controller
    {
        private Context context;

        public TestController(Context Context)
        {
            context = Context;
        }

        public IActionResult Index()
        {
            List<BookViewModel> pNotes = context.PhoneNotes.ToList();
            return View(pNotes);
        }

        #region Creating a note
        public IActionResult Create()
        {
            var model = new BookViewModel();
            return View(model);
        }

        public IActionResult CreateNote(BookViewModel bookModel)
        {
            context.PhoneNotes.Add(bookModel);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        #endregion


        /// <summary>
        /// Display note to another page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ShowNote(int id)
        {
            var phoneNote = context.PhoneNotes.Where(e => e.Id == id).FirstOrDefault(); 
            return View(phoneNote);
        }

        /// <summary>
        /// Removing a note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteNote(int id)
        {
            var phoneNote = context.PhoneNotes.Where(e => e.Id == id).FirstOrDefault();
            context.PhoneNotes.Remove(phoneNote);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        #region Editing a note
        public IActionResult Edit(int id)
        {
            var phoneNote = context.PhoneNotes.Where(e => e.Id == id).FirstOrDefault();
            return View(phoneNote);
        }

        public IActionResult EditNote(BookViewModel viewModel, int id)
        {
            var phoneNote = context.PhoneNotes.Where(e => e.Id == id).FirstOrDefault();
            context.PhoneNotes.Remove(phoneNote);
            context.PhoneNotes.Add(viewModel);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
