namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        public string? Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Population { get; set; }
    }
}
