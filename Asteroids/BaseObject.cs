using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class BaseObject
    {
        protected Point Pos { get; set; }
        protected Point Dir { get; set; } //направление в виде смещения по х и у
        protected Size Size { get; set; }
        public BaseObject()
        {
            Pos = new Point ( 0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);
        }
        public BaseObject(Point pos, Point dir, Size size)
        {
            this.Pos = pos;
            this.Dir = dir;
            this.Size = size;
        }
        public void Draw()
        {
            Game.Buffer.Graphics.FillEllipse
                (Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
