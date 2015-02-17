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

            var model = new SingleUserViewModel()
            {
                UserName = user.UserName,
                Notes = userNotes.ToList()
            };

            return View(model);
        }


        // GET: Note/AllNotes
        public ActionResult AllNotes()
        {
            ViewBag.Heading = "Viewing notes by all users";
            return View(db.Notes.ToList()); // same as auto-generated Contoso CRUD contoller Index method
        }


        // GET: Note/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Note/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Band,Song,ShowDate,Description,Link")] SingleUserViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                var band = (from b in db.Bands
                            where b.Name == userVm.Band
                            select b).FirstOrDefault<Band>();

                var song = (from s in db.Songs
                            where s.Title == userVm.Song
                            select s).FirstOrDefault<Song>();

                var user = (from u in db.Users
                            where u.UserID == 1 // eventually, UserId will be passed in as a parameter
                            select u).FirstOrDefault<User>();

                Note note = new Note();
                note.UserID = user.UserID;
                note.BandID = band.BandID;
                note.SongID = song.SongID;
                note.ShowDate = userVm.ShowDate;
                note.Description = userVm.Description;
                note.Link = userVm.Link;

                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("MyNotes");
            }

            return View(userVm);
        }
    }
}