using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyProApi.Domain.Entities;

namespace SocietyProApi.Data.Mappings.EntityFramework
{
    public class ChampionshipMap : IEntityTypeConfiguration<Championship>
    {
        public void Configure(EntityTypeBuilder<Championship> builder)
        {
            builder.ToTable("Campeonato");

            builder.HasOne(p => p.Field)
                .WithMany(p => p.Championship)
                .HasForeignKey(p => p.iCodCampo);

        }
    }
}
