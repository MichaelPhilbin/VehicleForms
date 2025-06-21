using Npgsql;
using System.Data;

namespace Inheritance
{
    public class Vehicle
    {
        protected int mileage;
        protected string owner;
        protected DateOnly dateMade;
        protected DateOnly dateSold;
        public Vehicle(int mileage, string owner, DateOnly dateMade, DateOnly dateSold)
        {
            this.mileage = mileage;
            this.owner = owner;
            this.dateMade = dateMade;
            this.dateSold = dateSold;
        }

        public int Mileage { get { return mileage; } set { mileage = value; } }
        public string Owner { get { return owner; } set { owner = value; } }
        public DateOnly DateMade { get { return dateMade; } set { dateMade = value; } }
        public DateOnly DateSold { get { return dateSold; } set { dateSold = value; } }
        public virtual void WriteRow(NpgsqlConnection conn)
        {
            string insertSql = @"
            INSERT INTO vehicle (miles, name, made, sold, vehicle_type)
            VALUES (@miles, @name, @made, @sold, @vehicle_type)
            RETURNING id;";

            using var cmd = new NpgsqlCommand(insertSql, conn);

            // Add parameter values (replace with your actual data)
            cmd.Parameters.AddWithValue("miles", this.mileage);
            cmd.Parameters.AddWithValue("name", this.owner);
            cmd.Parameters.AddWithValue("made", this.dateMade);
            cmd.Parameters.AddWithValue("sold", this.dateSold);
            cmd.Parameters.AddWithValue("vehicle_type", "NA");

            cmd.ExecuteScalar();
        }
        public static DataTable LoadVehiclesPG(NpgsqlConnection conn)
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM vehicle "
                                              , conn);
            using var adapter = new NpgsqlDataAdapter(cmd);
            var table = new DataTable();

            adapter.Fill(table);
            return table;
        }
    }

}

   



