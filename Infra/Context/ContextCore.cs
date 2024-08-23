using Domain.Entities;
using Infra.Extensions;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class ContextCore : DbContext
    {
        public ContextCore(DbContextOptions<ContextCore> options) : base(options) { }

        #region "DbSets"

        public DbSet<Produto> Produtos { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyGlobalStandards();

            base.OnModelCreating(modelBuilder);
        }
    }
}
