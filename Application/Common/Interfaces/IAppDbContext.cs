using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRepository
    {
        DbSet<Room> Rooms { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Instructor> Instructors { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
