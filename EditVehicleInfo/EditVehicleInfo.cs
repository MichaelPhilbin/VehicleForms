using Inheritance;
using Npgsql;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EditVehicleInfo
{
    public partial class EditVehicleInfo : Form
    {
        //private List<Vehicle> Vehicles = new List<Vehicle>();
        //private List<Automobile> Automobiles = new List<Automobile>();
        private NpgsqlConnection Conn;
        private DataTable Data = new DataTable();
        public EditVehicleInfo()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            vehicleDataGridView.AllowUserToAddRows = false;
            var password = Environment.GetEnvironmentVariable("PG_PASSWORD");
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Error: Environment variable PG_PASSWORD is not set!");
            }
            string connString = $"Host=localhost;Username=postgres;Password={password};Database=vehicle_data";

            Conn = new NpgsqlConnection(connString);
            Conn.Open();

            base.OnLoad(e);
            
        }
        private void vehicleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void automoblieRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (automoblieRadioButton.Checked)
            {
                Data = Automobile.LoadAutomobilesPG(Conn);
                vehicleDataGridView.DataSource = Data;
                vehicleDataGridView.Columns["vehicle_id"].Visible = false;
                var columnsInOrderA = new[]
                {
                "vin",
                "make",
                "model",
                
                };

                for (int i = 0+6; i < columnsInOrderA.Length; i++)
                {
                    var columnName = columnsInOrderA[i];
                    if (vehicleDataGridView.Columns.Contains(columnName))
                    {
                        vehicleDataGridView.Columns[columnName].DisplayIndex = i;
                    }
                }
            }
            if (watercraftRadioButton.Checked)
            {
                Data = Vehicle.LoadVehiclesPG(Conn);
                vehicleDataGridView.DataSource = Data;
            }
            if (aircraftRadioButton.Checked)
            {
                Data = Vehicle.LoadVehiclesPG(Conn);
                vehicleDataGridView.DataSource = Data;
            }

            vehicleDataGridView.Columns["id"].ReadOnly = true;

            var columnsInOrderV = new[]
            {   
                "id",
                "miles",
                "name",
                "made",
                "sold",
                "automobile_type"     
            };

            for (int i = 0; i < columnsInOrderV.Length; i++)
            {
                var columnName = columnsInOrderV[i];
                if (vehicleDataGridView.Columns.Contains(columnName))
                {
                    vehicleDataGridView.Columns[columnName].DisplayIndex = i;
                }
            }

        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            vehicleDataGridView.EndEdit();

            string error = Automobile.SaveAutomobilesPG(Conn, Data);
            if (error != "")
            {
                MessageBox.Show(error + "." +
                    "\n All changes rejected and rolled back." +
                    "\n Please fix error and re-submit.");
            }
            else
            {
                MessageBox.Show("Changes saved to database.");
            }
        }
    }
}
