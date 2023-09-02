using System;
using System.Collections.Generic;

namespace PipelineAPI.HeatmapDbContextes
{
    public partial class TblPipeline
    {
        public int PipelineId { get; set; }
        public int? MapSectionId { get; set; }
        public int? Size { get; set; }
        public int? PipelineClassesId { get; set; }
        public string? ChangeUser { get; set; }
        public int? UserStatusId { get; set; }
        public int? SystemStatusId { get; set; }
        public long? Equipment { get; set; }
        public string? LongText { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? NotificationBot { get; set; }
        public string? TechnicalOd { get; set; }
        public string? Akt { get; set; }
        public DateTime PipelineDate { get; set; }
        public string? Notification2 { get; set; }

        public virtual TblMapsection? MapSection { get; set; }
    }
}
