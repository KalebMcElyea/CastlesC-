namespace CastlesC_.Models
{
    public class Knights
    {
        public string Name { get; set; }

        public int? Age { get; set; }

        public int Id { get; set; }

        public int CastleId { get; set; }

        public Castle Castle { get; set; }
    }
}