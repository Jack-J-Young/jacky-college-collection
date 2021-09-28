using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabconv
{
    class Program
    {
        static void Main(string[] args)
        {
            Table t = new Table(new string[] { "h1", "h2" }, new string[][] { new string[] { "c1", "c2" } , new string[] { "c1", "c2" } });
            Console.WriteLine(t.ToString());
            Console.WriteLine(t.SetHTML());
            Console.WriteLine(t.SetCSV());
            Console.WriteLine(t.SetJSON());
            Console.WriteLine(t.SetMD());
            t.GetHTML(t.SetHTML());
            Console.ReadLine();
        }
    }
}
