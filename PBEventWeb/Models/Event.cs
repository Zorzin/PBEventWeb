using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PBEventWeb.Models
{
    public class Event
    {
        //[Key]
        public int EventID { get; set; }
        public string Tittle { get; set; }
        public string Text { get; set; }
        public bool Active { get; set; }
        public bool Viewable { get; set; }
        public int GameID { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<PhotoEvent> PhotoEvents { get; set; }
        public virtual Game Game { get; set; }
    }
}