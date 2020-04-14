using Application.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Reservations.Queries.GetReservationsList
{

   public class ReservationsListVm : Paged
    {
        public ReservationsListVm()
        {
            Reservations = new List<ReservationDto>();
        }

        public List<ReservationDto> Reservations { get; set; }
        public ReservationsListVm(List<ReservationDto> reservations,int count, int pageNumber, int pageSize) : base(count, pageNumber, pageSize)
        {
            Reservations = reservations;
        }
    }
}
