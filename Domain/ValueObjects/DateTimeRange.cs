using Domain.Common;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    [Owned]
    public class DateTimeRange 
    {
        public DateTimeRange() { }
        public DateTimeRange(DateTime start ,DateTime end)
        {
            if (DateTime.Compare(start,end).Equals(1) || DateTime.Compare(start, end).Equals(0))
            {
                Exception ex = new Exception("start date shouldn't be greater than end date" );
                throw new InvalidDateTimeRange(start, end, ex);
            }
            Start = start;
            End = end;
        }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
       
    }
}
