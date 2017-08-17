using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.STrace.Base
{
    public class Coords2D
    {       
        public int X { get; set; }
        public int Y { get; set; }

        public Coords2D()
        {
            
        }

        public Coords2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            Coords2D coords = (Coords2D) obj;
            return coords.X == X && coords.Y == Y;
        }

        public static Coords2D operator+(Coords2D a, Coords2D b) => new Coords2D(a.X+b.X,a.Y+b.Y);
    }
}
