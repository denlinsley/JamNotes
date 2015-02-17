using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JamNotes.Models
{
    public class SingleUserViewModel
    {
        public string UserName { get; set; }
        public string Band { get; set; }
        public string Song { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ShowDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string Link { get; set; }


        public List<Note> Notes { get; set; }
    }
}