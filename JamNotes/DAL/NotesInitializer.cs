using JamNotes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;


namespace JamNotes.DAL
{
    public class NotesInitializer : DropCreateDatabaseIfModelChanges<NotesContext>
    //public class NotesInitializer : DropCreateDatabaseAlways<NotesContext>
    {
        protected override void Seed(NotesContext context)
        {
            var bands = new List<Band>
            {
                new Band {Name="Phish"},
                new Band {Name="Grateful Dead"},
                new Band {Name="String Cheese Incident"}
            };
            bands.ForEach(b => context.Bands.Add(b));
            context.SaveChanges(); // not absolutely necessary, but helpful for debugging if these is a problem saving to the Db

            var songs = new List<Song> 
            {
                new Song {Title="Bathtub Gin"},
                new Song {Title="Tweezer"},
                new Song {Title="Scarlet -> Fire"},
                new Song {Title="Dark Star"},
                new Song {Title="Shine"},
                new Song {Title="Climb"}
            };
            songs.ForEach(s => context.Songs.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User {UserName="imatester", Email="ima@dummy.com", DateCreated=System.DateTime.Now, Role="User"},
                new User {UserName="hesatester", Email="hesa@dummy.com", DateCreated=System.DateTime.Now, Role="User"},
                new User {UserName="shesatester", Email="shesa@dummy.com", DateCreated=System.DateTime.Now, Role="User"},
                new User {UserName="admin", Email="admin@dummy.com", DateCreated=System.DateTime.Now, Role="admin"}
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var notes = new List<Note> 
            {
                new Note {UserID=1, BandID=1, SongID=1, ShowDate=DateTime.Parse("1997-08-17"), Description="High-energy uplifting jam", Link=@"http://www.phishtracks.com/shows/1997-08-17/bathtub-gin"},
                new Note {UserID=1, BandID=1, SongID=2, ShowDate=DateTime.Parse("2013-07-31"), Description="The famous 30+ minute Tahoe Tweezer", Link=@"http://www.phishtracks.com/shows/2013-07-31/tweezer"},
                new Note {UserID=2, BandID=2, SongID=3, ShowDate=DateTime.Parse("1977-05-08"), Description="The most perfect version of this combo", Link=@"https://archive.org/details/gd77-05-08.sbd.hicks.4982.sbeok.shnf"},
                new Note {UserID=2, BandID=2, SongID=4, ShowDate=DateTime.Parse("1997-08-17"), Description="An amazing jazzy journey, one of the best ever", Link=@"https://www.youtube.com/watch?v=kf-nX4G5ny0"},
                new Note {UserID=3, BandID=3, SongID=5, ShowDate=DateTime.Parse("2000-05-05"), Description="Closes out an incredible first set at Jazz Fest on a high note", Link=@"https://archive.org/details/sci2000-05-05.tlm170.flac16"},
                new Note {UserID=3, BandID=3, SongID=6, ShowDate=DateTime.Parse("2001-08-01"), Description="Very adventurious version with a great -> to Lonesome Road Blues", Link="https://archive.org/details/sci2001-08-01-dsbd.shnf"}
            };
            notes.ForEach(n => context.Notes.Add(n));
            context.SaveChanges();

            var featuredJams = new List<FeaturedJam>
            {
                new FeaturedJam {Title="The Tahoe Tweezer", Author="Dennis Linsley", DatePublished=DateTime.Parse("2015-01-25"), Content="This is a blog-style post about this jam"}
            };
            featuredJams.ForEach(f => context.FeaturedJams.Add(f));
            context.SaveChanges();
        }
    }
}
