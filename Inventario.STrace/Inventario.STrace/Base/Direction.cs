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
        public DirectionName Name { get; set; }

        public int Angle => CalcAngle();

        private int CalcAngle()
        {
            switch (Name)
            {
                case DirectionName.Top: return 90;
                case DirectionName.Bottom: return 270;
                case DirectionName.Right: return 0;
                case DirectionName.Left: return 180;
            }
            return 0;
        }
    }
}
