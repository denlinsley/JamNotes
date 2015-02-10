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
            var user = (from u in db.Users
                       where u.UserID == 1 // later, UserId will be passed in as a parameter
                       select u).FirstOrDefault<User>();

            var userNotes = from n in db.Notes
                            where n.UserID == user.UserID
                            select n;

            var model = new SingleUserViewModel() {
                UserName = user.UserName,
                Notes = userNotes.ToList()
            };

            return View(model);
        }

        // GET: Note/AllNotes
        public ActionResult AllNotes()
        {
            ViewBag.Heading = "Viewing notes by all users";
            return View(db.Notes.ToList()); // same as auot-generated Contoso CRUD contoller Index method
        }
    }
}