using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PBEventWeb.Models
{
    public class PhotoEvent
    {
        public int PhotoEventID { get; set; }

        //[Key]
        //[Column(Order = 0)]
        public int PhotoID { get; set; }

        //[Key]
        //[Column(Order = 1)]
        public int EventID { get; set; }
        
        public virtual Event Event { get; set; }
        public virtual Photo Photo { get; set; }
    }
}