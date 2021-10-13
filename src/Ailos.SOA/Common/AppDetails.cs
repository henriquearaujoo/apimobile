using System.Collections.Generic;

namespace Ailos.SOA.Common
{
    public class AppDetails
    {
        public AppDetails()
        {
            Rows = new List<Row>();
        }

        public string Header { get; set; }
        public string Footer { get; set; }

        private List<Row> _rows { get; set; }

        public List<Row> Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                value.RemoveAll(x => x == null);
                _rows = value;
            }
        }

        public void AddRow(string title, string value)
        {
            Rows.Add(new Row { Title = title, Value = value });
        }
    }

    public class Row
    {
        public Row()
        {
        }

        public Row(string title, string value)
        {
            Title = title;
            Value = value;
        }

        public Row(string title, object value)
        {
            Title = title;
            Value = value.ToString();
        }

        public string Title { get; set; }
        public string Value { get; set; }
    }
}