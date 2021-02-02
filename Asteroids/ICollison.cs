using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    interface ICollison
    {
        Rectangle Rect { get; } // область столкновения

        bool Collision(ICollison obj);
    }
}
