using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DBConnection
{
    public partial class EmberContext : DbContext
    {
        public EmberContext()
            : base("name=EmberContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        static EmberContext()
        {
            Database.SetInitializer<EmberContext>(null);
        }

    }
}