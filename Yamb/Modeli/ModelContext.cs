using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamb.Modeli
{
    class ModelContext : DbContext
    {
        public ModelContext() :
            base(@"Data Source=(localdb)\LocalDb;Initial Catalog=Yamb;Integrated Security=True;Connect Timeout=30;")
           
            {

            }


        public DbSet<Igrac> Igraci { get; set; }
    }
}
