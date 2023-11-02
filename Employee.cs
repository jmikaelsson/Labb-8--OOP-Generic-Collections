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
        public int Id;
        public string Name;
        public string Gender;
        public double Salary;

        public Employee(int id, string name, string gender, double salary)
        {
            Id = id;
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
