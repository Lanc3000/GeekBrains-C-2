using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_05_HW
{
    class Doubler
    {
        private int current = 1;
        private int count = 0;
        public int Finish { get; private set; }
        Stack<int> history = new Stack<int>();

        public int Current { get { return current; } }
        public int Count { get { return count; } }
        public int Steps
        {
            get
            {
                int fin = Finish;
                int i = 0;
                while(fin != 1)
                {
                    fin = fin % 2 == 0 ? fin / 2 : fin - 1;
                    i++;
                }
                return i;
            }
        }
        public Doubler()
        {
            Finish = new Random().Next(10, 101);
        }
        public Doubler(int finish)
        {
            this.Finish = finish;
        }
        public Doubler(int min, int max)
        {
            Finish = new Random().Next(min, max + 1);
        }
        public int Plus()
        {
            history.Push(current);
            current++;
            return current;
        }
        public int Multi()
        {
            history.Push(current);
            current *= 2;
            return current;
        }
        public void Reset()
        {
            current = 1;
            history.Clear();
            count = 0;
        }
        public int Back()
        {
            if (history.Count != 0)
                return history.Pop();
            else
                return 1;
        }
        public override string ToString()
        {
            return current.ToString();
        }
    }
}
