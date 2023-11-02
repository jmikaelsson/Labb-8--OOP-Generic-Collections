using System.Reflection.Metadata;

namespace Labb_8__OOP_Generic_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool startPage = true;

            while (startPage == true)
            {
                Console.WriteLine("Företags register");

                Console.WriteLine("" +
                    "\n" +
                    "\n1. Lägg till ny anställd" +
                    "\n2. Ta bort anställd" +
                    "\n3. Öppna alla anställda" +
                    "\n" +
                    "\n4. Exit");

                bool successfulParse = int.TryParse(Console.ReadLine(), out int userInput);
                while (true)
                {
                    if (successfulParse)
                    {
                        if (userInput == 1)
                        {
                            NewEployee();
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

        public static void NewEployee()
        {
            Stack<Employee> employees = new Stack<Employee>();

            Console.Write("Namn: ");
            string userName = Console.ReadLine();
            Console.Write("Kön: ");
            string userGender = Console.ReadLine();
            Console.Write("Lön: ");
            double userSalary = double.Parse(Console.ReadLine());
            int userId = 10001;

            Console.WriteLine("-------------------------------");
            Employee.PrintInfo();

            Console.WriteLine("" +
                "\nTryck enter för att lägga till anställd");
            Console.ReadKey();

            Employee employee = new Employee(userId, userName, userGender, userSalary);
            employees.Push(employee);

            userId++;
        }
    }
}