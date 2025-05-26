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
            (Vehicles, List<string> errorListV) = Vehicle.LoadVehiclesFile(_VEHICLE_FILE_PATH);
            (Automobiles, List<string> errorListAu) = Automobile.LoadAutomobilesFile(_AUTOMOBILE_FILE_PATH, Vehicles.ToDictionary(v => v.Vin, v => v));
            //(Watercraft, List<string> errorList) = Watercraft.LoadVehiclesFile(_VEHICLE_FILE_PATH);
            //(Aircraft, List<string> errorList) = Aircraft.LoadVehiclesFile(_VEHICLE_FILE_PATH);
            base.OnLoad(e);
            if (errorListV.Count() > 0 || errorListAu.Count() > 0) MessageBox.Show(string.Join('\n', errorListV.Concat(errorListAu).ToList()));
        }


        private void vehicleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //vehicleDataGridView;
        }

        private void automoblieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AutomobilesDT.Columns.Add("Vin", typeof(int));
            AutomobilesDT.Columns.Add("Owner", typeof(string));
            AutomobilesDT.Columns.Add("Mileage", typeof(double));
            AutomobilesDT.Columns.Add("DateMade", typeof(DateOnly));
            AutomobilesDT.Columns.Add("DateSold", typeof(DateOnly));
            AutomobilesDT.Columns.Add("Type", typeof(string));
            AutomobilesDT.Columns.Add("Make", typeof(string));
            AutomobilesDT.Columns.Add("Model", typeof(string));

            foreach (var vehicle in Vehicles)
            {
                var auto = Automobiles.FirstOrDefault(a => a.Vin == vehicle.Vin);

                AutomobilesDT.Rows.Add(
                    vehicle.Vin,
                    vehicle.Owner,
                    vehicle.Mileage,
                    vehicle.DateMade,
                    vehicle.DateSold,
                    auto?.Type.Trim() ?? "",
                    auto?.Make.Trim() ?? "",
                    auto?.Model.Trim() ?? ""
                );
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = AutomobilesDT;

            bs.Filter = "Make <> '' OR Model <> '' OR Type <> ''";

            vehicleDataGridView.DataSource = bs;

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText(_VEHICLE_FILE_PATH, string.Empty);
            File.WriteAllText(_AUTOMOBILE_FILE_PATH, string.Empty);

            using (StreamWriter vehicleWriter = Vehicle.OpenTSV(_VEHICLE_FILE_PATH))
            using (StreamWriter automobileWriter = Vehicle.OpenTSV(_AUTOMOBILE_FILE_PATH))
                foreach (DataRow row in AutomobilesDT.Rows)
                {
                    int vin = (int)row["Vin"];
                    string owner = (string)row["Owner"];
                    double mileage = (double)row["Mileage"];
                    DateOnly dateMade = (DateOnly)row["DateMade"];
                    DateOnly dateSold = (DateOnly)row["DateSold"];

                    string make = (string)row["Make"];
                    string model = (string)row["Model"];
                    string type = (string)row["Type"];

                    Vehicle vehicleToAdd;

                    if (!string.IsNullOrWhiteSpace(make) || !string.IsNullOrWhiteSpace(model) || !string.IsNullOrWhiteSpace(type))
                        vehicleToAdd = new Automobile(mileage, vin, owner, dateMade, dateSold, make, model, type);                  
                    else
                        vehicleToAdd = new Vehicle(mileage, vin, owner, dateMade, dateSold);
              
                    vehicleToAdd.WriteRow([vehicleWriter, automobileWriter]);
                }
        }
    }
}
