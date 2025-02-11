namespace Portfolio.BaseClasses
{
    public class Player
    {

        public string Id { get; set; }
        public string? Name { get; set; }

        public string? Country { get; set; }

        //public string? CourtType { get; set; }
        public CourtType CourtTypeEnum { get; set; }
        public enum CourtType
        {
            grass = 0,
            clay = 1,
            hard = 2

        }

        public Player(string id)
        {
            Id = GenerateCustomID();

        }


        private string GenerateCustomID()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
