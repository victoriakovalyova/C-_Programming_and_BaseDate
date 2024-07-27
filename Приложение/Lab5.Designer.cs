namespace Приложение
{
    partial class Lab5
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.listBox7 = new System.Windows.Forms.ListBox();
            this.listBox8 = new System.Windows.Forms.ListBox();
            this.listBox9 = new System.Windows.Forms.ListBox();
            this.listBox10 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(644, 329);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 22);
            this.textBox1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(621, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "N";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.button3.Location = new System.Drawing.Point(788, 357);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 41);
            this.button3.TabIndex = 17;
            this.button3.Text = "Выполнить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(788, 310);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 41);
            this.button4.TabIndex = 16;
            this.button4.Text = "Задание";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Gray;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.DimGray;
            chartArea1.BackSecondaryColor = System.Drawing.Color.DimGray;
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.chart1.Annotations;
            legend1.BackColor = System.Drawing.Color.DimGray;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.WhiteSmoke;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.Legend = "Legend1";
            series1.Name = "X1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "X2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Y";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(608, 404);
            this.chart1.TabIndex = 15;
            this.chart1.Text = "chart1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(644, 385);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(128, 22);
            this.textBox2.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(617, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "Кол-во записей";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Silver;
            this.listBox1.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(625, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(123, 154);
            this.listBox1.TabIndex = 22;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.Silver;
            this.listBox2.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(774, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(124, 154);
            this.listBox2.TabIndex = 23;
            // 
            // listBox3
            // 
            this.listBox3.BackColor = System.Drawing.Color.Silver;
            this.listBox3.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 15;
            this.listBox3.Location = new System.Drawing.Point(927, 12);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(127, 154);
            this.listBox3.TabIndex = 24;
            // 
            // listBox4
            // 
            this.listBox4.BackColor = System.Drawing.Color.Silver;
            this.listBox4.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 15;
            this.listBox4.Location = new System.Drawing.Point(988, 274);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(163, 64);
            this.listBox4.TabIndex = 25;
            // 
            // listBox5
            // 
            this.listBox5.BackColor = System.Drawing.Color.Silver;
            this.listBox5.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 15;
            this.listBox5.Location = new System.Drawing.Point(1073, 12);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(116, 154);
            this.listBox5.TabIndex = 26;
            // 
            // listBox6
            // 
            this.listBox6.BackColor = System.Drawing.Color.Silver;
            this.listBox6.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.listBox6.FormattingEnabled = true;
            this.listBox6.ItemHeight = 15;
            this.listBox6.Location = new System.Drawing.Point(624, 202);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(124, 64);
            this.listBox6.TabIndex = 27;
            // 
            // listBox7
            // 
            this.listBox7.BackColor = System.Drawing.Color.Silver;
            this.listBox7.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.listBox7.FormattingEnabled = true;
            this.listBox7.ItemHeight = 15;
            this.listBox7.Location = new System.Drawing.Point(754, 202);
            this.listBox7.Name = "listBox7";
            this.listBox7.Size = new System.Drawing.Size(144, 64);
            this.listBox7.TabIndex = 28;
            // 
            // listBox8
            // 
            this.listBox8.BackColor = System.Drawing.Color.Silver;
            this.listBox8.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.listBox8.FormattingEnabled = true;
            this.listBox8.ItemHeight = 15;
            this.listBox8.Location = new System.Drawing.Point(917, 202);
            this.listBox8.Name = "listBox8";
            this.listBox8.Size = new System.Drawing.Size(122, 64);
            this.listBox8.TabIndex = 29;
            // 
            // listBox9
            // 
            this.listBox9.BackColor = System.Drawing.Color.Silver;
            this.listBox9.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.listBox9.FormattingEnabled = true;
            this.listBox9.ItemHeight = 15;
            this.listBox9.Location = new System.Drawing.Point(1073, 202);
            this.listBox9.Name = "listBox9";
            this.listBox9.Size = new System.Drawing.Size(104, 64);
            this.listBox9.TabIndex = 30;
            // 
            // listBox10
            // 
            this.listBox10.BackColor = System.Drawing.Color.Silver;
            this.listBox10.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.listBox10.FormattingEnabled = true;
            this.listBox10.ItemHeight = 15;
            this.listBox10.Location = new System.Drawing.Point(977, 348);
            this.listBox10.Name = "listBox10";
            this.listBox10.Size = new System.Drawing.Size(174, 64);
            this.listBox10.TabIndex = 31;
            // 
            // Lab5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Приложение.Properties.Resources.фон;
            this.ClientSize = new System.Drawing.Size(1201, 425);
            this.Controls.Add(this.listBox10);
            this.Controls.Add(this.listBox9);
            this.Controls.Add(this.listBox8);
            this.Controls.Add(this.listBox7);
            this.Controls.Add(this.listBox6);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.chart1);
            this.Name = "Lab5";
            this.Text = "Сложение простейших потоков";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.ListBox listBox6;
        private System.Windows.Forms.ListBox listBox7;
        private System.Windows.Forms.ListBox listBox8;
        private System.Windows.Forms.ListBox listBox9;
        private System.Windows.Forms.ListBox listBox10;
    }
}