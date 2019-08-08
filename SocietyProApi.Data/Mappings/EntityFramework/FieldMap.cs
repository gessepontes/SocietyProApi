using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocietyProApi.Domain.Entities;

namespace SocietyProApi.Data.Mappings.EntityFramework
{
    public class FieldMap : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("CAMPO");

            builder.HasOne(p => p.Pessoa)
                .WithMany(p => p.Field)
                .HasForeignKey(p => p.IDPESSOA);
        }
    }
}
