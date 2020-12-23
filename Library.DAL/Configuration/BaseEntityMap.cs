using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DAL.Configuration
{
    public class BaseEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(b => b.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.UpdatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
