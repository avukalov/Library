using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL.Configuration
{
    public class AuthorBookMap : BaseEntityMap<AuthorBookEntity>
    {
        public override void Configure(EntityTypeBuilder<AuthorBookEntity> builder)
        {
            base.Configure(builder);

            builder.HasKey(ab => new { ab.AuthorId, ab.BookId });

            builder
                .HasOne(ab => ab.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ab => ab.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
