using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabconv
{
    class Table
    {
        protected List<KeyValuePair<string, List<object>>> data;

        public Table()
        {
            data = new List<KeyValuePair<string, List<object>>>();
        }

        public List<KeyValuePair<string, List<object>>> GetData()
        {
            return data;
        }

        public void AddColumn(string name)
        {
            data.Add(new KeyValuePair<string, List<object>>(name, new List <object>()));
        }

        public void AddColumnData(string columnName, object value)
        {
            KeyValuePair<string, List<object>> col = data.Where(kvp => kvp.Key == columnName).First();
            col.Value.Add(value);
        }

        public void AddColumnData(int colId, object value)
        {
            KeyValuePair<string, List<object>> col = data.ToArray()[colId];
            col.Value.Add(value);
        }

        public KeyValuePair<string, List<object>>[] ToArray()
        {
            return data.ToArray();
        }

        public List<string> ToKeyList()
        {
            List<string> keys = new List<string>();
            data.ForEach(x => keys.Add(x.Key));
            return keys;
        }

        public List<List<object>> ToValueList()
        {
            List<List<object>> values = new List<List<object>>();
            data.ForEach(x => values.Add(x.Value));
            return values;
        }

        public List<object> ToRow(int row)
        {
            if (row == 0)
                return ToKeyList().ConvertAll(obj => (object)obj);
            List<object> values = new List<object>();
            data.ForEach(x => values.Add(x.Value[row - 1]));
            return values;
        }

        public List<List<object>> Rows { get
        {
                List<List<object>> output = new List<List<object>>();
                for (int i = 0; i < data.First().Value.Count; i++)
                {
                    output.Add(new List<object>());
                    data.ForEach(x => output[i].Add(x.Value[i]));
                }
                return output;
        } }
        public int RowCount { get { return data.First().Value.Count; } }
        public int Count { get { return data.Count; } }
    }
}
