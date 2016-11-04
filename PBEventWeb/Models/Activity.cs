using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBEventWeb.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string Tittle { get; set; }
        public string Text { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public int PlaceID { get; set; }
        public int EventID { get; set; }
        public bool Gameable { get; set; }

        public Place Place { get; set; }
        public Event Event { get; set; }


    }
}