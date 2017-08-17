using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.STrace.Base
{
    public class Vector
    {
        public Coords2D Origin { get; set; }
        public Coords2D Destination { get; set; }
        public Direction Direction { get; set; }
    }
}
