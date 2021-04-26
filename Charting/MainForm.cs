using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public List<KeyValuePair<string, string>> GetCurrentProperties()
        {
            List<KeyValuePair<string, string>> properties = new List<KeyValuePair<string, string>>();

            properties.Add(new KeyValuePair<string, string>("Width", MainChart.Width.ToString()));
            properties.Add(new KeyValuePair<string, string>("Height", MainChart.Height.ToString()));
            properties.Add(new KeyValuePair<string, string>("Title", MainChart.Titles[0].Text));
            properties.Add(new KeyValuePair<string, string>("SeriesName", MainChart.Series[0].Name));

            return properties;
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
            foreach (KeyValuePair<string, int> piece in allData)
            {
                MainChart.Series[0].Points.AddXY(piece.Key, piece.Value);
            }
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
    }
}
