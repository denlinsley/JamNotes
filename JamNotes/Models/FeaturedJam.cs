using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JamNotes.Models
{
    public class FeaturedJam
    {
        public int FeaturedJamID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DatePublished { get; set; }
        public string Content { get; set; }
    }
}