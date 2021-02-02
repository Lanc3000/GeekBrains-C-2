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

        }

        public override void CollisionUpdate()
        {
            
        }
    }
}
