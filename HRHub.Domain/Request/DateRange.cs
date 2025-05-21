using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Domain.Request
{
    public record DateRange
    {
        private DateRange() { }

        public DateOnly Start { get; init; }
        public DateOnly End { get; init; }

        public int LengthInDays => End.DayNumber - Start.DayNumber;

        public static DateRange Create(DateOnly start, DateOnly end, int remainingLeaveDays)
        {

            int requestedDays = end.DayNumber - start.DayNumber;

            if (start > end)
            {
                throw new ApplicationException("End date precedes start date");
            }
            if (requestedDays > remainingLeaveDays)
            {
                throw new ApplicationException("You don't have enough remaining leave days.");
            }
            return new DateRange {
                Start = start,
                End = end
            };
        }
        }
    }
