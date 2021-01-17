using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProvaTecnica.Models
{
    public class Context: DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public System.Data.Entity.DbSet<ProvaTecnica.Models.Log> Logs { get; set; }
    }
}