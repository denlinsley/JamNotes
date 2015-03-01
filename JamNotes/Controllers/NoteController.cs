using JamNotes.DAL;
using System.Web.Mvc;
using System.Linq;
using JamNotes.Models;
using System;

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

        //// GET: Note/AllNotes
        //public ActionResult AllNotes()
        //{
        //    ViewBag.Heading = "Viewing notes by all users";
        //    return View(db.Notes.ToList()); // same as auto-generated Contoso CRUD contoller Index method
        //}


        // GET: Note/AllNotes
        public ActionResult AllNotes(string sortOrder)
        {
            ViewBag.Heading = "Viewing notes by all users";
            ViewBag.BandSortParm = String.IsNullOrEmpty(sortOrder) ? "band_desc" : "";
            ViewBag.SongSortParm = sortOrder == "Song" ? "song_desc" : "Song";


            var notes = from n in db.Notes
                        select n;

            switch (sortOrder)
            {
                case "band_desc":
                    notes = notes.OrderByDescending(n => n.Band.Name);
                    break;
                case "Song":
                    notes = notes.OrderBy(n => n.Song.Title);
                    break;
                case "song_desc":
                    notes = notes.OrderByDescending(n => n.Song.Title);
                    break;
                default:
                    notes = notes.OrderBy(n => n.Band.Name);
                    break;
            }
            return View(notes.ToList());
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