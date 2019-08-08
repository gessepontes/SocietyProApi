using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyProApi.Domain.Entities;

namespace SocietyProApi.Data.Mappings.EntityFramework
{
    public class HoraryExtraMap : IEntityTypeConfiguration<HoraryExtra>
    {
        public void Configure(EntityTypeBuilder<HoraryExtra> builder)
        {
            builder.ToTable("HORARIOEXTRA");

            builder.HasOne(p => p.FieldItem)
                .WithMany(p => p.HoraryExtras)
                .HasForeignKey(p => p.IDITEMCAMPO);
        }
    }
}
