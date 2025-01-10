using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Report;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ILogger<ReportsController> _logger;

        public ReportsController(IReportService reportService, ILogger<ReportsController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all reports
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaddleResponse<Report[]>>> ListReports()
        {
            return await _reportService.ListReportsAsync();
        }

        /// <summary>
        /// Gets a specific report by ID
        /// </summary>
        [HttpGet("{reportId}")]
        public async Task<ActionResult<PaddleResponse<Report>>> GetReport(string reportId)
        {
            return await _reportService.GetReportAsync(reportId);
        }

        /// <summary>
        /// Creates a new report
        /// </summary>
        [HttpPost("{type}")]
        public async Task<ActionResult<PaddleResponse<Report>>> CreateReport(string type, [FromBody] ReportParameters parameters)
        {
            return await _reportService.CreateReportAsync(type, parameters);
        }

        /// <summary>
        /// Downloads a report
        /// </summary>
        [HttpGet("{reportId}/download")]
        public async Task<IActionResult> DownloadReport(string reportId)
        {
            PaddleResponse<byte[]> response = await _reportService.DownloadReportAsync(reportId);
            if (!response.Success)
            {
                return BadRequest(response.Error);
            }
            return File(response.Response, "application/octet-stream", $"report_{reportId}.csv");
        }
    }
}