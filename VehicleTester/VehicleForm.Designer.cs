namespace VehicleTester
{
    partial class VehicleForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mileageTextbox = new TextBox();
            nameTextbox = new TextBox();
            informationPrompt = new MaskedTextBox();
            mileagePrompt = new MaskedTextBox();
            namePrompt = new MaskedTextBox();
            dateMadePrompt = new MaskedTextBox();
            dateBoughtPrompt = new MaskedTextBox();
            dateMadeCalendar = new MonthCalendar();
            dateBoughtCalendar = new MonthCalendar();
            maskedTextBox7 = new MaskedTextBox();
            automobileTickbox = new CheckBox();
            watercraftTickbox = new CheckBox();
            aircraftTickbox = new CheckBox();
            prompt2 = new MaskedTextBox();
            prompt1 = new MaskedTextBox();
            prompt3 = new MaskedTextBox();
            prompt4 = new MaskedTextBox();
            textbox1 = new TextBox();
            textbox2 = new TextBox();
            textbox3 = new TextBox();
            textbox4 = new TextBox();
            enterButton = new Button();
            SuspendLayout();
            // 
            // mileageTextbox
            // 
            mileageTextbox.Location = new Point(240, 45);
            mileageTextbox.Name = "mileageTextbox";
            mileageTextbox.Size = new Size(548, 27);
            mileageTextbox.TabIndex = 0;
            // 
            // nameTextbox
            // 
            nameTextbox.Location = new Point(240, 78);
            nameTextbox.Name = "nameTextbox";
            nameTextbox.Size = new Size(548, 27);
            nameTextbox.TabIndex = 2;
            // 
            // informationPrompt
            // 
            informationPrompt.Location = new Point(12, 12);
            informationPrompt.Name = "informationPrompt";
            informationPrompt.ReadOnly = true;
            informationPrompt.Size = new Size(776, 27);
            informationPrompt.TabIndex = 3;
            informationPrompt.Text = "Please Enter Vehicle Information";
            // 
            // mileagePrompt
            // 
            mileagePrompt.Location = new Point(12, 45);
            mileagePrompt.Name = "mileagePrompt";
            mileagePrompt.ReadOnly = true;
            mileagePrompt.Size = new Size(222, 27);
            mileagePrompt.TabIndex = 4;
            mileagePrompt.Text = "Mileage";
            // 
            // namePrompt
            // 
            namePrompt.Location = new Point(12, 78);
            namePrompt.Name = "namePrompt";
            namePrompt.ReadOnly = true;
            namePrompt.Size = new Size(222, 27);
            namePrompt.TabIndex = 6;
            namePrompt.Text = "Owner's Full Legal Name:";
            // 
            // dateMadePrompt
            // 
            dateMadePrompt.Location = new Point(12, 111);
            dateMadePrompt.Name = "dateMadePrompt";
            dateMadePrompt.ReadOnly = true;
            dateMadePrompt.Size = new Size(262, 27);
            dateMadePrompt.TabIndex = 7;
            dateMadePrompt.Text = "Date Made:";
            // 
            // dateBoughtPrompt
            // 
            dateBoughtPrompt.Location = new Point(280, 111);
            dateBoughtPrompt.Name = "dateBoughtPrompt";
            dateBoughtPrompt.ReadOnly = true;
            dateBoughtPrompt.Size = new Size(262, 27);
            dateBoughtPrompt.TabIndex = 8;
            dateBoughtPrompt.Text = "Date Bought:";
            // 
            // dateMadeCalendar
            // 
            dateMadeCalendar.Location = new Point(12, 150);
            dateMadeCalendar.Name = "dateMadeCalendar";
            dateMadeCalendar.ShowTodayCircle = false;
            dateMadeCalendar.TabIndex = 9;
            // 
            // dateBoughtCalendar
            // 
            dateBoughtCalendar.Location = new Point(280, 150);
            dateBoughtCalendar.Name = "dateBoughtCalendar";
            dateBoughtCalendar.ShowTodayCircle = false;
            dateBoughtCalendar.TabIndex = 10;
            // 
            // maskedTextBox7
            // 
            maskedTextBox7.Location = new Point(12, 369);
            maskedTextBox7.Name = "maskedTextBox7";
            maskedTextBox7.ReadOnly = true;
            maskedTextBox7.Size = new Size(222, 27);
            maskedTextBox7.TabIndex = 11;
            maskedTextBox7.Text = "Select Vehicle Type:";
            // 
            // automobileTickbox
            // 
            automobileTickbox.AutoSize = true;
            automobileTickbox.Location = new Point(240, 372);
            automobileTickbox.Name = "automobileTickbox";
            automobileTickbox.Size = new Size(110, 24);
            automobileTickbox.TabIndex = 12;
            automobileTickbox.Text = "Automoblie";
            automobileTickbox.UseVisualStyleBackColor = true;
            automobileTickbox.CheckedChanged += automobileTickbox_CheckedChanged;
            // 
            // watercraftTickbox
            // 
            watercraftTickbox.AutoSize = true;
            watercraftTickbox.Location = new Point(356, 372);
            watercraftTickbox.Name = "watercraftTickbox";
            watercraftTickbox.Size = new Size(100, 24);
            watercraftTickbox.TabIndex = 13;
            watercraftTickbox.Text = "Watercraft";
            watercraftTickbox.UseVisualStyleBackColor = true;
            watercraftTickbox.CheckedChanged += watercraftTickbox_CheckedChanged;
            // 
            // aircraftTickbox
            // 
            aircraftTickbox.AutoSize = true;
            aircraftTickbox.Location = new Point(462, 372);
            aircraftTickbox.Name = "aircraftTickbox";
            aircraftTickbox.Size = new Size(80, 24);
            aircraftTickbox.TabIndex = 14;
            aircraftTickbox.Text = "Aircraft";
            aircraftTickbox.UseVisualStyleBackColor = true;
            aircraftTickbox.CheckedChanged += aircraftTickbox_CheckedChanged;
            // 
            // prompt2
            // 
            prompt2.Location = new Point(12, 448);
            prompt2.Name = "prompt2";
            prompt2.ReadOnly = true;
            prompt2.Size = new Size(222, 27);
            prompt2.TabIndex = 15;
            prompt2.Text = "Type:";
            prompt2.Visible = false;
            // 
            // prompt1
            // 
            prompt1.Location = new Point(12, 415);
            prompt1.Name = "prompt1";
            prompt1.ReadOnly = true;
            prompt1.Size = new Size(222, 27);
            prompt1.TabIndex = 16;
            prompt1.Text = "Vin:";
            prompt1.Visible = false;
            // 
            // prompt3
            // 
            prompt3.Location = new Point(12, 481);
            prompt3.Name = "prompt3";
            prompt3.ReadOnly = true;
            prompt3.Size = new Size(222, 27);
            prompt3.TabIndex = 17;
            prompt3.Text = "Make:";
            prompt3.Visible = false;
            // 
            // prompt4
            // 
            prompt4.Location = new Point(12, 514);
            prompt4.Name = "prompt4";
            prompt4.ReadOnly = true;
            prompt4.Size = new Size(222, 27);
            prompt4.TabIndex = 18;
            prompt4.Text = "Model:";
            prompt4.Visible = false;
            // 
            // textbox1
            // 
            textbox1.Location = new Point(240, 415);
            textbox1.Name = "textbox1";
            textbox1.Size = new Size(548, 27);
            textbox1.TabIndex = 19;
            textbox1.Visible = false;
            // 
            // textbox2
            // 
            textbox2.Location = new Point(240, 448);
            textbox2.Name = "textbox2";
            textbox2.Size = new Size(548, 27);
            textbox2.TabIndex = 20;
            textbox2.Visible = false;
            // 
            // textbox3
            // 
            textbox3.Location = new Point(240, 481);
            textbox3.Name = "textbox3";
            textbox3.Size = new Size(548, 27);
            textbox3.TabIndex = 21;
            textbox3.Visible = false;
            // 
            // textbox4
            // 
            textbox4.Location = new Point(240, 514);
            textbox4.Name = "textbox4";
            textbox4.Size = new Size(548, 27);
            textbox4.TabIndex = 22;
            textbox4.Visible = false;
            // 
            // enterButton
            // 
            enterButton.Location = new Point(12, 567);
            enterButton.Name = "enterButton";
            enterButton.Size = new Size(222, 26);
            enterButton.TabIndex = 23;
            enterButton.Text = "Enter";
            enterButton.UseVisualStyleBackColor = true;
            enterButton.Click += enterButton_Click;
            // 
            // VehicleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 605);
            Controls.Add(enterButton);
            Controls.Add(textbox4);
            Controls.Add(textbox3);
            Controls.Add(textbox2);
            Controls.Add(textbox1);
            Controls.Add(prompt4);
            Controls.Add(prompt3);
            Controls.Add(prompt1);
            Controls.Add(prompt2);
            Controls.Add(aircraftTickbox);
            Controls.Add(watercraftTickbox);
            Controls.Add(automobileTickbox);
            Controls.Add(maskedTextBox7);
            Controls.Add(dateBoughtCalendar);
            Controls.Add(dateMadeCalendar);
            Controls.Add(dateBoughtPrompt);
            Controls.Add(dateMadePrompt);
            Controls.Add(namePrompt);
            Controls.Add(mileagePrompt);
            Controls.Add(informationPrompt);
            Controls.Add(nameTextbox);
            Controls.Add(mileageTextbox);
            MaximizeBox = false;
            Name = "VehicleForm";
            Text = "Vehicle Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox mileageTextbox;
        private TextBox nameTextbox;
        private MaskedTextBox informationPrompt;
        private MaskedTextBox mileagePrompt;
        private MaskedTextBox namePrompt;
        private MaskedTextBox dateMadePrompt;
        private MaskedTextBox dateBoughtPrompt;
        private MonthCalendar dateMadeCalendar;
        private MonthCalendar dateBoughtCalendar;
        private MaskedTextBox maskedTextBox7;
        private CheckBox automobileTickbox;
        private CheckBox watercraftTickbox;
        private CheckBox aircraftTickbox;
        private MaskedTextBox prompt2;
        private MaskedTextBox prompt1;
        private MaskedTextBox prompt3;
        private MaskedTextBox prompt4;
        private TextBox textbox1;
        private TextBox textbox2;
        private TextBox textbox3;
        private TextBox textbox4;
        private Button enterButton;
    }
}
