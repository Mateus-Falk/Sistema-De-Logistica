using Microsoft.EntityFrameworkCore;
using SistemaLogistica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogistica.Infra.Data.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InOut>()
                .ToTable(tb => tb.HasTrigger("TGR_UPDATE_QUANTITY"));

            modelBuilder.Entity<Category>()
                .HasData(
                new {Id = 1, Name = "Suco"},
                new {Id = 2, Name = "Refrigerante"},
                new {Id = 3, Name = "Cerveja"}
                );
        }

        #region DBSets<Tables>
        public DbSet<Person> Person { get; set; }
        public DbSet<InOut> InOut { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        #endregion
    }
}
