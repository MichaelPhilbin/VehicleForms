namespace Inheritance
{
    public class Vehicle
    {
        protected double mileage;
        protected int vin;
        protected string owner;
        protected DateOnly dateMade;
        protected DateOnly dateSold;
        public Vehicle(double mileage, int vin, string owner, DateOnly dateMade, DateOnly dateSold)
        {
            this.mileage = mileage;
            this.vin = vin;
            this.owner = owner;
            this.dateMade = dateMade;
            this.dateSold = dateSold;
        }

        public double Mileage { get { return mileage; } set { mileage = value; } }
        public int Vin { get { return vin; } set { vin = value; } }
        public string Owner { get { return owner; } set { owner = value; } }
        public DateOnly DateMade { get { return dateMade; } set { dateMade = value; } }
        public DateOnly DateSold { get { return dateSold; } set { dateSold = value; } }

        public static StreamWriter OpenTSV(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath, append: true);
            return writer;
        }
        public virtual void WriteRow(List<StreamWriter> writers)
        {
            string line = $"{Mileage}\t{Vin}\t{Owner}\t{DateMade}\t{DateSold}";
            writers[0].WriteLine(line);
        }
        public static (List<Vehicle> vehicles, List<string> errors) LoadVehiclesFile(string path)
        {
            List<string> errors = new List<string>();
            List<Vehicle> vehicles = new List<Vehicle>();

            if (!File.Exists(path)) return (vehicles, ["File Does Not Exist: " + path]);
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('\t');
                if (parts.Length < 5)
                {
                    errors.Add($"Error: Line {i} has too few columns.");
                    continue;
                }
                if (!double.TryParse(parts[0], out double mileage))
                {
                    errors.Add($"Invalid mileage at line {i}: {parts[0]}");
                    continue;
                }
                if (!int.TryParse(parts[1], out int vin))
                {
                    errors.Add($"Invalid VIN at line {i}: {parts[1]}");
                    continue;
                }
                if (!DateTime.TryParseExact(parts[3], "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateMadeDT))
                {
                    errors.Add($"Invalid date made at line {i}: {parts[3]}");
                    continue;
                }
                if (!DateTime.TryParseExact(parts[4], "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateSoldDT))
                {
                    errors.Add($"Invalid date sold at line {i}: {parts[4]}");
                    continue;
                }

                Vehicle v = new Vehicle(
                    mileage,
                    vin,
                    parts[2],
                    DateOnly.FromDateTime(dateMadeDT),
                    DateOnly.FromDateTime(dateSoldDT)
                );

                vehicles.Add(v);
            }

            return (vehicles, errors);
        }
    }

}

   



