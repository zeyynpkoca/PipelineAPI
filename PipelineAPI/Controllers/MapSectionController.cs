using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PipelineAPI.HeatmapDbContextes;
using PipelineAPI.Models;

namespace PipelineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapSectionController : ControllerBase
    {
        private readonly HeatmapDBContext _context;

        public MapSectionController(HeatmapDBContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<TblMapsection>> GetAllMapSections()
        {
            try
            {
                // Tüm harita bölümlerini çek
                var mapSections = _context.TblMapsections.ToList();

                return Ok(mapSections);
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir yanıt dön
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        //[HttpPost("getByDateRange")]
        //public ActionResult<IEnumerable<TblMapsection>> GetMapSectionsByDateRange([FromBody] DateRangeRequest request)
        //{
        //    try
        //    {

        //        string startDateStr = request.StartDate.ToString(); // Örneğin "2022-08-05" şeklinde geliyor
        //        string endDateStr = request.EndDate.ToString(); // Örneğin "2022-08-15" şeklinde geliyor

        //        // Tarih formatını belirtin
        //        // İlgili tarih aralığındaki Pipeline verilerini çek
        //        var pipelinesInDateRange = _context.TblPipelines
        //            .Where(p => p.PipelineDate >= startDate && p.PipelineDate <= endDate)
        //            .Select(p => p.MapSectionId)
        //            .ToList();



        //        var mapSectionsWithPipelineDate = _context.TblMapsections
        //            .Where(m => pipelinesInDateRange.Contains(m.MapSectionId))
        //            .Join(
        //                _context.TblPipelines,
        //                mapSection => mapSection.MapSectionId,
        //                pipeline => pipeline.MapSectionId,
        //                (mapSection, pipeline) => new MapSectionWithPipelineDate
        //                {
                            
        //                    MapSectionId = mapSection.MapSectionId,
        //                    name = mapSection.Name,
        //                    Latitude = mapSection.Latitude,
        //                    Longitude = mapSection.Longitude,
        //                    PipelineDate = pipeline.PipelineDate.Date
        //                }
        //            )
        //            .ToList();
        //        return Ok(mapSectionsWithPipelineDate);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hata durumunda uygun bir yanıt dön
        //        return StatusCode(500, $"Sunucu hatası: {ex.Message}");
        //    }
        //}
    }
}
