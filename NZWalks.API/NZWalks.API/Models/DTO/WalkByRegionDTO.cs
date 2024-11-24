namespace NZWalks.API.Models.DTO
{
    public class WalkByRegionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public string DifficultyCode { get; set; }
    }
}
