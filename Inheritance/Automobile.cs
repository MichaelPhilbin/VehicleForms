using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            using var transaction = conn.BeginTransaction();

            try
            {
                // First insert into vehicle
                string insertSqlVehicle = @"
                INSERT INTO vehicle (miles, name, made, sold, vehicle_type)
                VALUES (@miles, @name, @made, @sold, @vehicle_type)
                RETURNING vehicle_id;";

                using var cmd1 = new NpgsqlCommand(insertSqlVehicle, conn, transaction);

                cmd1.Parameters.AddWithValue("miles", this.mileage);
                cmd1.Parameters.AddWithValue("name", this.owner);
                cmd1.Parameters.AddWithValue("made", this.dateMade);
                cmd1.Parameters.AddWithValue("sold", this.dateSold);
                cmd1.Parameters.AddWithValue("vehicle_type", "automobile");

                int vehicleId = Convert.ToInt32(cmd1.ExecuteScalar());

                // Then insert into automobile
                string insertSqlAutomobile = @"
                INSERT INTO automobile (vehicle_id, vin, automobile_type, make, model)
                VALUES (@vehicle_id, @vin, @automobile_type, @make, @model);";

                using var cmd2 = new NpgsqlCommand(insertSqlAutomobile, conn, transaction);

                cmd2.Parameters.AddWithValue("vehicle_id", vehicleId);
                cmd2.Parameters.AddWithValue("vin", vin);
                cmd2.Parameters.AddWithValue("automobile_type", type);
                cmd2.Parameters.AddWithValue("make", make);
                cmd2.Parameters.AddWithValue("model", model);

                cmd2.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Transaction failed: " + ex.Message);
            }
        }
        public static DataTable LoadAutomobilesPG(NpgsqlConnection conn)
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM automobile " +
                                              "JOIN vehicle ON automobile.vehicle_id = vehicle.id;"
                                              , conn);
            using var adapter = new NpgsqlDataAdapter(cmd);
            var table = new DataTable();

            adapter.Fill(table);
            return table;
        }

        public static string SaveAutomobilesPG(NpgsqlConnection conn, DataTable data)
        {
            foreach (DataRow row in data.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    using var transaction = conn.BeginTransaction();

                    try
                    {
                        // Update VEHICLE table
                        using var vehicleCmd = new NpgsqlCommand(@"
                            UPDATE vehicle
                            SET miles = @miles,
                                name = @name,
                                made = @made,
                                sold = @sold
                            WHERE id = @vehicle_id;", conn, transaction);

                        vehicleCmd.Parameters.AddWithValue("miles", row["miles"]);
                        vehicleCmd.Parameters.AddWithValue("name", row["name"]);
                        vehicleCmd.Parameters.AddWithValue("made", row["made"]);
                        vehicleCmd.Parameters.AddWithValue("sold", row["sold"]);
                        vehicleCmd.Parameters.AddWithValue("vehicle_id", row["vehicle_id"]); // or vehicle.id

                        vehicleCmd.ExecuteNonQuery();

                        // Update AUTOMOBILE table
                        using var autoCmd = new NpgsqlCommand(@"
                            UPDATE automobile
                            SET vin = @vin,
                                automobile_type = @automobile_type,
                                make = @make,
                                model = @model
                            WHERE vehicle_id = @vehicle_id;", conn, transaction);

                        autoCmd.Parameters.AddWithValue("vin", row["vin"]);
                        autoCmd.Parameters.AddWithValue("automobile_type", row["automobile_type"]);
                        autoCmd.Parameters.AddWithValue("make", row["make"]);
                        autoCmd.Parameters.AddWithValue("model", row["model"]);
                        autoCmd.Parameters.AddWithValue("vehicle_id", row["vehicle_id"]);

                        autoCmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Failed to save row: " + ex.Message;
                    }
                }
            }

            data.AcceptChanges();
            return "";
        }
    }
}