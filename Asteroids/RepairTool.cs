using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class RepairTool : BaseObject
    {
        Image Image { get; } = Image.FromFile("images\\health.png");
        public RepairTool(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y + Dir.Y);
            if (Pos.X < 0 || Pos.X > Game.Width)
                Dir = new Point(-Dir.X, Dir.Y);
            if (Pos.Y < 0 || Pos.Y > Game.Height)
                Dir = new Point(Dir.X, -Dir.Y);
        }

        public override void CollisionUpdate()
        {
            Pos = new Point(Game.Width, Game.Random.Next(0, Game.Height));
        }
    }
}
