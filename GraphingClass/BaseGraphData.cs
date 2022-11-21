using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphingClass
{
    internal class BaseGraphData
    {
        public int Yaxis { get; set; } = 0;
        public int Xaxis { get; set; } = 0;
        public int[] pointArray { get; set; }
        public Color lineColor { get; set; }
        public int lineSize     { get; set; }
        public bool newGraph { get; set; } = true;

        private const int pointArrayLength = 1000;

        //things we want to keep together are kept in the class

        //default constructor
        public BaseGraphData()
        {

        }
        //constructor
        public BaseGraphData(
            int Yaxis,
            int Xaxis,
            Color lineColor,
            int lineSize,
            bool newGraph)
        {
            //items passed to constructor are assigned to local class values
            this.Yaxis = Yaxis;
            this.Xaxis = Xaxis;
            pointArray = new int[pointArrayLength];
            this.lineColor = lineColor;
            this.lineSize = lineSize;
        }
    }
}
