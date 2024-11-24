using System.Collections.Generic;
using System;

namespace OpenMate.Work.Helpers
{
    public class Helper
    {
        public static double CeelWidth = 164.857;

        public static Dictionary<DayOfWeek, double> DayOfWeekWidth = new Dictionary<DayOfWeek, double>
        {
            { DayOfWeek.Sunday,  0},
            { DayOfWeek.Monday, CeelWidth },
            { DayOfWeek.Tuesday, 2 * CeelWidth },
            { DayOfWeek.Wednesday, 3 * CeelWidth },
            { DayOfWeek.Thursday, 4 * CeelWidth },
            { DayOfWeek.Friday, 5 * CeelWidth },
            { DayOfWeek.Saturday, 6 * CeelWidth }
        };
    }
}
