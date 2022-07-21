using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Typer
{
    public class Score
    {
        public int WordsTyped { get; set; }
        public int Time { get; set; }

        public Score(int wordsTyped, int time)
        {
            this.WordsTyped = wordsTyped;
            this.Time = time;
        }

        public DataGrid SetTable()
        {
            DataTable dt = new DataTable();

            DataColumn column;
            DataView view;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Id";
            column.ReadOnly = true;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            column.ReadOnly = false;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "WordsTyped";
            column.ReadOnly = true;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Time";
            column.ReadOnly = true;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "Date";
            column.ReadOnly = true;
            dt.Columns.Add(column);

            DataGrid ScoreTable = new DataGrid();

            DataRow row = dt.NewRow();
            row["Id"] = ScoreTable.Items.Count + 1;
            row["Name"] = "";
            row["WordsTyped"] = this.WordsTyped;
            row["time"] = this.Time;
            row["Date"] = DateTime.Now.ToString("yyyy/M/d");

            dt.Rows.Add(row);

            view = new DataView(dt);
            ScoreTable.ItemsSource = view;
            ScoreTable.IsReadOnly = false;

            return ScoreTable;
        }
    }
}
