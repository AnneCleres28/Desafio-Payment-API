using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Infra.Context
{
    public class PottencialContext : DbContext
    {
        public PottencialContext(DbContextOptions<PottencialContext> options) : base(options)
        {

        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Item> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<int[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(
                            val => int.Parse(val)).ToArray());
            modelBuilder.Entity<Venda>().Property(e => e.Itens).HasConversion(converter);
        }  
    }
}