namespace PipelineAPI.Models
{
    public class PipelineModel
    {
        // Bu senin db modelin
        public int MapSectionId { get; set; }

        public string? name { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }
    }
}