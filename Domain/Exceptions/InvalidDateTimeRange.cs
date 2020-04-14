using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class InvalidDateTimeRange : Exception
    {
         public InvalidDateTimeRange(DateTime start,DateTime end,Exception ex):
            base($"DateTimeRange  \"{start}\" -\"{end}\" is invalid.", ex)
        {

        }
    }
}
