﻿using Chapter_TURMA14.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Chapter_TURMA14.Contexts
{
    public class Sqlcontext : DbContext
    {
        public Sqlcontext() { }
        public Sqlcontext(DbContextOptions<Sqlcontext> options) : base(options) { }
        // vamos utilizar esse método para configurar o banco de dados
        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
                //optionsBuilder.UseSqlServer("Data Source = DESKTOP-3PMVSMI\\SQLEXPRESS; initial catalog = Chapter; user id = sa; password = 123");
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-OBVK7HE; initial catalog = Chapter; Integrated Security = true; TrustServerCertificate=True");
                //optionsBuilder.UseSqlServer("Data Source = DESKTOP-OBVK7HE; initial catalog = Chapter; Integrated Security = true");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro> Livros { get; set; }

    }



}





