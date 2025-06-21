using Inheritance;
using System;
using System.IO;
using System.ComponentModel;
using System.Reflection.Metadata;
using Npgsql;

namespace VehicleTester
{
    public partial class VehicleForm : Form
    {
        private NpgsqlConnection Conn;
        private List<Vehicle> Vehicles = new List<Vehicle>();

        public VehicleForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var password = Environment.GetEnvironmentVariable("PG_PASSWORD");
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Error: Environment variable PG_PASSWORD is not set!");
            }
            string connString = $"Host=localhost;Username=postgres;Password={password};Database=vehicle_data";

            Conn = new NpgsqlConnection(connString);
            Conn.Open();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Conn.Close();
            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void automobileTickbox_CheckedChanged(object sender, EventArgs e)
        {
            watercraftTickbox.Enabled = !watercraftTickbox.Enabled;
            aircraftTickbox.Enabled = !aircraftTickbox.Enabled;

            prompt1.Text = "Vin:"; prompt1.Visible = !prompt1.Visible;
            prompt2.Text = "Type (Truck,Van,etc...):"; prompt2.Visible = !prompt2.Visible;
            prompt3.Text = "Make:"; prompt3.Visible = !prompt3.Visible;
            prompt4.Text = "Model:"; prompt4.Visible = !prompt4.Visible;

            textbox1.Visible = !textbox1.Visible;
            textbox2.Visible = !textbox2.Visible;
            textbox3.Visible = !textbox3.Visible;
            textbox4.Visible = !textbox4.Visible;


        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (mileagePrompt.Text == "")
            {
                MessageBox.Show("Please provide an input for Mileage.");
                return;
            }
            if (!int.TryParse(mileageTextbox.Text.Trim(), out int mileage))
            {
                MessageBox.Show("Please enter a valid number for mileage.\n User Input: " + mileageTextbox.Text.Trim());
                return;
            }
            if (nameTextbox.Text == "")
            {
                MessageBox.Show("Please provide an input for Owner's Name.");
                return;
            }

            if (automobileTickbox.Checked)
            {
                if (textbox1.Text == "")
                {
                    MessageBox.Show("Please provide an input for Vin.");
                    return;
                }
                if (textbox1.Text.Trim().Length != 17)
                {
                    MessageBox.Show("Please enter a valid string for vin.\n" +
                                    "Input Length: " + textbox1.Text.Trim().Length + ".\n" +
                                    "Length Needed: 17.");
                    return;
                }
                char[] toCheck = { 'O', 'Q', 'I' };
                if (toCheck.Any(c => textbox1.Text.Trim().Contains(c)))
                {
                    MessageBox.Show("Please enter a valid string for vin.\n" +
                                    "Input contained at least one (O, Q, or I).\n" +
                                    "Valid vin numbers do not contain these chars.");
                    return;
                }
                if (textbox2.Text == "")
                {
                    MessageBox.Show("Please provide an input for Automobile Type.");
                    return;
                }
                if (textbox3.Text == "")
                {
                    MessageBox.Show("Please provide an input for Make.");
                    return;
                }
                if (textbox4.Text == "")
                {
                    MessageBox.Show("Please provide an input for Model.");
                    return;
                }

                Automobile a = new Automobile(mileage,
                                              nameTextbox.Text.Trim(),
                                              DateOnly.FromDateTime(dateMadeCalendar.SelectionStart),
                                              DateOnly.FromDateTime(dateBoughtCalendar.SelectionStart),
                                              textbox1.Text.Trim(),
                                              textbox2.Text.Trim(),
                                              textbox3.Text.Trim(),
                                              textbox4.Text.Trim());

                DialogResult dr = MessageBox.Show("Mileage: " + a.Mileage.ToString() + "\n" +
                                                  "Owner's Name: " + a.Owner + "\n" +
                                                  "Date Made: " + a.DateMade + "\n" +
                                                  "Date Bought: " + a.DateSold + "\n" +
                                                  "Vin: " + a.Vin + "\n" +
                                                  "Automobile Type: " + a.Type + "\n" +
                                                  "Make: " + a.Make + "\n" +
                                                  "Model: " + a.Model + "\n",
                                                  "Confirmation Prompt",
                                                  MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    Vehicles.Add(a);

                    a.WriteRow(Conn);


                    MessageBox.Show("Information Submitted.");
                }


                return;
            }

            MessageBox.Show("Please select a Vehicle Type check box, and then enter the further relevant information.");
        }

        private void watercraftTickbox_CheckedChanged(object sender, EventArgs e)
        {
            automobileTickbox.Enabled = !automobileTickbox.Enabled;
            aircraftTickbox.Enabled = !aircraftTickbox.Enabled;
        }

        private void aircraftTickbox_CheckedChanged(object sender, EventArgs e)
        {
            watercraftTickbox.Enabled = !watercraftTickbox.Enabled;
            automobileTickbox.Enabled = !automobileTickbox.Enabled;
        }
    }
}
