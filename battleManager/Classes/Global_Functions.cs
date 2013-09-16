using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleManager.Classes
{
    static class Global_Functions
    {
        static double Div180byPi = 180 / Math.PI;

        public static double RadiansToDegrees(double rads)
        {
            return rads * Div180byPi;
        }

    }
}