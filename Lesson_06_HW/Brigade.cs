using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_06_HW
{
    public class Brigade
    {
        public string BrigadeName { get; set; }
        public Brigade()
        {

        }
        public Brigade(string _name)
        {
            BrigadeName = _name;
        }
        public override string ToString()
        {
            return BrigadeName;
        }
    }
}
