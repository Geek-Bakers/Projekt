using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// This class includes Resource table configuration
/// </summary>

namespace Projekt.Models.Configuration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.NumberOfFile).IsRequired();
            entity.Property(e => e.NumberOfWeek).IsRequired();
            entity.Property(e => e.UserId).IsRequired();
            entity.HasOne(a => a.User)
                  .WithMany(b => b.Resources)
                  .HasForeignKey(b => b.UserId);
        }
    }
}
