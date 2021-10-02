using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tabconv
{
    class TableConverter
    {
        private Table table;

        public TableConverter()
        {
        }

        public TableConverter(Table table)
        {
            this.table = table;
        }

        public static string JsonDataToString(string input)
        {
            Regex stringRegex = new Regex("\"(.*)\"");
            if (stringRegex.IsMatch(input))
                return input.Substring(1, input.Length - 2);
            return input;
        }
        public static string StringToJsonData(object input)
        {
            if (input.GetType() == typeof(String))
                return $"\"{input}\"";
            return (string)input;
        }

        // override object's ToString for debugging
        public override string ToString()
        {
            string output = "";
            var headings = table.ToKeyList();
            for (int i = 0; i < headings.Count; i++)
            {
                output += headings[i] + (i == headings.Count - 1 ? "\n" : " | ");
            }
            output += new String('-', output.Length - 1) + "\n";
            for (int i = 0; i < table.RowCount; i++)
            {
                var row = table.ToRow(i);
                for (int j = 0; j < row.Count; j++)
                {
                    output += row[j] + (j == row.Count - 1 ? "\n" : " | ");
                }
            }
            return output;
        }

        public void SetHTML(string input)
        {
            input = input.Replace("\t", "").Replace("\n", "");

            Regex rowRegex = new Regex("<tr>(.*?)</tr>");
            Regex headerRegex = new Regex("<th>(.*?)</th>");
            Regex DataRegex = new Regex("<td>(.*?)</td>");

            var rowsData = rowRegex.Matches(input);
            //Console.WriteLine(v.Value);
            table = new Table();

            var headerData = headerRegex.Matches(rowsData[0].Value);
            Console.WriteLine(headerData.Count);
            for (int i = 0; i < headerData.Count; i++)
            {
                table.AddColumn(headerData[i].Value.Substring(4, headerData[i].Value.Length - 9));
            }

            for (int i = 1; i < rowsData.Count; i++)
            {
                //table.AddColumn(headerData[i].Value.Substring(4, headerData[i].Value.Length - 9));
                var rowData = DataRegex.Matches(rowsData[i].Value);
                for (int j = 0; j < rowData.Count; j++)
                {
                    table.AddColumnData(j, rowData[j].Value.Substring(4, rowData[j].Value.Length - 9));
                }
            }
        }

        public void SetCSV(string input)
        {
            // clear tabs and lines
            input = input.Replace("\t", "");
            string[] rowData = input.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            table = new Table();
            
            rowData[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(key => table.AddColumn(JsonDataToString(key)));
            for (int i = 0; i < table.Count; i++)
            {
                var row = rowData[i + 1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < row.Length; j++)
                {
                    table.AddColumnData(j, JsonDataToString(row[j]));
                }
            }

            //heading
        }

        public void SetJSON(string input)
        {
            input = input.Replace("\t", "").Replace("\n", "");
            Regex arrayRegex = new Regex("[[](.*?)[]]");
            Regex objectRegex = new Regex("{(.*?)}");
            Regex jsonRegex = new Regex("(.*?): (.*?)");

            table = new Table();

            if (!arrayRegex.IsMatch(input))
                throw new Exception("Invalid JSON format");

            var rowsData = objectRegex.Matches(input);

            foreach (var v in rowsData)
            {
                var colsData = v.ToString().Substring(1, v.ToString().Length - 2).Split(',');
                for (int i = 0; i < colsData.Length; i++)
                {
                    if (!jsonRegex.IsMatch(colsData[i]))
                        throw new Exception("Invalid JSON format");
                    var d = colsData[i].Split(new string[] { ": " }, StringSplitOptions.None);
                    if (v.Equals(rowsData[0]))
                        table.AddColumn(JsonDataToString(d[0]));
                    table.AddColumnData(i, JsonDataToString(d[1]));
                }
            }
        }

        // output in html format
        public string GetHTML()
        {
            // create the table tag
            string output = "<table>\n";

            // add the heading row
            output += $"{t(1)}<tr>\n";
            var heading = table.ToKeyList();
            heading.ForEach(key => output += $"{t(2)}<th>{key}</th>\n");
            output += $"{t(1)}</tr>\n";

            // add td for each row in table
            var rows = table.Rows;
            rows.ForEach(row =>
            {
                output += $"{t(1)}<tr>\n";
                row.ForEach(value => output += $"{t(2)}<td>{value}</td>\n");
                output += $"{t(1)}</tr>\n";
            });
            output += "</table>";
            return output;
        }

        public string GetCSV()
        {
            string output = "";

            var heading = table.ToKeyList();
            // add header (ternary for commas and no commas on last column)
            heading.ForEach(key => output += $"{StringToJsonData(key)}{(key.Equals(heading.Last()) ? '\n' : ',')}");
            // same as header but for each row
            var rows = table.Rows;
            rows.ForEach(row =>
            {
                row.ForEach(value => output += $"{StringToJsonData(value)}{(value.Equals(row.Last()) ? '\n' : ',')}");
            });

            return output;
        }

        public string GetJSON()
        {
            // add outer []
            string output = "[\n";

            // add js object for each row
            var kvp = table.GetData();
            for (int i = 0; i < table.RowCount; i++)
            {
                output += $"{t(1)}{{\n";
                kvp.ForEach(x => output += $"{t(2)}{StringToJsonData(x.Key)}: {StringToJsonData(x.Value[i])}{(x.Equals(kvp.Last()) ? "" : ",")}\n");
                output += $"{t(1)}}}{(i != table.RowCount - 1 ? "," : "")}\n";
            }
            output += "]";
            return output;
        }

        public string GetMD()
        {
            string output = "";

            var data = table.GetData();
            int[] colsSizes = new int[table.Count];
            for (int i = 0; i < data.Count; i++)
            {
                int max = data[i].Key.Length;
                data[i].Value.ForEach(y =>
                {
                    max = y.ToString().Length > max ? y.ToString().Length : max;
                });
                colsSizes[i] = max;
            }

            int count = 0;
            table.ToKeyList().ForEach(key =>
            {
                output += $"|{key + new string(' ', colsSizes[count] - key.Length)}";
                count++;
            });
            output += "|\n";
            count = 0;
            table.ToKeyList().ForEach(key =>
            {
                output += $"|{new string('-', colsSizes[count])}";
                count++;
            });
            output += "|\n";

            table.Rows.ForEach(row =>
            {
                count = 0;
                row.ForEach(value =>
                {
                    output += $"|{value + new string(' ', colsSizes[count] - value.ToString().Length)}";
                    count++;
                });
                output += "|\n";
            });

            return output;
        }

        private string t(int i)
        {
            return new string('\t', i);
        }
    }
}
