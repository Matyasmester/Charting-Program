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
        List<NumericUpDown> allValueBoxes = new List<NumericUpDown>();

        List<KeyValuePair<string, int>> allData = new List<KeyValuePair<string, int>>();

        MainForm active;

        List<KeyValuePair<string, int>> cache;

        bool HasSentData = false;

        const int MaxFields = 16;
        const int MinFields = 2;

        int fields = MinFields;

        public delegate void PassData(List<KeyValuePair<string, int>> allData);

        private void SendData()
        {
            PassData pass = new PassData(active.ApplyData);

            for (int i = 0; i < allNameBoxes.Count; i++)
            {
                KeyValuePair<string, int> data = new KeyValuePair<string, int>(allNameBoxes[i].Text, (int)allValueBoxes[i].Value);
                allData.Add(data);
            }

            if (cache.All(allData.Contains) && cache.Count == allData.Count) return;

            active.SaveCache(allData);

            pass(allData);
        }

        private void CreateNewNameBox()
        {
            TextBox newNameBox = new TextBox();
            allNameBoxes.Add(newNameBox);
            TextBox previousN = allNameBoxes[allNameBoxes.IndexOf(newNameBox) - 1];
            Point newNLocation = new Point(previousN.Location.X, previousN.Location.Y + 40);
            newNameBox.Location = newNLocation;

            newNameBox.TextAlign = HorizontalAlignment.Center;

            this.Controls.Add(newNameBox);
        }

        private void CreateNewValueBox()
        {
            NumericUpDown newValueBox = new NumericUpDown();
            allValueBoxes.Add(newValueBox);
            NumericUpDown previousV = allValueBoxes[allValueBoxes.IndexOf(newValueBox) - 1];
            Point newVLocation = new Point(previousV.Location.X, previousV.Location.Y + 40);
            newValueBox.Location = newVLocation;

            newValueBox.TextAlign = HorizontalAlignment.Center;

            newValueBox.Maximum = 10000;

            this.Controls.Add(newValueBox);
        }

        private void RemoveLastNameBox()
        {
            TextBox lastN = allNameBoxes.Last();

            allNameBoxes.Remove(lastN);

            this.Controls.Remove(lastN);
        }

        private void RemoveLastValueBox()
        {
            NumericUpDown lastV = allValueBoxes.Last();

            allValueBoxes.Remove(lastV);

            this.Controls.Remove(lastV);
        }

        public ManageDataDialog(MainForm mainForm)
        {
            InitializeComponent();
            allNameBoxes.Add(textBox1);
            allValueBoxes.Add(numericUpDown1);

            active = mainForm;

            cache = active.LoadCache();

            if (!cache.Any()) return;
            else
            {
                foreach (KeyValuePair<string, int> piece in cache)
                {
                    allNameBoxes.Last().Text = piece.Key;
                    allValueBoxes.Last().Value = piece.Value;

                    CreateNewNameBox();
                    CreateNewValueBox();
                }
                RemoveLastNameBox();
                RemoveLastValueBox();
            }
        }

        private void ManageDataDialog_Load(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (HasSentData) this.Close();
            else
            {
                SendData();
                this.Close();
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (HasSentData) return;
            SendData();
            HasSentData = true;
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (fields == MaxFields) return;

            CreateNewNameBox();

            CreateNewValueBox();

            fields = allNameBoxes.Count + allValueBoxes.Count;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (fields == MinFields) return;

            RemoveLastNameBox();

            RemoveLastValueBox();

            fields = allNameBoxes.Count + allValueBoxes.Count;
        }
    }
}
