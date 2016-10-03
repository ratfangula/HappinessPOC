using HappinessPOC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappinessPOC.Data
{
    public class HappinessContext: DbContext
    {
        public HappinessContext():base("DefaultConnection")
        {
                
        }
        public DbSet<HappyItem> HappyItems { get; set; }
    

    }
}
