namespace Recycle_store
{
    partial class Registration
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
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.DOB = new System.Windows.Forms.DateTimePicker();
            this.MidleName = new System.Windows.Forms.TextBox();
            this.Organization = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FirstName
            // 
            this.FirstName.BackColor = System.Drawing.Color.SteelBlue;
            this.FirstName.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstName.ForeColor = System.Drawing.Color.LightSalmon;
            this.FirstName.Location = new System.Drawing.Point(122, 301);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(155, 25);
            this.FirstName.TabIndex = 0;
            this.FirstName.Text = "Имя";
            // 
            // LastName
            // 
            this.LastName.BackColor = System.Drawing.Color.SteelBlue;
            this.LastName.Font = new System.Drawing.Font("Palatino Linotype", 7.8F);
            this.LastName.ForeColor = System.Drawing.Color.LightSalmon;
            this.LastName.Location = new System.Drawing.Point(122, 253);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(155, 25);
            this.LastName.TabIndex = 1;
            this.LastName.Text = "Фамилия";
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonRegistration.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegistration.ForeColor = System.Drawing.Color.LightSalmon;
            this.buttonRegistration.Location = new System.Drawing.Point(121, 520);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(156, 34);
            this.buttonRegistration.TabIndex = 2;
            this.buttonRegistration.Text = "Зарегистрироваться";
            this.buttonRegistration.UseVisualStyleBackColor = false;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // DOB
            // 
            this.DOB.CalendarForeColor = System.Drawing.Color.Indigo;
            this.DOB.CalendarMonthBackground = System.Drawing.Color.Wheat;
            this.DOB.CalendarTitleBackColor = System.Drawing.Color.Wheat;
            this.DOB.CalendarTitleForeColor = System.Drawing.Color.Wheat;
            this.DOB.CalendarTrailingForeColor = System.Drawing.Color.Wheat;
            this.DOB.Location = new System.Drawing.Point(98, 435);
            this.DOB.Name = "DOB";
            this.DOB.Size = new System.Drawing.Size(200, 22);
            this.DOB.TabIndex = 3;
            // 
            // MidleName
            // 
            this.MidleName.BackColor = System.Drawing.Color.SteelBlue;
            this.MidleName.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MidleName.ForeColor = System.Drawing.Color.LightSalmon;
            this.MidleName.Location = new System.Drawing.Point(122, 346);
            this.MidleName.Name = "MidleName";
            this.MidleName.Size = new System.Drawing.Size(155, 25);
            this.MidleName.TabIndex = 6;
            this.MidleName.Text = "Отчество";
            // 
            // Organization
            // 
            this.Organization.BackColor = System.Drawing.Color.SteelBlue;
            this.Organization.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Organization.ForeColor = System.Drawing.Color.LightSalmon;
            this.Organization.Location = new System.Drawing.Point(122, 472);
            this.Organization.Name = "Organization";
            this.Organization.Size = new System.Drawing.Size(155, 25);
            this.Organization.TabIndex = 9;
            this.Organization.Text = "Организация";
            // 
            // Phone
            // 
            this.Phone.BackColor = System.Drawing.Color.SteelBlue;
            this.Phone.Font = new System.Drawing.Font("Palatino Linotype", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Phone.ForeColor = System.Drawing.Color.LightSalmon;
            this.Phone.Location = new System.Drawing.Point(122, 387);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(155, 25);
            this.Phone.TabIndex = 10;
            this.Phone.Text = "Номер телефона";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 19.8F);
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(90, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "Регистрация";
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Recycle_store.Properties.Resources.куинджи;
            this.ClientSize = new System.Drawing.Size(389, 582);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.Organization);
            this.Controls.Add(this.MidleName);
            this.Controls.Add(this.DOB);
            this.Controls.Add(this.buttonRegistration);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.DateTimePicker DOB;
        private System.Windows.Forms.TextBox MidleName;
        private System.Windows.Forms.TextBox Organization;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Label label1;
    }
}