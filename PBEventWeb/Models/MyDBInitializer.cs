using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PBEventWeb.Models
{
    public class MyDBInitializer : DropCreateDatabaseAlways<MyDBContext>
    {
        protected override void Seed(MyDBContext context)
        {
            base.Seed(context);
        }
    }
}