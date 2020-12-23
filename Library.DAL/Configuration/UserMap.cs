using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DAL.Configuration
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Oib).HasMaxLength(11).IsRequired();
            builder.Property(u => u.DateOfBirth).IsRequired();
            builder.Property(u => u.JoinDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
