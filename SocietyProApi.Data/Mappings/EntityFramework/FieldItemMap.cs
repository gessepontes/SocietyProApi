using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyProApi.Domain.Entities;

namespace SocietyProApi.Data.Mappings.EntityFramework
{
    public class FieldItemMap : IEntityTypeConfiguration<FieldItem>
    {
        public void Configure(EntityTypeBuilder<FieldItem> builder)
        {
            builder.ToTable("CAMPOITEM");

            builder.HasOne(p => p.Field)
                .WithMany(p => p.FieldItens)
                .HasForeignKey(p => p.IDCAMPO);
        }
    }
}
