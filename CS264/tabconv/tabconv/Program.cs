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
            Table t = new Table();
            t.AddColumn("h1");
            t.AddColumn("h2");
            t.AddColumnData("h1", "c1");
            t.AddColumnData("h2", "c2");
            t.AddColumnData("h1", "c3");
            t.AddColumnData("h2", "c4");

            TableConverter tc = new TableConverter(t);
            Console.WriteLine(tc.ToString());
            Console.WriteLine(tc.GetHTML());
            Console.WriteLine(tc.GetCSV());
            Console.WriteLine(tc.GetJSON());
            Console.WriteLine(tc.GetMD());
            tc.SetHTML(tc.GetHTML());
            Console.WriteLine(tc.GetHTML());
            Console.WriteLine(tc.GetCSV());
            tc.SetCSV(tc.GetCSV());
            Console.WriteLine(tc.GetHTML());
            Console.WriteLine(tc.GetCSV());
            tc.SetJSON(tc.GetJSON());
            Console.WriteLine(tc.GetHTML());
            Console.WriteLine(tc.GetCSV());
            Console.ReadLine();
        }
    }
}
