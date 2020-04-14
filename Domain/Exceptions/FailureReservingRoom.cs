using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
   public class FailureReservingRoom : Exception
    {
        public FailureReservingRoom(string message) : base(message)
        {
        }
    }
}
