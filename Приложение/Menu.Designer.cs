namespace Приложение
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(32, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Случайные величины";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.button2.Location = new System.Drawing.Point(32, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(275, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Случайные процессы";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.button3.Location = new System.Drawing.Point(32, 256);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(275, 43);
            this.button3.TabIndex = 3;
            this.button3.Text = "Линейные системы";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.button4.Location = new System.Drawing.Point(32, 321);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(275, 59);
            this.button4.TabIndex = 4;
            this.button4.Text = "Статистические эксперименты над ЭВМ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.button5.Location = new System.Drawing.Point(32, 401);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(275, 43);
            this.button5.TabIndex = 5;
            this.button5.Text = "Сумма простейших потоков";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "Теория вероятностей";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.button6.Location = new System.Drawing.Point(125, 450);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 34);
            this.button6.TabIndex = 7;
            this.button6.Text = "Выход";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button7.Location = new System.Drawing.Point(260, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(93, 34);
            this.button7.TabIndex = 8;
            this.button7.Text = "Об авторе";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Приложение.Properties.Resources.фон;
            this.ClientSize = new System.Drawing.Size(365, 496);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Menu";
            this.Text = "Главное меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

