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
    public partial class ManageDataDialog : Form
    {
        List<TextBox> allNameBoxes = new List<TextBox>();
        List<TextBox> allValueBoxes = new List<TextBox>();

        List<KeyValuePair<string, string>> allData = new List<KeyValuePair<string, string>>();

        MainForm active;

        const int MaxFields = 16;
        const int MinFields = 2;

        int fields = MinFields;

        public delegate void PassData(List<KeyValuePair<string, string>> allData);

        private void SendData()
        {
            PassData pass = new PassData(active.ApplyData);

            for (int i = 0; i < allNameBoxes.Count; i++)
            {
                KeyValuePair<string, string> data = new KeyValuePair<string, string>(allNameBoxes[i].Text, allValueBoxes[i].Text);
                allData.Add(data);
            }

            pass(allData);
        }

        public ManageDataDialog(MainForm mainForm)
        {
            InitializeComponent();
            allNameBoxes.Add(textBox1);
            allValueBoxes.Add(textBox2);

            active = mainForm;
        }

        private void ManageDataDialog_Load(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            SendData();
            this.Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SendData();
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (fields == MaxFields) return;

            TextBox newNameBox = new TextBox();
            allNameBoxes.Add(newNameBox);
            TextBox previousN = allNameBoxes[allNameBoxes.IndexOf(newNameBox) - 1];
            Point newNLocation = new Point(previousN.Location.X, previousN.Location.Y + 40);
            newNameBox.Location = newNLocation;

            TextBox newValueBox = new TextBox();
            allValueBoxes.Add(newValueBox);
            TextBox previousV = allValueBoxes[allValueBoxes.IndexOf(newValueBox) - 1];
            Point newVLocation = new Point(previousV.Location.X, previousV.Location.Y + 40);
            newValueBox.Location = newVLocation;

            newNameBox.TextAlign = HorizontalAlignment.Center;
            newValueBox.TextAlign = HorizontalAlignment.Center;

            this.Controls.Add(newValueBox);
            this.Controls.Add(newNameBox);

            fields = allNameBoxes.Count + allValueBoxes.Count;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (fields == MinFields) return; 

            TextBox lastN = allNameBoxes.Last();
            TextBox lastV = allValueBoxes.Last();

            allNameBoxes.Remove(lastN);
            allValueBoxes.Remove(lastV);

            this.Controls.Remove(lastN);
            this.Controls.Remove(lastV);

            fields = allNameBoxes.Count + allValueBoxes.Count;
        }
    }
}
