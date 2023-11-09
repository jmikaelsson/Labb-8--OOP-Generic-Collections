using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_8__OOP_Generic_Collections
{
    internal class Lists
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
                    else
                    {
                        Console.WriteLine("Du måste göra ett val, 1,2, 3 eller 4[exit]");
                    }
                }
            }

            static void NewEmployee(List<Employee> employees)
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
                employees.Add(newEmployee);
                Console.Clear();
            }

            static void AllEmployee(List<Employee> employees)
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

            static void RemoveEmployee(List<Employee> employees)
            {

                //<Stacks>employeeBackUp = employees;
                while (employees.Count > 0)
                {
                    employees.Pop();
                    Console.WriteLine("Antal anställda: " + employees.Count);
                }
                Console.WriteLine("Alla anställda borttagna..\n\n[1] Ångra borttagning\nTryck Enter för att gå tillbaka");
                bool succses = int.TryParse(Console.ReadLine(), out int reverseRemove);
                while (succses)
                {
                    if (reverseRemove == 1)
                    {
                        Console.Clear();
                        //employees.Push(employeeBackUp);

                    }
                    else
                    {
                        Console.WriteLine("Tryck 1 för att ångra");
                    }
                }
            }

            static void SeekEmployee(List<Employee> employees)
            {
                Console.WriteLine("Sök medarbetare" +

                    "------------------------");
                Console.Write("Namn: ");
                string name = Console.ReadLine();
                string gender = Console.ReadLine();
                bool succses = double.TryParse(Console.ReadLine(), out double salary);
                if (succses)
                {
                    //Console.WriteLine(employees.Contains(name));
                }
                else
                {
                    Console.WriteLine("Fel inskrivet");
                }





            }

        }
    }



