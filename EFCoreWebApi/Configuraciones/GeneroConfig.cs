﻿using EFCoreWebApi.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreWebApi.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {

            //modelBuilder.Entity<Genero>().HasKey(x => x.Id);
            builder.Property(x => x.Nombre).HasMaxLength(150);
        }
    }
}