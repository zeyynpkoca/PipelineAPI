using System;
using System.Collections.Generic;

namespace PipelineAPI.HeatmapDbContextes
{
    public partial class TblMapsection
    {
        public TblMapsection()
        {
            TblPipelines = new HashSet<TblPipeline>();
        }

        public int MapSectionId { get; set; }
        public string? Name { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public virtual ICollection<TblPipeline> TblPipelines { get; set; }
    }
}
