using Library.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.DAL
{
    public class LibraryDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<AuthorBookEntity> AuthorBook { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<UserEntity>().Property(u => u.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<UserEntity>().Property(u => u.DateOfBirth).IsRequired();
            modelBuilder.Entity<UserEntity>().Property(u => u.Oib).HasMaxLength(11).IsRequired();
            modelBuilder.Entity<UserEntity>().Property(u => u.JoinDate).HasDefaultValue(DateTime.Now).IsRequired();

            //modelBuilder.Entity<BookEntity>().HasKey(b => b.BookId);
            modelBuilder.Entity<BookEntity>().Property(b => b.Title).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<BookEntity>().Property(b => b.Publisher).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<BookEntity>().Property(b => b.Language).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<BookEntity>().Property(b => b.ISBN).HasMaxLength(13).IsRequired();
            modelBuilder.Entity<BookEntity>().Property(b => b.Category).HasMaxLength(25);
            modelBuilder.Entity<BookEntity>().Property(b => b.Genre).HasMaxLength(25);
            modelBuilder.Entity<BookEntity>().Property(b => b.Published);
            modelBuilder.Entity<BookEntity>().Property(a => a.CreatedAt).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<BookEntity>().Property(a => a.UpdatedAt).HasDefaultValue(DateTime.Now);

            //modelBuilder.Entity<AuthorEntity>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<AuthorEntity>().Property(a => a.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<AuthorEntity>().Property(a => a.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<AuthorEntity>().Property(a => a.Country).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<AuthorEntity>().Property(a => a.CreatedAt).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<AuthorEntity>().Property(a => a.UpdatedAt).HasDefaultValue(DateTime.Now);


            modelBuilder.Entity<AuthorBookEntity>().Property(a => a.CreatedAt).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<AuthorBookEntity>().Property(a => a.UpdatedAt).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<AuthorBookEntity>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });

            modelBuilder.Entity<AuthorBookEntity>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ab => ab.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuthorBookEntity>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}