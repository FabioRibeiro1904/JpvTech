using JpvTech.Domain.Entities;
using JpvTech.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace JpvTech.Infra.Context
{
    public class DataContext:DbContext
    {   
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pessoa>().ToTable("Pessoa");


            //modelBuilder.Entity<Pessoa>().HasKey(x => x.Id);

            //modelBuilder.Entity<Pessoa>().Property(x => x.Nome)
            //    .HasColumnType("varchar(60)")
            //    .IsRequired();

            //modelBuilder.Entity<Pessoa>().Property(x => x.Nascimento).IsRequired();

            //modelBuilder.Entity<Pessoa>().Property(x => x.Renda)
            //    .HasColumnType("decimal(18,2)")
            //    .IsRequired();

            //modelBuilder.Entity<Pessoa>().Property(x => x.Cpf).HasColumnType("varchar(11")
            //    .IsRequired();

            modelBuilder.ApplyConfiguration(new PessoaMapping());

        }
    }
}
