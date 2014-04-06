// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleTable.cs" company="">
//   
// </copyright>
// <summary>
//   Copyright (c) 2013 Khalid Abuhakmeh
//   https://github.com/khalidabuhakmeh/ConsoleTables
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>Copyright (c) 2013 Khalid Abuhakmeh https://github.com/khalidabuhakmeh/ConsoleTables</summary>
    public class ConsoleTable
    {
        public ConsoleTable(params string[] columns)
        {
            this.Columns = new List<string>(columns);
            this.Rows = new List<object[]>();
        }

        public IList<string> Columns { get; protected set; }

        public IList<object[]> Rows { get; protected set; }

        public static ConsoleTable From<T>(IEnumerable<T> values)
        {
            var table = new ConsoleTable();

            var columns = typeof(T).GetProperties().Select(x => x.Name).ToArray();
            table.AddColumn(columns);

            foreach (var propertyValues in values.Select(value => columns.Select(column => typeof(T).GetProperty(column).GetValue(value, null))))
            {
                table.AddRow(propertyValues.ToArray());
            }

            return table;
        }

        public ConsoleTable AddColumn(string[] names)
        {
            foreach (var name in names)
            {
                this.Columns.Add(name);
            }

            return this;
        }

        public ConsoleTable AddRow(params object[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (!this.Columns.Any())
            {
                throw new Exception("Please set the columns first");
            }

            if (this.Columns.Count != values.Length)
            {
                throw new Exception(string.Format("The number columns in the row ({0}) does not match the values ({1}", this.Columns.Count, values.Length));
            }

            this.Rows.Add(values);
            return this;
        }

        public override string ToString()
        {
            if (!this.Rows.Any())
            {
                return "\nCount: 0";
            }

            var builder = new StringBuilder();

            // find the longest column by searching each row
            var columnLengths =
                this.Columns.Select((t, i) => this.Rows.Select(x => x[i]).Union(this.Columns).Where(x => x != null).Select(x => x.ToString().Length).Max())
                    .ToList();

            // create the string format with padding
            var format = Enumerable.Range(0, this.Columns.Count).Select(i => " | {" + i + ", -" + columnLengths[i] + " }").Aggregate((s, a) => s + a) + " |";

            var longestLine = 0;
            var results = new List<string>();

            // find the longest formatted line
            foreach (var result in this.Rows.Select(row => string.Format(format, row)))
            {
                longestLine = Math.Max(longestLine, result.Length);
                results.Add(result);
            }

            // create the divider
            var line = " " + string.Join(string.Empty, Enumerable.Repeat("-", longestLine - 1)) + " ";

            builder.AppendLine(line);
            builder.AppendLine(string.Format(format, this.Columns.Cast<object>().ToArray()));

            foreach (var row in results)
            {
                builder.AppendLine(line);
                builder.AppendLine(row);
            }

            builder.AppendLine(line);
            builder.AppendLine();
            builder.AppendFormat("Count: {0}", this.Rows.Count);

            return builder.ToString();
        }

        public void Write()
        {
            Console.WriteLine(this.ToString());
        }
    }
}