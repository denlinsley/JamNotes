using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JamNotes.Models
{
    public class SingleUserViewModel
    {
        public string UserName { get; set; }
        public List<Note> Notes { get; set; }
    }
}