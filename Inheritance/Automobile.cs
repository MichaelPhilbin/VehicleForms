using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Automobile : Vehicle
    {
        private string type;
        private string make;
        private string model;
        public Automobile(double mileage, int vin, string owner, DateOnly dateMade, DateOnly dateSold, string type, string make, string model) : base(mileage, vin, owner, dateMade, dateSold)
        {
            this.type = type;
            this.make = make;
            this.model = model;
        }

        public string Type { get { return type; } set { type = value; } }
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public override void WriteRow(List<StreamWriter> writers)
        {
            base.WriteRow(writers);
            string line = $"{vin}\t{Type}\t{Make}\t{Model}";
            writers[1].WriteLine(line);
        }
        public static (List<Automobile> automobiles, List<string> errors) LoadAutomobilesFile(string path, Dictionary<int, Vehicle> baseVehicles)
        {
            List<string> errors = new List<string>();
            List<Automobile> automobiles = new List<Automobile>();

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('\t');
                if (parts.Length != 4)
                {
                    errors.Add($"Error: Line {i} has too few/many columns.");
                    continue;
                }

                int vin = int.Parse(parts[0]);
            
                if (baseVehicles.TryGetValue(vin, out Vehicle v))
                {
                    automobiles.Add(new Automobile(
                        v.Mileage, v.Vin, v.Owner,
                        v.DateMade, v.DateSold,
                        parts[1], parts[2], parts[3]
                    ));
                }
            }

            return (automobiles, errors);
        }
    
       
    }
}
