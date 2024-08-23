using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
