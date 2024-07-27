namespace Recycle_store
{
    partial class FirstWindow
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
            this.Entry = new System.Windows.Forms.Button();
            this.Registration = new System.Windows.Forms.Button();
            this.Creater = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Entry
            // 
            this.Entry.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Entry.Location = new System.Drawing.Point(120, 12);
            this.Entry.Name = "Entry";
            this.Entry.Size = new System.Drawing.Size(222, 42);
            this.Entry.TabIndex = 0;
            this.Entry.Text = "Вход";
            this.Entry.UseVisualStyleBackColor = true;
            this.Entry.Click += new System.EventHandler(this.Entry_Click);
            // 
            // Registration
            // 
            this.Registration.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Registration.Location = new System.Drawing.Point(120, 60);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(222, 45);
            this.Registration.TabIndex = 1;
            this.Registration.Text = "Регистрация";
            this.Registration.UseVisualStyleBackColor = true;
            this.Registration.Click += new System.EventHandler(this.Registration_Click);
            // 
            // Creater
            // 
            this.Creater.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Creater.Location = new System.Drawing.Point(312, 284);
            this.Creater.Name = "Creater";
            this.Creater.Size = new System.Drawing.Size(113, 45);
            this.Creater.TabIndex = 2;
            this.Creater.Text = "Oб авторе";
            this.Creater.UseVisualStyleBackColor = true;
            this.Creater.Click += new System.EventHandler(this.Creater_Click);
            // 
            // FirstWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Recycle_store.Properties.Resources.Вход;
            this.ClientSize = new System.Drawing.Size(437, 341);
            this.Controls.Add(this.Creater);
            this.Controls.Add(this.Registration);
            this.Controls.Add(this.Entry);
            this.Name = "FirstWindow";
            this.Text = "FirstWindow";
            this.Load += new System.EventHandler(this.FirstWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Entry;
        private System.Windows.Forms.Button Registration;
        private System.Windows.Forms.Button Creater;
    }
}