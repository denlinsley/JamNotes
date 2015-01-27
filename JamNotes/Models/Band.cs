using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JamNotes.Models
{
    public class Band
    {
        public int BandID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}