using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JamNotes.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public int BandID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}