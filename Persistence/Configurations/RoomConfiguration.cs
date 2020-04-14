using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(r => r.RoomId).HasColumnName("RoomID");
            builder.HasMany(r => r.Reservations)
                     .WithOne(r => r.Room);
            builder.HasIndex(r => r.Name)
                    .IsUnique();
        }
    }
}
