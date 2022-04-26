#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPWebpage.Models;

namespace ASPWebpage.Data
{
    public class ASPWebpageApplicationDbContext : DbContext
    {
        public ASPWebpageApplicationDbContext (DbContextOptions<ASPWebpageApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ASPWebpage.Models.Asp> Asp { get; set; }
    }
}
