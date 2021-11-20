using System;
using System.Collections.Generic;
using System.Linq;

namespace LegacyCalculatorTask
{
   public partial class LegacyCalculator
   {
      public IPlannedStart Calculate(List<DateTime> dates, int requiredDaysInFirstWeek = 1)
      {
         PlannedStart plannedStart = new PlannedStart { StartTime = DateTime.MinValue, Count = 0 };

         // check if dates no items then return early
         if (dates.Count == 0)
         {
            return plannedStart;
         }

         dates.Sort((a, b) => a.CompareTo(b));

         DateTime startOfFirstWeek = dates[0];

         DateTime startOfSecondWeek = startOfFirstWeek.AddDays(7); // add a week

         // returns counts for first week.
         int countsForFirstWeek = dates
            .Count(x => x > startOfFirstWeek && x < startOfSecondWeek);

         // returns counts for second week.
         int countsForSecondWeek = dates
            .Count(x => x > startOfSecondWeek && x < startOfSecondWeek.AddDays(7)); // add a week

         if (countsForSecondWeek > countsForFirstWeek && countsForSecondWeek >= requiredDaysInFirstWeek)
         {
            plannedStart = new PlannedStart { StartTime = startOfSecondWeek, Count = countsForSecondWeek };
         }
         return plannedStart;
      }
   }
}
