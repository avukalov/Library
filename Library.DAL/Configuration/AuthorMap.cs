using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DAL.Configuration
{
    public class AuthorMap : BaseEntityMap<AuthorEntity>
    {
        public override void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            base.Configure(builder);

            builder.HasKey(a => a.AuthorId);
            builder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Country).HasMaxLength(50).IsRequired();

        }
    }
}
