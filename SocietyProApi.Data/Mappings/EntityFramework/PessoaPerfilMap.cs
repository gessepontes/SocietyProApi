using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyProApi.Domain.Entities;

namespace SocietyProApi.Data.Mappings.EntityFramework
{
    public class PessoaPerfilMap : IEntityTypeConfiguration<PessoaPerfil>
    {
        public void Configure(EntityTypeBuilder<PessoaPerfil> builder)
        {
            builder.ToTable("PESSOAPERFIL");

            builder.HasOne(p => p.Pessoa)
                .WithMany(p => p.PessoaPerfis)
                .HasForeignKey(p => p.IDPESSOA);
        }
    }
}
