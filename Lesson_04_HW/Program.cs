using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
    а) для целых чисел;
    б) *для обобщенной коллекции;
    в) *используя Linq.
 */
namespace Lesson_04_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(23);
            list.Add(40);
            list.Add(12);
            list.Add(-12);
            list.Add(0);
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i] % 2 == 0)
                    dictionary.Add(list[i], )
            }
        }
    }
}
