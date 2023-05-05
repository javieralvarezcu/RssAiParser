using RssAiParser.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssAiParser.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DebugDataBase")
        {
        }

        public DbSet<OriginalNew> OriginalNews { get; set; }
        public DbSet<ParsedNew> ParsedNews { get; set; }
    }
}
