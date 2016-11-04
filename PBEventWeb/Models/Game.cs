using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBEventWeb.Models
{
    public class Game
    {
        public int GameID { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<UserGame> UserGames { get; set; }
    }
}