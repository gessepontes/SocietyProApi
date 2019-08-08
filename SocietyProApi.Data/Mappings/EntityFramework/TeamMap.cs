using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyProApi.Domain.Entities;

namespace SocietyProApi.Data.Mappings.EntityFramework
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("TIME");

            builder.HasOne(p => p.Pessoa)
                .WithMany(p => p.Teams)
                .HasForeignKey(p => p.IDPESSOA);

        }
    }
}
