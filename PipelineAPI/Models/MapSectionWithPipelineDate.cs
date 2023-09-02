namespace PipelineAPI.Models
{
    public class MapSectionWithPipelineDate
    {
        public int MapSectionId { get; set; }
        public string? name { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public DateTime PipelineDate { get; set; }

    }
}
