using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

namespace Labb_8__OOP_Generic_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<Employee> employees = new Stack<Employee>();

            bool startPage = true;

            while (startPage)
            {
                Console.WriteLine("Företags register");

                Console.WriteLine("" +
                    "\n" +
                    "\n1. Lägg till ny anställd" +
                    "\n2. Öppna alla medarbetare" +
                    "\n3. Ta bort medarbetare" +
                    "\n" +
                    "\n4. Exit");

                bool successfulParse = int.TryParse(Console.ReadLine(), out int userInput);
                while (true)
                {
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
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du måste göra ett val, 1,2, 3 eller 4[exit]");
                    }
                }
            }       
        }

        public static void NewEmployee(Stack<Employee> employees)
        {
            Console.WriteLine("Lägg till ny anställd\n-----------------------");

            Console.Write("Namn: ");
            string userName = Console.ReadLine();
            Console.Write("Kön: ");
            string userGender = Console.ReadLine();
            Console.Write("Lön: ");
            bool successfulParse =! double.TryParse(Console.ReadLine(), out double userSalary);
            while(successfulParse)
            {
                Console.WriteLine("Fel format. Endast siffror\n");
                Console.Write("Lön: ");
                successfulParse = !double.TryParse(Console.ReadLine(), out userSalary);
            }
                
            Employee newEmployee = new Employee(userName, userGender, userSalary);
            
            Console.WriteLine("-----------------------\nSammanfattning\n");
            newEmployee.PrintInfo();

            Console.WriteLine("" +
                "\nTryck enter för att lägga till anställd");
            Console.ReadKey();
            employees.Push(newEmployee);
        }

        public static void AllEmployee(Stack<Employee> employees)
        {
            foreach(var employee in employees)
            {
                Console.WriteLine($"{employee}" +
                    $"-----------------------------");
                    employees.Count();
            }

        }

        public static void RemoveEmployee(Stack<Employee> employees)
        {
           
        }
    }
}