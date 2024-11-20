namespace NZWalks.API.Models.DTO
{
    public class WalkDetailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public string DifficultyCode { get; set; }
    }
        
}
