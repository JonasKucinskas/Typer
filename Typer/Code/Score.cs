using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;

namespace Typer
{
    
    public class Score
    {
        public string Name { get; set; }

        public string FileName { get; set; }

        public int WordCount { get; set; }

        public int Time { get; set; }

        public string Date = DateTime.Now.ToString("yyyy/M/d");

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
            column.ColumnName = "WordCount";
            column.ReadOnly = true;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Time";
            column.ReadOnly = true;
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "FileName";
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
            row["Name"] = this.Name;
            row["WordCount"] = this.WordCount;
            row["Time"] = this.Time;
            row["FileName"] = this.FileName;
            row["Date"] = this.Date;

            dt.Rows.Add(row);

            view = new DataView(dt);
            ScoreTable.ItemsSource = view;
            ScoreTable.IsReadOnly = false;

            return ScoreTable;
        }

        public void WriteScoreToXmlFile()
        {

            /*
            XmlSerializer serializer = new XmlSerializer(typeof(Score));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            
            var xml = "";
            
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, score);
                
                xml = writer.ToString(); // Your XML
            }
            using (StringWriter write = new StringWriter())
            {
                serializer.Serialize(write, score);
                xml = write.ToString();
                File.WriteAllText(path, xml);

            }
            */
            string path = Environment.CurrentDirectory + "\\Data\\Scores\\Scores.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode score = doc.CreateElement("Score");

            XmlNode name = doc.CreateElement("Name");
            name.InnerText = this.Name;
            score.AppendChild(name);

            XmlNode wordCount = doc.CreateElement("WordCount");
            wordCount.InnerText = this.WordCount.ToString();
            score.AppendChild(wordCount);

            XmlNode fileName = doc.CreateElement("FileName");
            fileName.InnerText = this.FileName; 
            score.AppendChild(fileName);

            XmlNode time = doc.CreateElement("Time");
            time.InnerText = this.Time.ToString();
            score.AppendChild(time);

            XmlNode date = doc.CreateElement("Date");
            date.InnerText = this.Date;
            score.AppendChild(date);

            doc.DocumentElement.AppendChild(score);
            doc.Save(path);
        }

        
        
        public static List<Score> ReturnScoreObject()
        {
            string path = Environment.CurrentDirectory + "\\Data\\Scores\\Scores.xml";
            List<Score> listAllEntries = new List<Score>();
            XmlSerializer serializer = new XmlSerializer(typeof(Score));

            using (FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                
                Score score = (Score)serializer.Deserialize(reader);
                listAllEntries.Add(score);
            }

            return listAllEntries;
        }
    }
}
