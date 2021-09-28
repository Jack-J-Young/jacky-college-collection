using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabconv
{
    class Table
    {
        public string[] heading;
        public string[][] body;

        public Table()
        {
        }

        public Table(string[] heading, string[][] body)
        {
            this.heading = heading;
            this.body = body;
        }


        // override object's ToString for debugging
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < heading.Length; i++)
            {
                output += heading[i] + (i == heading.Length - 1 ? "\n" : " | ");
            }
            output += new String('-', output.Length - 1) + "\n";
            for (int i = 0; i < body.Length; i++)
            {
                for (int j = 0; j < body[i].Length; j++)
                {
                    output += body[i][j] + (j == body[i].Length - 1 ? "\n" : " | ");
                }
            }
            return output;
        }

        public void GetHTML(string input)
        {
            input = input.Replace("\t", "").Replace("\n", "");
            int current = 0;
            int start = input.IndexOf("<tr>");
            int end = input.IndexOf("</tr>");
            current = start;
            while (current < end)
            {
                current = input.IndexOf("<td>", current);
                string data = input.Substring(current, input.IndexOf("</td>", current) - 3);
                current = input.IndexOf("</td>", current) + 2;
                Console.WriteLine(data);
                Console.WriteLine(current);
            }

        }

        // output in html format
        public string SetHTML()
        {
            // create the table tag
            string output = "<table>\n";

            // add the heading row
            output += $"{t(1)}<tr>\n";
            for (int i = 0; i < heading.Length; i++)
            {
                output += $"{t(2)}<td>{heading[i]}</td>\n";
            }
            output += $"{t(1)}</tr>\n";

            // add td for each row in table
            for (int i = 0; i < body.Length; i++)
            {
                output += $"{t(1)}<tr>\n";
                // add data for each column
                for (int j = 0; j < body[i].Length; j++)
                {
                    output += $"{t(2)}<td>{body[i][j]}</td>\n";
                }
                output += $"{t(1)}</tr>\n";
            }

            output += "</table>";
            return output;
        }

        public string SetCSV()
        {
            string output = "";
            // add header (ternary for commas and no commas on last column)
            for(int i = 0; i < heading.Length;i++)
            {
                output += $"\"{heading[i]}\"{(i == heading.Length-1 ? '\n' : ',')}";
            }
            // same as header but for each row
            for (int i = 0; i < body.Length; i++)
            {
                for (int j = 0; j < body[i].Length; j++)
                {
                    output += $"\"{body[i][j]}\"{(j == body[i].Length - 1 ? '\n' : ',')}";
                }
            }
            return output;
        }

        public string SetJSON()
        {
            // add outer []
            string output = "[\n";

            // add js object for each row
            for(int i = 0; i < body.Length; i++)
            {
                output += $"{t(1)}{{\n";
                // for each column interpolate the heading and the data
                for (int j = 0; j < body[i].Length; j++)
                {
                    output += $"{t(2)}\"{heading[j]}\": \"{body[i][j]}\"{(j != body[i].Length-1 ? "," : "")}\n";
                }
                output += $"{t(1)}}}{(i != body.Length - 1 ? "," : "")}\n";
            }

            output += "]";
            return output;
        }

        public string SetMD()
        {
            string output = "";
            string[][] preProcessedTable = new string[body.Length+1][];
            int[] maxLengths = new int[heading.Length];
            // add all table data to pre proc table
            preProcessedTable[0] = new string[heading.Length];
            for (int i = 0; i < body.Length; i++)
            {
                preProcessedTable[i + 1] = new string[body[i].Length];
            }

            // add the | before everything and find the largest bit of data in each column
            for (int i = 0; i < preProcessedTable.Length; i++)
            {
                for (int j = 0; j < preProcessedTable[i].Length; j++)
                {
                    if (i == 0)
                    {
                        preProcessedTable[i][j] = "|" + heading[j];
                    }
                    else
                    {
                        preProcessedTable[i][j] = "|" + body[i-1][j];
                    }
                    if (preProcessedTable[i][j].Length > maxLengths[j])
                        maxLengths[j] = preProcessedTable[i][j].Length;
                }
            }

            // convert pre proc table to output string adding extra spaces to have all data in the column the same
            for (int i = 0; i < preProcessedTable.Length; i++)
            {
                for (int j = 0; j < preProcessedTable[i].Length; j++)
                {
                    output += $"{preProcessedTable[i][j]}{new string(' ', maxLengths[j] - preProcessedTable[i][j].Length)}";
                    
                }
                // add ---s for under header
                if (i == 0)
                {
                    output += "|\n";
                    for (int k = 0; k < maxLengths.Length; k++)
                    {
                        output += $"|{new string('-', maxLengths[k] - 1)}";
                    }
                }
                output += "|\n";
            }
            return output;
        }

        private string t(int i)
        {
            return new string('\t', i);
        }
    }
}
