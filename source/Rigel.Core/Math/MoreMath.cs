using System;
using System.Linq;

namespace Rigel.Core.Math
{
    public static class MoreMath
    {
        public static DateTime Min(DateTime one, DateTime two)
        {
            return new DateTime[] {one, two}.Min();
        }

        public static DateTime Max(DateTime one, DateTime two)
        {
            return new DateTime[] {one, two}.Max();
        }

        public static DateTime Min(params DateTime[] dates)
        {
            return dates.Min();
        }

        public static DateTime Max(params DateTime[] dates)
        {
            return dates.Max();
        }

        public static double ToRadians(double deg)
        {
            return (deg*System.Math.PI/180.0);
        }

        public static double ToDegrees(double rad)
        {
            return (rad/System.Math.PI*180.0);
        }
    }
}