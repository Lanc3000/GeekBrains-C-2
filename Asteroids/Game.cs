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

       public static Image background = Image.FromFile("images\\fon.jpg");

        static Timer timer = new Timer();
        public static BaseObject[] objes;
        static Game()
        {

        }
        static public void Init(Form form)
        {
            Graphics g; //графическое устройство для вывода графики
            context = BufferedGraphicsManager.Current;//предоставляет доступ к главному буферу графического контекста для текулщего прилоджения
            g = form.CreateGraphics(); //создаем объект - поверхнгость рисования и связываем его с формой
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));//связываем буфер с граф.объектом, чтобы рисовать в буфере
            timer.Interval = 100;
            //timer.Tick += Timer_Tick;
            timer.Start();
            Load();
        }
        static void Load()
        {
            objes = new BaseObject[20];
            for(int i = 0; i < objes.Length; i++)
            {
                objes[i] = new BaseObject(new Point(i * 10, i * 10), new Point(i, i), new Size(20, 20));
            }
        }
        public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(background, 0, 0);
            //Buffer.Graphics.DrawRectangle(Pens.White, 10, 10, 100, 200);
            foreach(var el in objes)
            {
                el.Draw();
            }
            Buffer.Render();
        }
    }
}
