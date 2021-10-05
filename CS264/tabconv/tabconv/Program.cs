using System;
using System.IO;
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

            t.AddColumn("h111");
            t.AddColumn("h2aaaaaaaa");
            t.AddColumn("3");
            t.AddColumnData(0, "c1");
            t.AddColumnData(1, "c2");
            t.AddColumnData(2, "1");
            t.AddColumnData(0, "cwww3");
            t.AddColumnData(1, "cw4");
            t.AddColumnData(2, "2");

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
            Console.WriteLine(tc.GetText());
            Console.WriteLine(tc.GetLaTeX());
            Console.ReadLine();
        }
    }
}
