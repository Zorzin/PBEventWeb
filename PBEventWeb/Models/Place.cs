using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBEventWeb.Models
{
    public class Place
    {

        public int PlaceID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}