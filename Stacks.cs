﻿using Labb_8__OOP_Generic_Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_8__OOP_Generic_Collections
{
    internal static class Stacks
    {
        public static void StackMethod()
        {
            Stack<Employee> employees = new();
            Stack<Employee> employeeBackUp = new();

            bool startPage = true;
            while (startPage)
            {
                Console.WriteLine("Företags register");

                Console.WriteLine("" +
                    "\n" +
                    "\n1. Lägg till ny anställd" +
                    "\n2. Öppna alla medarbetare" +
                    "\n3. Ta bort medarbetare" +
                    "\n4. Sök anställd" +
                    "\n\n\n-----------------------" +
                    "\n5. Exit");

                bool successfulParse = int.TryParse(Console.ReadLine(), out int userInput);
                if (successfulParse)
                {
                    if (userInput == 1)
                    {
                        Console.Clear();
                        NewEmployee(employees);
                    }
                    else if (userInput == 2)
                    {
                        Console.Clear();
                        AllEmployee(employees);
                    }
                    else if (userInput == 3)
                    {
                        Console.Clear();
                        RemoveEmployee(employees);
                    }

                    else if (userInput == 4)
                    {
                        Console.Clear();
                        SeekEmployee(employees);
                    }
                    else if (userInput == 5)
                    {
                        Console.Clear();
                        startPage = false;
                    }
                }
                else
                {
                    Console.WriteLine("Du måste göra ett val, 1,2, 3 eller 4[exit]");
                }
            }
        }

        static void NewEmployee(Stack<Employee> employees)
        {
            Console.WriteLine("Lägg till ny anställd\n-----------------------");

            Console.Write("Namn: ");
            string userInputName = Console.ReadLine();
            Console.Write("Kön: ");
            string userInputGender = Console.ReadLine();
            Console.Write("Månadslön: ");
            bool wrongInput = !double.TryParse(Console.ReadLine(), out double userInputSalary);
            while (wrongInput)
            {
                Console.WriteLine("Fel format. Endast siffror\n");
                Console.Write("Lön: ");
                wrongInput = !double.TryParse(Console.ReadLine(), out userInputSalary);
            }

            Employee newEmployee = new Employee(userInputName, userInputGender, userInputSalary);

            Console.WriteLine("-----------------------\nSammanfattning\n");
            newEmployee.PrintInfo();

            Console.WriteLine("" +
                "\nTryck enter för att lägga till anställd");
            Console.ReadKey();
            employees.Push(newEmployee);
            Console.Clear();
        }

        static void AllEmployee(Stack<Employee> employees)
        {

            if (employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    employee.PrintInfo();
                    Console.WriteLine($"---------------------------\nTotalt antal anställda: {employees.Count()}\n");
                }
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Det finns inga anställda att vissa...");
                Console.ReadKey();
                Console.Clear();
            }
        }


        static void CopyEmployees(Stack<Employee> stackA, Stack<Employee> StackB)
        {
            if(StackB.Count > 0)
            {
                StackB.Clear();
            }


            foreach (Employee employee in stackA)
            {
                StackB.Push(employee);
            }

        }
        static void RemoveEmployee(Stack<Employee> employees)
        {
            
            if (employees is null || employees.Count <= 0)
            {
                return;
            }

            Stack<Employee> employeeBackUp = new();
            CopyEmployees(employees, employeeBackUp);


            while (employees.Count > 0)
            {
                var employee = employees.Pop();
                Console.WriteLine("Antal anställda: " + employees.Count);
            }
            Console.WriteLine("Alla anställda borttagna..\n\n[1] Ångra borttagning\n[2] för att gå tillbaka");
            string userChoise = Console.ReadLine();
            switch (userChoise)
            {
                case "1":
                        Console.Clear();
                        CopyEmployees(employeeBackUp, employees);
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }

        static void SeekEmployee(Stack<Employee> employees)
        {
            Console.WriteLine("Sök medarbetare" +

                "------------------------");
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);
            //if (foundEmployee is not null)
            //{
            //    Console.WriteLine("------------------------");
            //    foundEmployee.PrintInfo();
            //}
            //else
            //{
            //    Console.WriteLine("------------------------");
            //    Console.WriteLine($"Det finns ingen med {name} i registret");
            //}
            bool stackContain = employees.Contains(foundEmployee);
            if (stackContain)
            {
                Console.WriteLine("------------------------");
                foundEmployee.PrintInfo();
            }
            else
            {
                Console.WriteLine("------------------------");
                Console.WriteLine($"Det finns ingen med {name} i registret");
            }
            
            Console.WriteLine("Tryck enter för att gå tillbaka");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
