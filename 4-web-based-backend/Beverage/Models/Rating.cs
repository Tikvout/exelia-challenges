namespace Beverage.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public string Score { get; set; }

        // Navigation Properties
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
    }
}
