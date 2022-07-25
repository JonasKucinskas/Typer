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
    [XmlRoot("Scores")]
    [Serializable]
    public class Score
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "FileName")]
        public string FileName { get; set; }

        [XmlElement(ElementName = "WordCount")]
        public int WordCount { get; set; }

        [XmlElement(ElementName = "Time")]
        public int Time { get; set; }

        [XmlElement(ElementName = "Date")]
        public string Date = DateTime.Now.ToString();
        public static void SetTable(DataGrid ScoreTable, List<Score> scores)
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

            for (int i = 0; i < scores.Count; i++)
            {
                Score score = scores[i];

                DataRow row = dt.NewRow();
                row["Id"] = i + 1;
                row["Name"] = score.Name;
                row["WordCount"] = score.WordCount;
                row["Time"] = score.Time;
                row["FileName"] = score.FileName;
                row["Date"] = score.Date;


                dt.Rows.Add(row);
            }

            view = new DataView(dt);
            ScoreTable.ItemsSource = view;
            ScoreTable.IsReadOnly = false;
        }

        public void WriteScoreToXmlFile()
        {

            /*
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var xml = "";
            
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, score1);
                
                xml = writer.ToString(); // Your XML
            }
            
            using (StreamWriter write = new StreamWriter(path, false))
            {
                serializer.Serialize(write, scores);
            }
            */

            string path = Environment.CurrentDirectory + "\\Data\\Scores\\Scores.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Score>));

            Score score = new Score();
            score.Date = this.Date;
            score.FileName = this.FileName;
            score.Name = this.Name;
            score.WordCount = this.WordCount;


            List<Score> scores = new List<Score>();
            scores.Add(score);

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode scoreNode = doc.CreateElement("Score");

            XmlNode name = doc.CreateElement("Name");
            name.InnerText = this.Name;
            scoreNode.AppendChild(name);

            XmlNode wordCount = doc.CreateElement("WordCount");
            wordCount.InnerText = this.WordCount.ToString();
            scoreNode.AppendChild(wordCount);

            XmlNode fileName = doc.CreateElement("FileName");
            fileName.InnerText = this.FileName; 
            scoreNode.AppendChild(fileName);

            XmlNode time = doc.CreateElement("Time");
            time.InnerText = this.Time.ToString();
            scoreNode.AppendChild(time);

            XmlNode date = doc.CreateElement("Date");
            date.InnerText = this.Date;
            scoreNode.AppendChild(date);

            doc.DocumentElement.AppendChild(scoreNode);
            doc.Save(path);
            
        }
        public static List<Score> ReturnScores()
        {
            string path = Environment.CurrentDirectory + "\\Data\\Scores\\Scores.xml";
            List<Score> listAllEntries = new List<Score>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Score>));

            using (StreamReader reader = new StreamReader(path))
            {
                listAllEntries = (List<Score>)serializer.Deserialize(reader);
            }

            return listAllEntries;
        }
    }
}
