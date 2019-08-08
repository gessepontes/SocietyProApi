using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyProApi.Domain.Entities;

namespace SocietyProApi.Data.Mappings.EntityFramework
{
    public class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("JOGADOR");

            builder.HasOne(p => p.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.IDTIME);
        }
    }
}
