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
    public partial class SaveChartDialog : Form
    {
        MainForm active;

        string currentFullPath = string.Empty;
        const string ext = ".txt";

        public SaveChartDialog(MainForm mainForm)
        {
            InitializeComponent();
            active = mainForm;
        }

        private void SaveChartDialog_Load(object sender, EventArgs e)
        {

        }

        private void ChooseFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;

            DialogResult result = dialog.ShowDialog(this);

            string path = dialog.SelectedPath + @"\" + FileNameBox.Text;

            if (result == DialogResult.OK) currentFullPath = FileNameBox.Text.Contains(ext) ? path : path + ext; 

            CurrentPathLabel.Text = currentFullPath;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            active.SaveChart(currentFullPath);
            this.Close();
        }
    }
}
