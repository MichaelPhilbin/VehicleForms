using Inheritance;
using System;
using System.IO;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace VehicleTester
{
    public partial class VehicleForm : Form
    {
        private const string _VEHICLE_FILE_PATH = @"C:\Users\micha\source\repos\Inheritance\Inheritance\data\VehicleDB.txt";
        private const string _AUTOMOBILE_FILE_PATH = @"C:\Users\micha\source\repos\Inheritance\Inheritance\data\AutomobileDB.txt";
        private List<Vehicle> Vehicles = new List<Vehicle>();
        private StreamWriter vehicleWriter;
        private StreamWriter automobileWriter;
        private StreamWriter watercraftWriter;
        private StreamWriter aircraftWriter;
        public VehicleForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            vehicleWriter = Vehicle.OpenTSV(_VEHICLE_FILE_PATH);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            vehicleWriter?.Close();
            base.OnClosed(e);
        }

        private void automobileTickbox_CheckedChanged(object sender, EventArgs e)
        {
            watercraftTickbox.Enabled = !watercraftTickbox.Enabled;
            aircraftTickbox.Enabled = !aircraftTickbox.Enabled;

            prompt1.Text = "Type (Truck,Van,etc...):";  prompt1.Visible = !prompt1.Visible;
            prompt2.Text = "Make:";                     prompt2.Visible = !prompt2.Visible;
            prompt3.Text = "Model:";                    prompt3.Visible = !prompt3.Visible;

            textbox1.Visible = !textbox1.Visible;
            textbox2.Visible = !textbox2.Visible;
            textbox3.Visible = !textbox3.Visible;
            

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (mileagePrompt.Text == "")
            {
                MessageBox.Show("Please provide an input for Mileage.");
                return;
            }
            if (!double.TryParse(mileageTextbox.Text.Trim(), out double mileage))
            {
                MessageBox.Show("Please enter a valid number for mileage.\n User Input: " + mileageTextbox.Text.Trim());
                return;
            }
            if (vinTextbox.Text == "")
            {
                MessageBox.Show("Please provide an input for Vin Number.");
                return;
            }
            if (!int.TryParse(vinTextbox.Text.Trim(), out int vin))
            {
                MessageBox.Show("Please enter a valid integer for vin.\n User Input: " + vinTextbox.Text.Trim());
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
                    MessageBox.Show("Please provide an input for Automobile Type.");
                    return;
                }
                if (textbox2.Text == "")
                {
                    MessageBox.Show("Please provide an input for Make.");
                    return;
                }
                if (textbox3.Text == "")
                {
                    MessageBox.Show("Please provide an input for Model.");
                    return;
                }

                Automobile a = new Automobile(mileage,
                                              vin,
                                              nameTextbox.Text.Trim(),
                                              DateOnly.FromDateTime(dateMadeCalendar.SelectionStart),
                                              DateOnly.FromDateTime(dateBoughtCalendar.SelectionStart),
                                              textbox1.Text.Trim(),
                                              textbox2.Text.Trim(),
                                              textbox3.Text.Trim());

                DialogResult dr = MessageBox.Show("Mileage: " + a.Mileage.ToString() + "\n" +
                                                  "Vin: " + a.Vin.ToString() + "\n" +
                                                  "Owner's Name: " + a.Owner + "\n" +
                                                  "Date Made: " + a.DateMade + "\n" +
                                                  "Date Bought: " + a.DateSold + "\n" +
                                                  "Automobile Type: " + a.Type + "\n" +
                                                  "Make: " + a.Make + "\n" +
                                                  "Model: " + a.Model + "\n",
                                                  "Confirmation Prompt",
                                                  MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    Vehicles.Add( a );
                    automobileWriter = Vehicle.OpenTSV(_AUTOMOBILE_FILE_PATH);
                    a.WriteRow([vehicleWriter, automobileWriter]);
                    automobileWriter?.Close();

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
