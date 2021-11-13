using System.Collections.Generic;
using Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfigurations
{
    internal class SageConfig : IEntityTypeConfiguration<Sage>
    {
        public void Configure(EntityTypeBuilder<Sage> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.HasMany<Book>(s => s.Books)
                .WithMany(b => b.Sages)
                .UsingEntity(j => j.ToTable("SageBook"));
        }
    }
}