using svg_generator.Shapes;
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
        // shapes list, index = z value
        public List<Shape> shapes;
        private readonly Originator camera;

        private readonly Caretaker undo;
        private readonly Caretaker redo;

        public Canvas()
        {
            shapes = new List<Shape>();
            camera = new Originator(shapes);

            undo = new Caretaker();
            redo = new Caretaker();
        }

        public bool AddShape(string inp)
        {
            Shape shape;
            
            switch (inp.ToLower())
            {
                case "rectangle":
                    shape = new Rectangle();
                    break;
                case "circle":
                    shape = new Circle();
                    break;
                case "ellipse":
                    shape = new Ellipse();
                    break;
                case "line":
                    shape = new Line();
                    break;
                default:
                    Console.WriteLine("Invalid shape");
                    return false;
            }

            undo.Push(camera.SaveStateToMomento());
            redo.Clear();
            shapes.Add(shape);
            return true;
        }

        public void clear()
        {
            undo.Push(camera.SaveStateToMomento());
            redo.Clear();
            shapes = new List<Shape>();
        }

        public void Undo()
        {
            List<Shape> snap = undo.Pop().GetState();
            Momento pre = camera.SaveStateToMomento();

            shapes = snap;
            camera.SetState(snap);
            redo.Push(pre);
        }

        public void Redo()
        {
            List<Shape> snap = redo.Pop().GetState();

            undo.Push(camera.SaveStateToMomento());
            shapes = snap;
            camera.SetState(snap);
        }

        public void GetSVG()
        {
            Console.WriteLine();
            string output = "<svg>\n";
            foreach (Shape s in shapes)
                output += $"{s.GetTag()}\n";
            output += "</svg>";
            Console.WriteLine(output);

            // save file
            File.WriteAllText("output.svg", output);

            Console.WriteLine();

            Console.WriteLine("File saved to output.svg");

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
