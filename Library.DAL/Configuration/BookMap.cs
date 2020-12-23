using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.Configuration
{
    public class BookMap : BaseEntityMap<BookEntity>
    {
        public override void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            base.Configure(builder);

            builder.HasKey(b => b.BookId);
            builder.Property(b => b.Title).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Language).HasMaxLength(50).IsRequired();
            builder.Property(b => b.ISBN).HasMaxLength(17).IsRequired();
            builder.Property(b => b.Category).HasMaxLength(25);
            builder.Property(b => b.Genre).HasMaxLength(25);
            builder.Property(b => b.Publisher).HasMaxLength(50);
            builder.Property(b => b.Published);
        }
    }
}
