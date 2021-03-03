using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    abstract class BaseObject: ICollison
    {
        protected Point Pos { get; set; }
        protected Point Dir { get; set; } //направление в виде смещения по х и у
        protected Size Size { get; set; }

        public Rectangle Rect => new Rectangle(Pos, Size);

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
        public abstract void Draw();
        public abstract void Update();
        public abstract void CollisionUpdate();

        public bool Collision(ICollison obj)
        {
            return this.Rect.IntersectsWith(obj.Rect);
        }
    }
    class Star: BaseObject 
    {
        static Image Image { get; } = Image.FromFile("images\\star.png");
        public Star(Point pos, Point dir, Size size):  base(pos, dir, size)
        {
            
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 20, 20);
        }
        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            if (Pos.X < -Size.Width)
            {
                Pos = new Point(Game.Width, Game.Random.Next(0, Game.Height));
            }
        }

        public override void CollisionUpdate(){}
    }
    class Meteors : BaseObject {
        static Image Image { get; } = Image.FromFile("images\\meteor.png");
        public Meteors(Point pos, Point dir, Size size): base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }
        public override void Update() {
            Pos = new Point(Pos.X + Dir.X, Pos.Y + Dir.Y);
            if (Pos.X< 0 || Pos.X> Game.Width)
                Dir = new Point(-Dir.X, Dir.Y);
            if (Pos.Y< 0 || Pos.Y> Game.Height)
                Dir = new Point(Dir.X, -Dir.Y);
        }
        
        public override void CollisionUpdate()
        {
            Pos = new Point(Pos.X, Game.Random.Next(0, Game.Height));
        }
    }
    class Bullet : BaseObject {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void CollisionUpdate()
        {
            Pos = new Point(0, Game.Random.Next(0, Game.Height));
        }

        public override void Draw()
        {
            // Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 20, 20);
            Game.Buffer.Graphics.FillRectangle(Brushes.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            if (Pos.X > Game.Width)
            {
                Pos = new Point(0, Game.Random.Next(0, Game.Height));
            }

        }
    }
}
