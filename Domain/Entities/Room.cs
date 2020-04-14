using Domain.Exceptions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
   public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }
        public void AddReservation(Reservation reservation)
        {
            DateTimeRange dateTimeRange = reservation.DateTimeRange;
            if (this.isAvailableAt(dateTimeRange))
            {
                this.Reservations.Add(reservation);
            }
            else
            {
                // instead of throwing exception we can use here a object of type Result and collect errors and return to the application layer 
                throw new FailureReservingRoom("this room is not available at this time");
            }
        }

        public bool isAvailableAt(DateTimeRange dateTimeRange)
        {
            return !(Reservations.Where(r => r.DateTimeRange.Start <= dateTimeRange.End && dateTimeRange.Start < r.DateTimeRange.End)
                               .Any());

        }
        public void ChangeReservationDate(int reservationId,DateTimeRange newDateTimeRange)
        {
            var reservation = Reservations.Where(r => r.ReservationId == reservationId).First();
            if (this.isAvailableAt(newDateTimeRange))
            {
                reservation.DateTimeRange = newDateTimeRange;
            }
            else
            {
                throw new FailureReservingRoom("this room is not available at this time");

            }
        }
    }
}
