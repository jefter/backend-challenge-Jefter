using desafio.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.data.Base
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options)
        {

        }

        public DesafioContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=desafioDB.db");
        }

        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }

        


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Pedido>().HasKey(m => m.Id);
        //    base.OnModelCreating(builder);
        //}
    }
}
