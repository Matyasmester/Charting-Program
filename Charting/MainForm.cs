using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Charting
{
    public partial class MainForm : Form
    {
        private const string DataEnd = "<EndData>";

        public MainForm()
        {
            InitializeComponent();
        }

        List<KeyValuePair<string, int>> DataCache = new List<KeyValuePair<string, int>>();

        public List<KeyValuePair<string, string>> GetCurrentProperties()
        {
            List<KeyValuePair<string, string>> properties = new List<KeyValuePair<string, string>>();

            properties.Add(new KeyValuePair<string, string>("Width", MainChart.Width.ToString()));
            properties.Add(new KeyValuePair<string, string>("Height", MainChart.Height.ToString()));
            properties.Add(new KeyValuePair<string, string>("Title", MainChart.Titles[0].Text));
            properties.Add(new KeyValuePair<string, string>("SeriesName", MainChart.Series[0].Name));

            return properties;
        }

        public void SaveCache(List<KeyValuePair<string, int>> cache)
        {
            DataCache = cache;
        }

        public List<KeyValuePair<string, int>> LoadCache()
        {
            return DataCache;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Font font = new Font("Microsoft Sans Serif", 12f);

            MainChart.Titles.Add("title");

            MainChart.Titles[0].Font = font;

            MainChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        public void ApplyProperties(List<KeyValuePair<string, string>> properties)
        {
            string width = properties.Find(x => x.Key.Equals("Width")).Value;
            string height = properties.Find(x => x.Key.Equals("Height")).Value;

            MainChart.Width = width == string.Empty ? MainChart.Width : Convert.ToInt32(width);
            MainChart.Height = height == string.Empty ? MainChart.Height : Convert.ToInt32(height);

            MainChart.Series[0].Name = properties.Find(x => x.Key.Equals("SeriesName")).Value;

            MainChart.Titles.Clear();
            MainChart.Titles.Add(properties.Find(x => x.Key.Equals("Title")).Value);
            MainChart.Titles[0].Font = new Font("Microsoft Sans Serif", 12f);
        }

        public void ApplyData(List<KeyValuePair<string, int>> allData)
        {
            MainChart.Series[0].Points.Clear();
            foreach (KeyValuePair<string, int> piece in allData)
            {
                MainChart.Series[0].Points.AddXY(piece.Key, piece.Value);
            }
        }

        public void SaveChart(string path)
        {
            List<string> lines = new List<string>();

            foreach (KeyValuePair<string, int> data in DataCache)
            {
                lines.Add(data.Key);
                lines.Add(data.Value.ToString());
            }

            lines.Add(DataEnd);

            foreach (KeyValuePair<string, string> prop in GetCurrentProperties())
            {
                lines.Add(prop.Key);
                lines.Add(prop.Value);
            }
            File.WriteAllLines(path, lines);
        }

        private void LoadChart()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            string path = string.Empty;

            if (result == DialogResult.OK) path = dialog.FileName;

            string[] lines = File.ReadAllLines(path);

            List<KeyValuePair<string, int>> cache = new List<KeyValuePair<string, int>>();

            List<KeyValuePair<string, string>> properties = new List<KeyValuePair<string, string>>();

            int dataEndIndex = Array.IndexOf(lines, DataEnd);

            for (int i = 0; i < lines.Length - 1; i++)
            {
                string line = lines[i];
                string next = lines[i + 1];
                if (!line.Equals(DataEnd) && !next.Equals(DataEnd) && i < dataEndIndex && i % 2 == 0)
                {
                    cache.Add(new KeyValuePair<string, int>(line, Convert.ToInt32(next)));
                }
                if (i > dataEndIndex && i % 2 != 0)
                {
                    properties.Add(new KeyValuePair<string, string>(line, next));
                }
            }

            ApplyData(cache);
            ApplyProperties(properties);
        }
        
        private void Chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void ManageDataButton_Click(object sender, EventArgs e)
        {
            var form = new ManageDataDialog(this);
            form.ShowDialog(this);
        }

        private void ChartPropertiesButton_Click(object sender, EventArgs e)
        {
            var form = new ChartPropertiesDialog(this);
            form.ShowDialog(this);
        }

        private void SaveChartButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveChartDialog(this);
            dialog.ShowDialog(this);
        }

        private void LoadChartButton_Click(object sender, EventArgs e)
        {
            LoadChart();
        }
    }
}
