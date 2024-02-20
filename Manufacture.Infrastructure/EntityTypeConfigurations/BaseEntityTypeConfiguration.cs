using Manufacture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manufacture.Infrastructure.EntityTypeConfigurations;

public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        // Общая конфигурация для всех сущностей
        builder.HasKey("Id");
        builder.HasIndex("Id").IsUnique();
        builder.Property("CreatedBy").HasMaxLength(20);
        builder.Property("CreatedDateTime").IsRequired();
        builder.Property("UpdatedBy").HasMaxLength(20);
        builder.Property("UpdatedDateTime");
    }
}