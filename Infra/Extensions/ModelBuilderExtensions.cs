using Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Infra.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyGlobalStandards(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(BaseEntity.Id):
                            property.IsKey();
                            break;
                        case nameof(BaseEntity.UpdatedDate):
                            property.IsNullable = true;
                            break;
                        case nameof(BaseEntity.CreatedDate):
                            property.IsNullable = false;
                            property.SetColumnType("datetime");
                            property.SetDefaultValueSql("CURRENT_TIMESTAMP");
                            break;
                    }
                }
            }

            return builder;
        }
    }
}
