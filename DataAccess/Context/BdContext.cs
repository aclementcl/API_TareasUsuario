using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataAccess.Context
{
    public class BdContext: DbContext, IBdContext
    {
        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        public int SaveChanges(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
