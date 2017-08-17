using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.STrace.Environment
{
    public class ColorHelper
    {
        public static double Difference(Color a, Color b)
        {
            return Math.Sqrt(Math.Pow(b.R - a.R, 2) + Math.Pow(b.G - a.G, 2) + Math.Pow(b.B - a.B, 2));
        }
    }
}
