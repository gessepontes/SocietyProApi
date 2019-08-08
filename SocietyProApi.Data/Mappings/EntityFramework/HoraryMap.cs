using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyProApi.Domain.Entities;

namespace SocietyProApi.Data.Mappings.EntityFramework
{
    public class HoraryMap : IEntityTypeConfiguration<Horary>
    {
        public void Configure(EntityTypeBuilder<Horary> builder)
        {
            builder.ToTable("HORARIOPADRAO");

            builder.HasOne(p => p.FieldItem)
                .WithMany(p => p.Horarys)
                .HasForeignKey(p => p.IDITEMCAMPO);
        }
    }
}
