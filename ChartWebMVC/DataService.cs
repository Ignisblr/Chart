using ChartWebMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartWebMVC
{
    public class DataService
    {
        static int _function = 0;

        static List<Point> points = new List<Point>();

        public static void DefineFunction(ChartData values)
        {
            while (values.minRange < values.maxRange + 1)
            {
                _function = values.higherCoef * (int)Math.Pow(values.minRange, 2) + values.lowerCoef * values.minRange + values.freeCoef;
                points.Add(new Point(values.minRange, _function));
                values.minRange++;
            }
        }

        public static void DefineFunction(int higherCoef, int lowerCoef, int freeCoef, int minRange, int maxRange)
        {
            while (minRange < maxRange + 1)
            {
                _function = higherCoef * (int)Math.Pow(minRange, 2) + lowerCoef * minRange + freeCoef;
                points.Add(new Point(minRange, _function));
                minRange++;
            }
        }

        public static string GetValues()
        {
            string json = "[\n";
            foreach (Point point in points)
            {
                if (!Equals(points.IndexOf(points.Last()), points.IndexOf(point)))
                    json += String.Format("{0}, \n", JsonConvert.SerializeObject(point));
                else { json += String.Format("{0} \n]", JsonConvert.SerializeObject(point)); }
            }
            points = new List<Point>();
            return json;
        }
    }
}
