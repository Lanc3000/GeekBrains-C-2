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
        public static Dictionary<T, int> dictionary2<T, value>(List<T> list)
        {
            Dictionary<T, int> dictionary = new Dictionary<T, int>();
            foreach (T el in list)
            {
                if (dictionary.ContainsKey(el))
                    dictionary[el]++;
                else
                    dictionary[el] = 1;
            }
            return dictionary;
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(23);
            list.Add(40);
            list.Add(12);
            list.Add(-12);
            list.Add(0);
            list.Add(12);
            list.Add(40);
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                    if (dictionary.ContainsKey(list[i]))
                        dictionary[list[i]]++;
                    else
                        dictionary[list[i]] = 1;
            }
            foreach(var el in dictionary)
                Console.WriteLine($"Key: {el.Key} --- Value: {el.Value}");
            
            Console.WriteLine("");
            Dictionary<int, int> dic2 = dictionary2<int, int>(list);
            foreach (var el in dic2)
                Console.WriteLine($"Key: {el.Key} --- Value: {el.Value}");
            Console.WriteLine("");

            var dic3 = from el in list
                       group el by el;
            foreach(IGrouping<int, int> el in dic3)
                Console.WriteLine($"Key: {el.Key} --- Value: {el.Count()}");

            Console.ReadKey();
        }
    }
}
