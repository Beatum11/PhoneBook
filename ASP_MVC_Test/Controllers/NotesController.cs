using Microsoft.AspNetCore.Mvc;
using ASP_MVC_Test.Controllers;
using ASP_MVC_Test.Models;
using ASP_MVC_Test.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_MVC_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private Context context;

        public NotesController(Context Context)
        {
            context = Context;
        }

        // GET: api/<NotesController>
        [HttpGet]
        public List<BookViewModel> Get()
        {
            return context.PhoneNotes.ToList();
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public BookViewModel Get(int id)
        {
            var note = context.PhoneNotes.Where(e => e.Id == id).FirstOrDefault();
            return note;
        }

        // POST api/<NotesController>
        [HttpPost]
        public void Post(BookViewModel note)
        {
            context.PhoneNotes.Add(note);
            context.SaveChanges();
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, BookViewModel note)
        {
            var phoneNote = context.PhoneNotes.Where(e => e.Id == id).FirstOrDefault();
            context.PhoneNotes.Remove(phoneNote);
            context.PhoneNotes.Add(note);
            context.SaveChanges();
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var note = context.PhoneNotes.Where(e => e.Id == id).FirstOrDefault();
            context.PhoneNotes.Remove(note);
            context.SaveChanges();
        }
    }
}
