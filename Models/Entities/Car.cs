using CarDealer.Models.Enums;

namespace CarDealer.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public Conditions Condition { get; set; }
        public string Color { get; set; }
        public Drives Drive { get; set; }
        public string Description { get; set; }
    }
}
