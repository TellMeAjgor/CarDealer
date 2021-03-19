using System;

namespace CarDealer.Models.Entities
{
    public class Translaction
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
    }
}