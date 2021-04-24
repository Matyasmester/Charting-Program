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

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainChart.Series["Default"].Points.AddXY("Ajay", "10000");
            MainChart.Series["Default"].Points.AddXY("Ramesh", "8000");
            MainChart.Series["Default"].Points.AddXY("Ankit", "7000");
            MainChart.Series["Default"].Points.AddXY("Gurmeet", "10000");
            MainChart.Series["Default"].Points.AddXY("Suresh", "8500");

            MainChart.Titles.Add("Salary Chart");

            MainChart.Series["Default"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        public void ApplyProperties(List<KeyValuePair<string, string>> properties)
        {
            MainChart.Width = Convert.ToInt32(properties.Find(x => x.Key.Equals("Width")).Value);
            MainChart.Height = Convert.ToInt32(properties.Find(x => x.Key.Equals("Height")).Value);
            MainChart.Series[0].Name = properties.Find(x => x.Key.Equals("SeriesName")).Value;
        }
        
        private void Chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void ManageDataButton_Click(object sender, EventArgs e)
        {
            var form = new ManageDataDialog();
            form.ShowDialog(this);
        }

        private void ChartPropertiesButton_Click(object sender, EventArgs e)
        {
            var form = new ChartPropertiesDialog(this);
            form.ShowDialog(this);
        }
    }
}
