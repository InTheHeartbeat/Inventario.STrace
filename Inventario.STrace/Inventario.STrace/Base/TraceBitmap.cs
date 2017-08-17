using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.STrace.Base
{
    public class TraceBitmap
    {
        public int Width => bitmap.Width;
        public int Height => bitmap.Height;

        public Color[,] ColorMap { get; set; }

        private readonly Bitmap bitmap;
        private BitmapData bitmapData;        

        public TraceBitmap(Bitmap bmp)
        {
            bitmap = bmp;
            ColorMap = new Color[Width, Height];
            Initialize();
        }

        private void Initialize()
        {
            bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite,
                bitmap.PixelFormat);

            unsafe
            {
                byte* line = (byte*) bitmapData.Scan0;
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        byte* pos = line + x * 3;
                        ColorMap[x, y] = Color.FromArgb(pos[0], pos[1], pos[2]);
                    }
                    line += bitmapData.Stride;
                }
            }

            bitmap.UnlockBits(bitmapData);
        }

        public bool InRange(Coords2D pos) => pos.X >= 0 && pos.Y >= 0 && pos.X < Width && pos.Y < Height;

        public Color this[int x, int y] => ColorMap[x, y];
    }
}
