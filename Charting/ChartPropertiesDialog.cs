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
    public partial class ChartPropertiesDialog : Form
    {
        MainForm active;
        List<KeyValuePair<string, string>> allProperties = new List<KeyValuePair<string, string>>();

        private void StateCurrentProperties(List<KeyValuePair<string, string>> properties)
        {
            WidthBox.Value = Convert.ToInt32(properties.Find(x => x.Key.Equals("Width")).Value);
            HeightBox.Value = Convert.ToInt32(properties.Find(x => x.Key.Equals("Height")).Value);

            SeriesNameBox.Text = properties.Find(x => x.Key.Equals("SeriesName")).Value;
            ChartTitleBox.Text = properties.Find(x => x.Key.Equals("Title")).Value;
        }
        public ChartPropertiesDialog(MainForm mainForm)
        {
            InitializeComponent();
            active = mainForm;
            StateCurrentProperties(active.GetCurrentProperties());
        }

        public delegate void PassProperties(List<KeyValuePair<string, string>> properties);

        private void ChartPropertiesDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void SendProperties()
        {
            //TODO: MORE PROPERTIES (eg: border)
            allProperties.Add(new KeyValuePair<string, string>("Width", WidthBox.Text));
            allProperties.Add(new KeyValuePair<string, string>("Height", HeightBox.Text));
            allProperties.Add(new KeyValuePair<string, string>("SeriesName", SeriesNameBox.Text));
            allProperties.Add(new KeyValuePair<string, string>("Title", ChartTitleBox.Text));
            PassProperties pass = new PassProperties(active.ApplyProperties);
            pass(allProperties);
            allProperties.Clear();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            SendProperties();
            this.Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SendProperties();
        }
    }
}
