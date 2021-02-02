using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class GameObjectException: Exception
    {
        public Size Value { get; set; }
        public GameObjectException(string message, Size size): base(message)
        {
            Value = size;
        }
    }
}
