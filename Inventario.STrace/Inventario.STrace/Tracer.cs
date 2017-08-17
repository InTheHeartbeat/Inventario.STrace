using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.STrace.Base;
using Inventario.STrace.Environment;

namespace Inventario.STrace
{
    public class Tracer
    {
        private TraceBitmap patientBitmap;

        public Tracer()
        {
        }

        private void Initialize()
        {
        }

        public TraceMap Trace(TraceBitmap bitmap)
        {
            TraceMap result = new TraceMap();

            if (bitmap == null)
                throw new ArgumentNullException();

            List<Coords2D> processedCoords = new List<Coords2D>();

            Coords2D currentOrigin = SearchOrigin(processedCoords, bitmap, 0, 0);
            processedCoords.Add(currentOrigin);

            Vector currentVector = new Vector() {Origin = currentOrigin};

            while (processedCoords.Count != bitmap.Width * bitmap.Height)
            { // <--------- вот тута брейк!!1!
                /*
                 * запусти и через там секунд 10 поставь брейк вот здесь, 
                 * посмотри колво элементов в processedCoords, их будет 119. 
                 * После этого посмотри на конечную точку currentVector, она будет
                 * 9;10, что соответствует тому что я тебе в телеграмме скинул поймешь крч.
                */ 
                
                foreach (Coords2D dir in Direction.Directions)
                {
                    Coords2D currentPoint = new Coords2D(currentOrigin.X + dir.X, currentOrigin.Y + dir.Y);
                 
                    /*if (Direction.Directions.All(direction => 
                    processedCoords.All(processed => processed.Equals(direction + currentPoint))))
                        return result; // - хард ресет  */
                    if (!bitmap.InRange(currentPoint)) continue;
                    if (processedCoords.Any(wc=>currentPoint.Equals(wc))) continue;
                    if (currentPoint.Equals(currentOrigin)) continue;
                    

                    if (ColorHelper.Difference(bitmap[currentOrigin.X, currentOrigin.Y],
                            bitmap[currentOrigin.X + dir.X, currentOrigin.Y + dir.Y]) <=
                        TracingConfig.ConformityThreshold)
                    {
                        currentVector.Destination = currentPoint;                        
                        currentOrigin = currentPoint;
                        processedCoords.Add(currentPoint);
                        break;
                    }
                    processedCoords.Add(currentPoint);
                }                
            }

            return result;
        }

        private Coords2D SearchOrigin(List<Coords2D> workedCoords, TraceBitmap bitmap, int lastX, int lastY)
        {
            for (int y = lastY; y < bitmap.Height; y++)
            {
                for (int x = lastX; x < bitmap.Width; x++)
                {
                    if (workedCoords.Contains(new Coords2D(x, y))) continue;

                    foreach (Coords2D dir in Direction.Directions)
                    {
                        if (!bitmap.InRange(new Coords2D(x + dir.X, y + dir.Y))) continue;

                        double diff = ColorHelper.Difference(bitmap[x, y], bitmap[x + dir.X, y + dir.Y]);

                        if (diff >= TracingConfig.ContrastThreshold)
                        {
                            return new Coords2D(x + dir.X, y + dir.Y);
                        }
                    }
                }
            }
            return null;
        }
    }
}
