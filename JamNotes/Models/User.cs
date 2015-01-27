using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JamNotes.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}