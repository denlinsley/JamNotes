using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JamNotes.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public int UserID { get; set; }
        public int BandID { get; set; }
        public int SongID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ShowDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string Link { get; set; }

        public virtual User User { get; set; }
        public virtual Band Band { get; set; }
        public virtual Song Song { get; set; }
    }
}