using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

namespace Labb_8__OOP_Generic_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Villken typ vill du använda" +
                    "\n[1] Stacks<T>" +
                    "\n[2] List<T>");

                bool right = int.TryParse(Console.ReadLine(), out int userInput);

                if (right)
                {
                    if (userInput == 1)
                    {
                        Console.Clear();
                        Stacks.StackMethod();
                    }
                    else if (userInput == 2)
                    {
                        Console.Clear();
                        Lists.ListMethod();
                    }
                    else
                    {
                        Console.WriteLine("Du kan bara välja mellan 1 eller 2!");
                    }
                }
            }
        } 
    }
}