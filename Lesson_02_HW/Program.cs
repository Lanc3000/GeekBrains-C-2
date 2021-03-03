using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
   Тимур Самигуллин
    1. Построить три класса (базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой 
        (один из потомков) и фиксированной оплатой (второй потомок).
      а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы. 
        Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка», 
        для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
      б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
      в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
      г) *Создать класс, содержащий массив сотрудников, 
            и реализовать возможность вывода данных с использованием foreach.
 */
namespace Lesson_02_HW
{
    abstract class Employee: IComparable {
        public double Wage { get; set; }
        public double Rate { get; set; }
        public abstract double CalcOfAverageWage();

        public int CompareTo(object obj)
        {
            if (Wage < ((Employee)obj).Wage)
                return 1;
            if (Wage > ((Employee)obj).Wage)
                return -1;
            return 0;
        }
    }
    class HourlyEmployee : Employee
    {
        public HourlyEmployee(double rate)
        {
            this.Rate = rate;
        }
        public override double CalcOfAverageWage()
        {
            Wage = 20.8 * 8 * Rate;
            return Wage;
        }
    }
    class FixedEmployee : Employee
    {
        public FixedEmployee(double wage)
        {
            this.Wage = wage;
        }
        public override double CalcOfAverageWage()
        {
            return Wage;
        }
    }
    class ArrayOfEmployees
    {
        Employee[] _employees;
        public ArrayOfEmployees(Employee[] employees)
        {
            this._employees = employees;
        }
        public void PrintEmployees()
        {
            foreach(var el in _employees)
                Console.WriteLine($"Wage employee - {el.Wage}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = {
                    new HourlyEmployee(60),
                    new HourlyEmployee(80),
                    new FixedEmployee(10000),
                    new FixedEmployee(20000)
            };
            foreach(var el in employees)
            {
                Console.WriteLine($"employee payroll - {el.CalcOfAverageWage()}");
            }

            Array.Sort(employees);
            Console.WriteLine("");
            Console.WriteLine("Массив работников после сортировки:");
            foreach (var el in employees)
            {
                Console.WriteLine($"employee payroll - {el.CalcOfAverageWage()}");
            }

            ArrayOfEmployees array = new ArrayOfEmployees(employees);
            Console.WriteLine("");
            Console.WriteLine("Вызов зарплат сотрудников из объекта класса ArrayOfEmployees");
            array.PrintEmployees();
            Console.ReadKey();
        }
    }
}
