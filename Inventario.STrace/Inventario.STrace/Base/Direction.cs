using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.STrace.Base.Enums;

namespace Inventario.STrace.Base
{
    public class Direction
    {
        public static readonly List<Coords2D> Directions = new List<Coords2D>()
        {
            new Coords2D() {X = 1, Y = 0},
            new Coords2D() {X = 0, Y = -1},
            new Coords2D() {X = -1, Y = 0},
            new Coords2D() {X = 0, Y = 1},

            /*new Coords2D() {X = 1, Y = -1},
            new Coords2D() {X = 1, Y = 1},
            new Coords2D() {X = -1, Y = 1},
            new Coords2D() {X = -1, Y = -1}*/
        };

        public Coords2D DirectionCoords { get; set; }

        public Direction()
        {
            
        }
    }
}
