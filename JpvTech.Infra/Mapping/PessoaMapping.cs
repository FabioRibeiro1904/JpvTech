using JpvTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JpvTech.Infra.Mapping
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(x => x.Nascimento).IsRequired();

            builder.Property(x => x.Renda).HasColumnType("decimal(18,2)") ;

            builder.Property(x => x.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();

        }
    }
}
