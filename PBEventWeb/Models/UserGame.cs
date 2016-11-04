using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PBEventWeb.Models
{
    public class UserGame
    {
        public int UserGameID { get; set; }

        //[Key]
        //[Column(Order = 0)]
        public int UserID { get; set; }

        //[Key]
        //[Column(Order = 1)]
        public int GameID { get; set; }

        //[Key]
        //[Column(Order = 2)]
        public int Points { get; set; }

        public Game Game { get; set; }
        public User User { get; set; }
    }
}