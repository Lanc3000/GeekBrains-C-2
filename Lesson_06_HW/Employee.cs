using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_06_HW
{
    [Serializable]
     public class Employee
    {
        public string FIO { get; set; }
        public DateTime DateOfPreviousExam { get; set; }
        public Brigade EmployeeBrigade { get; set; }
        public string GetBrigadeName
        {
            get { return EmployeeBrigade?.BrigadeName; }
            set { EmployeeBrigade = new Brigade(value); }
        }
    }
}
