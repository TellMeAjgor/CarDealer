namespace CarDealer.Models.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public short Age { get; set; }
        public string City { get; set; }
        public string Sex { get; set; }
    }
}