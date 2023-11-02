using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Labb_8__OOP_Generic_Collections
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }

        public static int RefernsId = 10001;


        public Employee(string name, string gender, double salary)
        {
            Id = RefernsId;
            Name = name;
            Gender = gender;
            Salary = salary;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Namn: {Name}"+$"\nKön: {Gender}"+$"\nLön: {Salary}"+$"\nAnställningsnummer: {Id}");
        }

    }
}
