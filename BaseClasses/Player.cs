namespace Portfolio.BaseClasses
{
    public class Player
    {

        public string? NiclName { get; set; }

        public CourtType CourtTypeEnum { get; set; }
        public enum CourtType
        {
            grass = 0,
            clay = 1,
            hard = 2
        }

    }
}
