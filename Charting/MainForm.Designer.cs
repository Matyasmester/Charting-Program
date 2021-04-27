namespace Charting
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ManageDataButton = new System.Windows.Forms.Button();
            this.ChartPropertiesButton = new System.Windows.Forms.Button();
            this.LoadChartButton = new System.Windows.Forms.Button();
            this.SaveChartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // MainChart
            // 
            this.MainChart.BorderlineColor = System.Drawing.Color.Black;
            this.MainChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.MainChart.BorderlineWidth = 2;
            chartArea3.Name = "ChartArea1";
            this.MainChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.MainChart.Legends.Add(legend3);
            this.MainChart.Location = new System.Drawing.Point(12, 26);
            this.MainChart.Name = "MainChart";
            series3.ChartArea = "ChartArea1";
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series3.Legend = "Legend1";
            series3.Name = "Default";
            this.MainChart.Series.Add(series3);
            this.MainChart.Size = new System.Drawing.Size(920, 560);
            this.MainChart.TabIndex = 0;
            this.MainChart.Text = "chart1";
            this.MainChart.Click += new System.EventHandler(this.Chart1_Click);
            // 
            // ManageDataButton
            // 
            this.ManageDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ManageDataButton.Location = new System.Drawing.Point(954, 63);
            this.ManageDataButton.Name = "ManageDataButton";
            this.ManageDataButton.Size = new System.Drawing.Size(420, 48);
            this.ManageDataButton.TabIndex = 1;
            this.ManageDataButton.Text = "Manage Data";
            this.ManageDataButton.UseVisualStyleBackColor = true;
            this.ManageDataButton.Click += new System.EventHandler(this.ManageDataButton_Click);
            // 
            // ChartPropertiesButton
            // 
            this.ChartPropertiesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChartPropertiesButton.Location = new System.Drawing.Point(954, 194);
            this.ChartPropertiesButton.Name = "ChartPropertiesButton";
            this.ChartPropertiesButton.Size = new System.Drawing.Size(420, 48);
            this.ChartPropertiesButton.TabIndex = 2;
            this.ChartPropertiesButton.Text = "Chart Properties";
            this.ChartPropertiesButton.UseVisualStyleBackColor = true;
            this.ChartPropertiesButton.Click += new System.EventHandler(this.ChartPropertiesButton_Click);
            // 
            // LoadChartButton
            // 
            this.LoadChartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadChartButton.Location = new System.Drawing.Point(954, 467);
            this.LoadChartButton.Name = "LoadChartButton";
            this.LoadChartButton.Size = new System.Drawing.Size(420, 48);
            this.LoadChartButton.TabIndex = 4;
            this.LoadChartButton.Text = "Load Chart";
            this.LoadChartButton.UseVisualStyleBackColor = true;
            this.LoadChartButton.Click += new System.EventHandler(this.LoadChartButton_Click);
            // 
            // SaveChartButton
            // 
            this.SaveChartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveChartButton.Location = new System.Drawing.Point(954, 336);
            this.SaveChartButton.Name = "SaveChartButton";
            this.SaveChartButton.Size = new System.Drawing.Size(420, 48);
            this.SaveChartButton.TabIndex = 3;
            this.SaveChartButton.Text = "Save Chart";
            this.SaveChartButton.UseVisualStyleBackColor = true;
            this.SaveChartButton.Click += new System.EventHandler(this.SaveChartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 641);
            this.Controls.Add(this.LoadChartButton);
            this.Controls.Add(this.SaveChartButton);
            this.Controls.Add(this.ChartPropertiesButton);
            this.Controls.Add(this.ManageDataButton);
            this.Controls.Add(this.MainChart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Charting";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.Button ManageDataButton;
        private System.Windows.Forms.Button ChartPropertiesButton;
        private System.Windows.Forms.Button LoadChartButton;
        private System.Windows.Forms.Button SaveChartButton;
    }
}

