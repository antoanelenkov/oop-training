using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Data.Utils
{
    internal static class RandomGenerator
    {
        private static Random  gen = new Random();

        internal static DateTime GetDate()
        {
            var startDate = DateTime.Now.AddHours(-4);
            int range = 24;
            return startDate.AddHours(gen.Next(range));
        }

        internal static string GetEventName()
        {
            return $"EventName_{GetString()}";
        }

        internal static string GetSelectionName()
        {
            return $"Selection_{GetString()}";
        }

        internal static string GetMarketName()
        {
            return $"Market_{GetString()}";
        }

        internal static string GetSportName()
        {
            return $"Sport_{GetString()}";
        }

        internal static string GetLeagueName()
        {
            return $"League_{GetString()}";
        }

        internal static bool GetBooleanStatus()
        {
            return gen.Next(10) > 5;
        }

        internal static double GetDouble()
        {
            return gen.Next(10) + gen.NextDouble();
        }

        private static string GetString(int length = 5)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[gen.Next(s.Length)]).ToArray());
        }

        public static T GetRandomElement<T>(IList<T> elements)
        {
            return elements[gen.Next(elements.Count)];
        }
    }
}
