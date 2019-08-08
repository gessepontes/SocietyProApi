using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyProApi.Domain.Entities;

namespace SocietyProApi.Data.Mappings.EntityFramework
{
    public class InscriptionMap : IEntityTypeConfiguration<Inscription>
    {
        public void Configure(EntityTypeBuilder<Inscription> builder)
        {
            builder.ToTable("Inscrito");

            builder.HasOne(p => p.Team)
                .WithMany(p => p.Inscriptions)
                .HasForeignKey(p => p.IDTime);


            builder.HasOne(p => p.Championship)
                .WithMany(p => p.Inscriptions)
                .HasForeignKey(p => p.IDCampeonato);
        }
    }
}
