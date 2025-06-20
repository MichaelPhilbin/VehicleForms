using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Automobile : Vehicle
    {
        private string vin;
        private string type;
        private string make;
        private string model;
        public Automobile(int mileage, string owner, DateOnly dateMade, DateOnly dateSold, string vin, string type, string make, string model) : base(mileage, owner, dateMade, dateSold)
        {
            this.vin = vin;
            this.type = type;
            this.make = make;
            this.model = model;
        }

        public string Vin { get { return vin; } set { type = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public override void WriteRow(NpgsqlConnection conn)
        {
            string insertSqlVehicle = @"
            INSERT INTO vehicle (miles, name, made, sold, vehicle_type)
            VALUES (@miles, @name, @made, @sold, @vehicle_type)
            RETURNING id;";

            using var cmd1 = new NpgsqlCommand(insertSqlVehicle, conn);

            cmd1.Parameters.AddWithValue("miles", mileage);
            cmd1.Parameters.AddWithValue("name", owner);
            cmd1.Parameters.AddWithValue("made", dateMade);
            cmd1.Parameters.AddWithValue("sold", dateSold);
            cmd1.Parameters.AddWithValue("vehicle_type", "automobile");

            cmd1.ExecuteScalar();

            int vehicleId = Convert.ToInt32(cmd1.ExecuteScalar());

            string insertSqlAutomobile = @"
            INSERT INTO automobile (vehicle_id, vin, automobile_type, make, model)
            VALUES (@vehicle_id, @vin, @automobile_type, @make, @model);"; 

            using var cmd2 = new NpgsqlCommand(insertSqlAutomobile, conn);

            cmd2.Parameters.AddWithValue("vehicle_id", vehicleId);
            cmd2.Parameters.AddWithValue("vin", vin);
            cmd2.Parameters.AddWithValue("automobile_type", type);
            cmd2.Parameters.AddWithValue("make", make);
            cmd2.Parameters.AddWithValue("model", model);

            cmd2.ExecuteNonQuery();
        }
        public static List<Automobile> LoadAutomobilesFile(NpgsqlConnection conn)
        {
          
            List<Automobile> automobiles = new List<Automobile>();

            using var cmd = new NpgsqlCommand("SELECT * FROM automobile " +
                                              "JOIN vehicle ON automobile.id = vehicle.vehicle_id;"
                                              , conn);
            using var adapter = new NpgsqlDataAdapter(cmd);
            var table = new DataTable();

            // Step 4: Fill DataTable
            adapter.Fill(table);


            conn.Close();

            return automobiles;
        }
    }
}
