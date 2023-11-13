using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb_8__OOP_Generic_Collections
{
    internal static class Lists
    {
        public static void ListMethod()
        {
            List<Employee> employees = new();

            bool startPage = true;
            while (startPage)
            {
                Console.WriteLine("Företags register");

                Console.WriteLine("" +
                    "\n" +
                    "\n1. Lägg till ny anställd" +
                    "\n2. Öppna medarbetare" +
                    "\n3. Sök anställd" +
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

        //Method to insert new employee
        static void NewEmployee(List<Employee> employees)
        {
            Console.WriteLine("Lägg till ny anställd\n-----------------------");

            Console.Write("Namn: ");
            string userInputName = Console.ReadLine();
            Console.Write("Kön: ");
            string userInputGender = Console.ReadLine();
            Console.Write("Månadslön: ");
            bool wrongInput = !double.TryParse(Console.ReadLine(), out double userInputSalary);
           
            while (wrongInput) //if user put in anything else than numbers
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
            employees.Add(newEmployee);
            Console.Clear();
        }

        //Method for print out all employees
        static void AllEmployee(List<Employee> employees)
        {
            //employees.Contains();
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
            else // If there in´t any emolyees
            {
                Console.WriteLine("Det finns inga anställda att vissa...");
                Console.ReadKey();
                Console.Clear();
            }
        }


        //Method for seek a specific employee
        static void SeekEmployee(List<Employee> employees)
        {
            Console.WriteLine("Sök medarbetare" +
                "\n[1] Namn" +
                "\n[2] Kön"+
                "\n------------------------");
            string userChoise = Console.ReadLine();
            
            switch (userChoise)
            {
                case "1":
                    Console.Write("Namn: ");
                    string name = Console.ReadLine();
                    Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);
                    bool ListContain = employees.Contains(foundEmployee);
                    if (ListContain)
                    {
                        Console.WriteLine("------------------------");
                        foundEmployee.PrintInfo();
                    }
                    else
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine($"Det finns ingen med {name} i registret");
                    }
                    break;
                case "2":
                    Console.WriteLine("Kön:");
                    string gender = Console.ReadLine();
                    if (employees.Count > 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Resultatet av sök på: {gender}\n------------------------\n");

                        foreach (Employee employee in employees.FindAll(employee => employee.Gender == gender).ToList())
                        {
                            employee.PrintInfo();
                        }
                        Employee first = employees.Find(employee => employee.Gender == gender);
                        Console.WriteLine($"\n------------------------\nDen {gender} som har varit anställd längst är:");
                        first.PrintInfo();
                        break;
                        

                    }
                    else
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine($"Det finns ingen {gender} i registret");
                    }
                    break;
            }


           

            Console.WriteLine("Tryck enter för att gå tillbaka");
            Console.ReadKey();
            Console.Clear();

        }
    }
}