using JamNotes.DAL;
using System.Web.Mvc;
using System.Linq;
using JamNotes.Models;

namespace JamNotes.Controllers
{
    public class NoteController : Controller
    {
        NotesContext db = new NotesContext();

        // GET: MyNotes
        public ActionResult MyNotes()
        {
            var aNote = (from n in db.Notes
                         where n.UserID == 1
                         select n).FirstOrDefault<Note>();

            return View(aNote);
        }

        // GET: Note/AllNotes
        public ActionResult AllNotes()
        {
            var notes = from n in db.Notes
                        select n;

            return View(notes);


        }
    }
}