using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svg_generator.Shapes
{
    class Group : Shape
    {
        private List<Shape> shapes;
        private Canvas canvasRef;

        public Group (Canvas canvasRef)
        {
            shapes = new List<Shape>();
            this.canvasRef = canvasRef;
            UpdateValues();
        }

        public override void UpdateValues()
        {
            UpdateWithUI();
        }

        public override void UpdateWithUI()
        {
            List<Shape> temp_shapes = new List<Shape>();
            List<bool> selected = new List<bool>();

            foreach (Shape s in canvasRef.shapes)
            {
                if (s != this)
                {
                    temp_shapes.Add(s);
                    selected.Add(false);
                }
                else
                {
                    foreach (Shape ts in shapes)
                    {
                        temp_shapes.Add(ts);
                        selected.Add(true);
                    }
                }
            }

            int index = 0;
            while (true)
            {
                Console.Clear();

                Console.WriteLine(index == 0 ? "" : "w - move selection up");
                Console.WriteLine(index == temp_shapes.Count - 1 ? "" : "s - move selection down");
                Console.WriteLine("Space - Add/Remove from group");
                Console.WriteLine();
                Console.WriteLine("d - done");
                Console.WriteLine();

                for (int i = 0; i < temp_shapes.Count; i++)
                {
                    Shape s = temp_shapes[i];

                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine($"{i} - {$"{s.GetType()}".Split('.').Last()}");

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                char command = Console.ReadKey().KeyChar;

                switch (command)
                {
                    case 'w':
                        if (index > 0)
                        {
                            index--;
                        }
                        break;
                    case 's':
                        if (index < temp_shapes.Count - 1)
                        {
                            index++;
                        }
                        break;
                    case ' ':
                        selected[index] = !selected[index];
                        break;
                    case 'd':
                        Shape first = null;
                        for (int i = 0; i < temp_shapes.Count; i++)
                        {
                            if (selected[i])
                            {
                                if (first == null)
                                    first = temp_shapes[i];
                                if (!shapes.Contains(temp_shapes[i])) {
                                  shapes.Add(temp_shapes[i]);
                                  canvasRef.shapes.Remove(temp_shapes[i]);
                                }
                            }
                            else
                            {
                                if (shapes.Contains(temp_shapes[i]))
                                {
                                    shapes.Remove(temp_shapes[i]);
                                    canvasRef.shapes.Add(temp_shapes[i]);
                                }
                            }
                        }
                        if (shapes.Count == 0)
                            canvasRef.shapes.Remove(this);
                        return;
                    default:
                        break;
                }
            }

        }

        public override string GetTag()
        {
            string output = "<g>\n";
            foreach (Shape s in shapes)
                output += $"{s.GetTag()}\n";
            output += "</g>";
            return output;
        }
    }
}
