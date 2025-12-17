using Microsoft.AspNetCore.Mvc;
using Subbmitly.Application.DTOs;
using Subbmitly.Application.Interfaces;

namespace Subbmitly.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpGet("getSubmissions")]
        public async Task<IActionResult> GetSubmissions()
        {
            try
            {
                var submissions = await _submissionService.GetSubmissions();
                return Ok(submissions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost("createSubmission")]
        public async Task<IActionResult> CreateSubmission([FromBody] CreateSubmissionRequest request)
        {
            try
            {
                var result = await _submissionService.CreateSubmissionAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}