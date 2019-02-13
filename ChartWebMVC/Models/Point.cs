using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ChartWebMVC.Models
{
    public class Point
    {

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public int? x = null;

        [DataMember(Name = "y")]
        public int? y = null;
    }
}

