using Inheritance;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EditVehicleInfo
{
    public partial class EditVehicleInfo : Form
    {
        private const string _VEHICLE_FILE_PATH = @"C:\Users\micha\source\repos\Inheritance\Inheritance\data\VehicleDB.txt";
        private const string _AUTOMOBILE_FILE_PATH = @"C:\Users\micha\source\repos\Inheritance\Inheritance\data\AutomobileDB.txt";
        private List<Vehicle> Vehicles = new List<Vehicle>();
        private List<Automobile> Automobiles = new List<Automobile>();
        private DataTable AutomobilesDT = new DataTable();
        public EditVehicleInfo()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            vehicleDataGridView.AllowUserToAddRows = false;
            //(Vehicles, List<string> errorListV) = Vehicle.LoadVehiclesFile(_VEHICLE_FILE_PATH);
            //(Automobiles, List<string> errorListAu) = Automobile.LoadAutomobilesFile(_AUTOMOBILE_FILE_PATH, Vehicles.ToDictionary(v => v.Vin, v => v));
            //(Watercraft, List<string> errorList) = Watercraft.LoadVehiclesFile(_VEHICLE_FILE_PATH);
            //(Aircraft, List<string> errorList) = Aircraft.LoadVehiclesFile(_VEHICLE_FILE_PATH);
            base.OnLoad(e);
            //if (errorListV.Count() > 0 || errorListAu.Count() > 0) MessageBox.Show(string.Join('\n', errorListV.Concat(errorListAu).ToList()));
        }
        private void vehicleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void automoblieRadioButton_CheckedChanged(object sender, EventArgs e)
        {   
            AutomobilesDT.Columns.Add("Vin", typeof(string));
            AutomobilesDT.Columns.Add("Owner", typeof(string));
            AutomobilesDT.Columns.Add("Mileage", typeof(double));
            AutomobilesDT.Columns.Add("DateMade", typeof(DateOnly));
            AutomobilesDT.Columns.Add("DateSold", typeof(DateOnly));
            AutomobilesDT.Columns.Add("Type", typeof(string));
            AutomobilesDT.Columns.Add("Make", typeof(string));
            AutomobilesDT.Columns.Add("Model", typeof(string));

            vehicleDataGridView.DataSource = AutomobilesDT;

        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            

        }
    }
}
