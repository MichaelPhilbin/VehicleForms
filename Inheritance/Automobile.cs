using System;
using System.Collections.Generic;
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
        public override void WriteRow(List<StreamWriter> writers)
        {
            base.WriteRow(writers);
            string line = $"{Vin}\t{Type}\t{Make}\t{Model}";
            writers[1].WriteLine(line);
        }
        public static (List<Automobile> automobiles, List<string> errors) LoadAutomobilesFile(string path, Dictionary<int, Vehicle> baseVehicles)
        {
            List<string> errors = new List<string>();
            List<Automobile> automobiles = new List<Automobile>();

            return (automobiles, errors);
        }
    
       
    }
}
