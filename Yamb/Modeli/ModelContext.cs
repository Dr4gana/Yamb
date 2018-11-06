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
            base(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Yamb;Integrated Security=True;")
           
            {

            }


        public DbSet<Igrac> Igraci { get; set; }
    }
}
