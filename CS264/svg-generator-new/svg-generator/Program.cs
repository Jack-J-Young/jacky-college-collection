using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            // create new canvas
            Canvas c = new Canvas();

            string[] command = new string[]{"h"};
            Console.WriteLine("Enter command (h for help):");
            while (command[0] != "q")
            {
                Console.Write("> ");
                command = Console.ReadLine().Split(' ');

                // commands
                switch (command[0])
                {
                    case "h":
                        Console.WriteLine("Commands:");
                        Console.WriteLine();
                        Console.WriteLine("h         - help");
                        Console.WriteLine("a <shape> - Add new shape");
                        Console.WriteLine("u         - undo");
                        Console.WriteLine("r         - redo");
                        Console.WriteLine("c         - clear");
                        Console.WriteLine();
                        Console.WriteLine("q         - quit");
                        break;
                    case "a":
                        try
                        {
                            if (c.AddShape(command[1]))
                                Console.WriteLine($"Added a {command[1].ToLower()} to the canvas");
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("No shape given");
                        }
                        break;
                    case "u":
                        break;
                    case "r":
                        break;
                    case "c":
                        c.clear();
                        Console.WriteLine("Canvas cleared");
                        break;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("unknown command, type h for help");
                        break;
                }
            }
        }
    }
}
