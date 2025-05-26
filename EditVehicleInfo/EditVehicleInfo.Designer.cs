namespace EditVehicleInfo
{
    partial class EditVehicleInfo
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
            automoblieRadioButton = new RadioButton();
            watercraftRadioButton = new RadioButton();
            aircraftRadioButton = new RadioButton();
            maskedTextBox1 = new MaskedTextBox();
            vehicleDataGridView = new DataGridView();
            confirmButton = new Button();
            ((System.ComponentModel.ISupportInitialize)vehicleDataGridView).BeginInit();
            SuspendLayout();
            // 
            // automoblieRadioButton
            // 
            automoblieRadioButton.AutoSize = true;
            automoblieRadioButton.Location = new Point(12, 45);
            automoblieRadioButton.Name = "automoblieRadioButton";
            automoblieRadioButton.Size = new Size(109, 24);
            automoblieRadioButton.TabIndex = 0;
            automoblieRadioButton.TabStop = true;
            automoblieRadioButton.Text = "Automoblie";
            automoblieRadioButton.UseVisualStyleBackColor = true;
            automoblieRadioButton.CheckedChanged += automoblieRadioButton_CheckedChanged;
            // 
            // watercraftRadioButton
            // 
            watercraftRadioButton.AutoSize = true;
            watercraftRadioButton.Location = new Point(127, 45);
            watercraftRadioButton.Name = "watercraftRadioButton";
            watercraftRadioButton.Size = new Size(99, 24);
            watercraftRadioButton.TabIndex = 1;
            watercraftRadioButton.TabStop = true;
            watercraftRadioButton.Text = "Watercraft";
            watercraftRadioButton.UseVisualStyleBackColor = true;
            // 
            // aircraftRadioButton
            // 
            aircraftRadioButton.AutoSize = true;
            aircraftRadioButton.Location = new Point(232, 45);
            aircraftRadioButton.Name = "aircraftRadioButton";
            aircraftRadioButton.Size = new Size(79, 24);
            aircraftRadioButton.TabIndex = 2;
            aircraftRadioButton.TabStop = true;
            aircraftRadioButton.Text = "Aircraft";
            aircraftRadioButton.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(12, 12);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.ResetOnSpace = false;
            maskedTextBox1.Size = new Size(1107, 27);
            maskedTextBox1.TabIndex = 3;
            maskedTextBox1.Text = "Select a Type of Vehicle to Search Through.";
            // 
            // vehicleDataGridView
            // 
            vehicleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            vehicleDataGridView.Location = new Point(12, 75);
            vehicleDataGridView.Name = "vehicleDataGridView";
            vehicleDataGridView.RowHeadersWidth = 51;
            vehicleDataGridView.Size = new Size(1107, 448);
            vehicleDataGridView.TabIndex = 4;
            vehicleDataGridView.CellContentClick += vehicleDataGridView_CellContentClick;
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(12, 529);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(143, 29);
            confirmButton.TabIndex = 5;
            confirmButton.Text = "Confirm Changes";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // EditVehicleInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(1131, 569);
            Controls.Add(confirmButton);
            Controls.Add(vehicleDataGridView);
            Controls.Add(maskedTextBox1);
            Controls.Add(aircraftRadioButton);
            Controls.Add(watercraftRadioButton);
            Controls.Add(automoblieRadioButton);
            Name = "EditVehicleInfo";
            Text = "Edit Vehicle Info";
            ((System.ComponentModel.ISupportInitialize)vehicleDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton automoblieRadioButton;
        private RadioButton watercraftRadioButton;
        private RadioButton aircraftRadioButton;
        private MaskedTextBox maskedTextBox1;
        private DataGridView vehicleDataGridView;
        private Button confirmButton;
    }
}
