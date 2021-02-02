using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Ship : BaseObject
    {
        static Image Image { get; } = Image.FromFile("images\\ship.png");
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            if (size.Width == 0 || size.Height == 0)
                throw new GameObjectException("Нельзя установить нулевой размер корабля", size);
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }

        public void Up()
        {
            Pos = new Point(Pos.X, Pos.Y - Dir.Y);
        }
        public void Down()
        {
            Pos = new Point(Pos.X, Pos.Y + Dir.Y);
        }
        
        public override void Update()
        {
            
        }
        //TODO 
        public override void CollisionUpdate()
        {
            
        }
    }
}
