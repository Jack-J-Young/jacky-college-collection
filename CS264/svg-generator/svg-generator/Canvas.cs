using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator
{
    class Canvas
    {
        private List<Shape> shapes;

        public Canvas()
        {
            shapes = new List<Shape>();
        }

        public void AddShape(int type)
        {
            switch (type)
            {
                case 0:
                    shapes.Add(new Rectangle());
                    break;
                case 1:
                    shapes.Add(new Circle());
                    break;
                case 2:
                    shapes.Add(new Ellipse());
                    break;
                case 3:
                    shapes.Add(new Line());
                    break;
                case 4:
                    shapes.Add(new Polyline());
                    break;
                case 5:
                    shapes.Add(new Polygon());
                    break;
                case 6:
                    shapes.Add(new Path());
                    break;
                default:
                    break;
            }
        }

        public Shape PickShape(string header)
        {
            int pageCount = shapes.Count / 10;
            int page = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(header);
                Console.WriteLine();

                // print all shapes
                bool ended = false;
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        Shape s = shapes[i + page * 10];
                        // Get key to press + shapes class name
                        Console.WriteLine($"{i} - {$"{s.GetType()}".Split('.').Last()}");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ended = true;
                    }
                    if (ended)
                    {
                        Console.WriteLine("  -");
                    }
                }
                Console.WriteLine();
                Console.WriteLine(page <= 0 ? "" : "[ - Previous page");
                Console.WriteLine(page >= pageCount ? "" : "] - Next page");
                Console.WriteLine("c - cancel");
                Console.WriteLine();
                Console.WriteLine($"Page {page} of {pageCount}");
                char command = Console.ReadKey().KeyChar;

                switch (command)
                {
                    case '[':
                        page -= page <= 0 ? 0 : 1;
                        break;
                    case ']':
                        page += page >= pageCount ? 0 : 1;
                        break;
                    case 'c':
                        return null;
                    default:
                        if (command >= 48 || command <= 57)
                        {
                            try
                            {
                                return shapes[(command - 48) + page * 10];
                            }
                            catch (ArgumentOutOfRangeException) { }
                            
                        }
                        break;
                }
            }
        }

        public void EditShape()
        {
            Shape s = PickShape("Pick shape to edit:");

            if (s == null)
                return;

            s.UpdateWithUI();
        }

        public void DeleteShape()
        {
            Shape s = PickShape("Pick shape to edit:");

            if (s == null)
                return;

            shapes.Remove(s);
        }

        public void AddShape()
        {
            Console.Clear();
            Console.WriteLine("Press key to create shape");
            Console.WriteLine("0 - Rectangle");
            Console.WriteLine("1 - Circle");
            Console.WriteLine("2 - Ellipse");
            Console.WriteLine("3 - Line");
            Console.WriteLine("4 - Polyline");
            Console.WriteLine("5 - Polygon");
            Console.WriteLine("6 - Path");
            Console.WriteLine();
            Console.WriteLine("q - quit");
            char input = Console.ReadKey().KeyChar;
            if (input == 'q')
                return;
            if ((int)input >= 48 && (int)input <= 54)
                AddShape(input - 48);
            else
                AddShape();
        }

        public void EditZ()
        {
            int index = 0;
            while (true)
            {
                Console.Clear();

                Console.WriteLine(index == 0 ? "" : "w - move selection up");
                Console.WriteLine(index == shapes.Count - 1 ? "" : "s - move selection down");
                Console.WriteLine("Hold Shift to drag selected shape with selection");
                Console.WriteLine();

                bool ended = false;
                for (int i = 0; i < shapes.Count; i++)
                {
                    try
                    {
                        Shape s = shapes[i];
                        // Get key to press + shapes class name

                        if (i == index)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }

                        Console.WriteLine($"{i} - {$"{s.GetType()}".Split('.').Last()}");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ended = true;
                    }
                    if (ended)
                    {
                        Console.WriteLine("  -");
                    }
                }

                char command = Console.ReadKey().KeyChar;
                Shape temp;

                switch (command)
                {
                    case 'w':
                        if (index != 0)
                        {
                            index--;
                        }
                        break;
                    case 's':
                        if(index != shapes.Count - 1)
                        {
                            index++;
                        }
                        break;
                    case 'W':
                        if (index != 0)
                        {
                            temp = shapes[index];
                            shapes[index] = shapes[index - 1];
                            shapes[index - 1] = temp;
                            index--;
                        }
                        break;
                    case 'S':
                        if (index != shapes.Count-1)
                        {
                            temp = shapes[index];
                            shapes[index] = shapes[index + 1];
                            shapes[index + 1] = temp;
                            index++;
                        }
                        
                        break;
                    default:
                        break;
                }
            }
            
        }

        public void GetSVG()
        {
            Console.Clear();
            string output = "<svg>\n";
            foreach (Shape s in shapes)
                output += $"{s.GetTag()}\n";
            output += "</svg>";
            Console.WriteLine(output);

            // save file
            File.WriteAllText("output.svg", output);

            Console.WriteLine();
            Console.WriteLine("File saved as output.svg");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
