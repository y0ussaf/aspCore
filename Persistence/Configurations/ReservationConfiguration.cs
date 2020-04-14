using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.ReservationId).HasColumnName("ReservationID");
            builder.HasOne(r => r.Course)
                    .WithMany()
                    .HasForeignKey(r => r.CourseId);
            builder.HasOne(r => r.Instructor)
                    .WithMany()
                    .HasForeignKey(r => r.InstructorId);
            builder.HasOne(r => r.Room)
                    .WithMany()
                    .HasForeignKey(r => r.RoomId);

            builder.OwnsOne(r => r.DateTimeRange).Property(a => a.Start).HasColumnName("StartDate");
            builder.OwnsOne(r => r.DateTimeRange).Property(a => a.End).HasColumnName("EndDate");
          



        }
    }
}
