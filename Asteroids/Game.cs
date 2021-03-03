using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        public static ulong Timer { get; private set; } = 0;

        static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer { get; private set; }
        public static Random Random { get; } = new Random();
        public static int Width { get; private set; }
        public static int Height { get; private set; }

        public static int Health { get; private set; } = 100;
        public static int Score { get; private set; } = 0;

        public static int CountOfMeteors { get; private set; } = 10;

       public static Image background = Image.FromFile("images\\fon.jpg");

        static Timer timer = new Timer();

        public static BaseObject[] objes;
        public static List<Meteors> meteorsList;
        public static List<Bullet> bulletsList;
        public static Ship ship;
        public static RepairTool repairTool;
        static Game()
        {

        }
        static public void Init(Form form)
        {
            Graphics g; //графическое устройство для вывода графики
            context = BufferedGraphicsManager.Current;//предоставляет доступ к главному буферу графического контекста для текулщего прилоджения
            g = form.CreateGraphics(); //создаем объект - поверхнгость рисования и связываем его с формой
            if (form.ClientSize.Width > 1000 || form.ClientSize.Height > 1000 || form.ClientSize.Width < 0 || form.ClientSize.Height < 0)
                throw new ArgumentOutOfRangeException("Недопустимый диапазон ширины или высоты!");
            else {
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
            }

            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));//связываем буфер с граф.объектом, чтобы рисовать в буфере
            timer.Interval = 50;
            timer.Tick += Timer_Tick; ;
            timer.Start();
            Load();
            form.FormClosing += Form_FormClosing;
            form.KeyDown += Form_KeyDown;
            form.MouseMove += Form_MouseMove;
        }

        private static void Form_MouseMove(object sender, MouseEventArgs e)
        {
            ship.SetPos(e.Location);
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
            if (e.KeyCode == Keys.Space) 
                bulletsList.Add(new Bullet(new Point(ship.GetPos.X + 10, ship.GetPos.Y), new Point(
                 5, 0), new Size(10, 5)));
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Game.Draw();
            Game.Update();
        }

        static void Load()
        {
            ship = new Ship(new Point(0, 400), new Point(5, 5), new Size(10, 10));
            repairTool = new RepairTool(new Point(Width, Random.Next(0, Height)), new Point(5, 5), new Size(10, 10));
            objes = new BaseObject[10];

            bulletsList = new List<Bullet>();

            meteorsList = new List<Meteors>(CountOfMeteors);

            for(int i = 0; i < CountOfMeteors; i++)
            {
                meteorsList.Add(new Meteors(new Point(Width, Random.Next(0, Height)), new Point(-i, i), new Size(20, 20)));
            }
            for (int i = 0; i < 10; i++)
            {
                objes[i] = new Star(new Point(Width, Random.Next(0, Height)), new Point(-i, 0 ), new Size(20, 20));
            }

        }
        public static void Draw()
        {
            Buffer.Graphics.DrawImage(background, 0, 0);
            Buffer.Graphics.DrawString("Health: " + Health.ToString(), SystemFonts.DefaultFont, Brushes.Red, 0, 0);
            Buffer.Graphics.DrawString("Score: " + Score.ToString(), SystemFonts.DefaultFont, Brushes.White, 100, 0);
            
            foreach(var el in objes)
                el.Draw();

            foreach (var el in meteorsList)
                el.Draw();

            foreach (var el in bulletsList)
                el.Draw();
            
            ship.Draw();
            repairTool.Draw();
            Buffer.Render();
        }
        public static void Update() //TODO: разделить логику на методы - слишком большой метод
        {

            foreach (var el in objes)
                el.Update();

            foreach (var el in bulletsList)
                el.Update();

            for (int i = 0; i < meteorsList.Count; i++) //хотел сделать с двумя foreach - 
            {                                           // компилятор заругался на проблемы с коллекциями
                meteorsList[i].Update();

                if (meteorsList[i].Collision(ship))
                {
                    Health -= 10;
                    meteorsList[i].CollisionUpdate();
                }

                for(int j = 0; j < bulletsList.Count; j++) {

                    if (i >= 0 && meteorsList[i].Collision(bulletsList[j]))
                    {
                        
                        meteorsList.RemoveAt(i);
                        i--;
                        bulletsList.RemoveAt(j);
                        j--;
                        Score += 10;
                    }
                    if (meteorsList.Count == 0)
                    {
                        CountOfMeteors++;
                        meteorsList = new List<Meteors>(CountOfMeteors);

                        for (int k = 0; k < CountOfMeteors; k++)
                        {
                            meteorsList.Add(new Meteors(new Point(Width, Random.Next(0, Height)), new Point(-k, k), new Size(20, 20)));
                        }
                    }
                }
            }
  
            if(repairTool.Collision(ship))
            {
                Health += 10;
                repairTool.CollisionUpdate();
            }
            repairTool.Update();
            //bullet?.Update(); // if(bullet != null) bullet.Update();
            
        }
    }
}
