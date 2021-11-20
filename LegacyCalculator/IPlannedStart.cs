using System;

namespace LegacyCalculatorTask
{
   public interface IPlannedStart
   {
      public DateTime StartTime { get; set; }
      public int Count { get; set; }
   }
}
