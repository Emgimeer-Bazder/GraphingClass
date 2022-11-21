using Microsoft.Maui.Graphics.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GraphingClass
{
    internal class LineDrawable : BaseGraphData, IDrawable //inherate stuff, no idea what this does
    {
        private const int numberOfGraphs = 3;
        private string[] colorName = new string[numberOfGraphs] { "Red", "Blue", "DarkGreen" };
        ColorTypeConverter converter = new ColorTypeConverter();
        private int[] lineWidth = new int[numberOfGraphs] {1, 2, 3};
        public BaseGraphData[] lineGraphs = new BaseGraphData[numberOfGraphs];      //makes an array of graphs
        //default constructor because no parameters passed to it
        public LineDrawable() : base()
        {
            for( int i = 0; i < numberOfGraphs; i++)
            {
                lineGraphs[i] = new BaseGraphData
                    (
                    Yaxis: 0,
                    Xaxis: 0,
                    lineSize: lineWidth[i],
                    lineColor: (Color)(converter.ConvertFromInvariantString(colorName[i])),
                    newGraph: true
                    );
            }
                
                
        }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            for(int graphIndex = 0; graphIndex<lineGraphs.Length; graphIndex++)
            {
                Rect lineGraphRect = new(dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height);
                DrawLineGraph(canvas, lineGraphRect, lineGraphs[graphIndex]);
            }
        }

        private void DrawLineGraph(ICanvas canvas, Rect lineGraphRect, BaseGraphData lineGraph)
        {
            if(lineGraph.Xaxis <2)
            {
                lineGraph.pointArray[lineGraph.Xaxis] = lineGraph.Yaxis;
                lineGraph.Xaxis++;
                return;
            }
            else if(lineGraph.Xaxis < 1000)
            {                lineGraph.pointArray[lineGraph.Xaxis] = lineGraph.Yaxis;
                lineGraph.Xaxis++;
            }
            else
            {

                for(int i = 0; i<999;i++)
                {
                    lineGraph.pointArray[i] = lineGraph.pointArray[i + 1];
                }  
                lineGraph.pointArray[999] = lineGraph.Yaxis;
            }                
            for(int i= 0; i< lineGraph.Xaxis -1; i++)        //Xaxis -1 to make sure we do not go past the end point
                {
                    canvas.StrokeColor = lineGraph.lineColor;
                    canvas.StrokeSize = lineGraph.lineSize;
                    canvas.DrawLine(i, lineGraph.pointArray[i], i + 1, lineGraph.pointArray[i + 1]);
                }
        }
    }
}
