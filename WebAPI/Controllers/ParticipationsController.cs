using Business.Abstracts;
using Business.Dtos.Participations;
using Core.DataAccess.Security.Extensions;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipationsController : ControllerBase
    {
        private readonly IParticipationService _participationService;

        public ParticipationsController(IParticipationService participationService)
        {
            _participationService = participationService;
        }
        protected int getAuthenticatedUserId()
        {
            int userId = HttpContext.User.GetUserId();
            return userId;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedParticipationRequest createdParticipationRequest)
        {
           createdParticipationRequest.UserId = getAuthenticatedUserId();
            var result = await _participationService.Add(createdParticipationRequest);
            return Ok(result);
        }
        [HttpGet("results/{surveyId}")]
        public async Task<IActionResult> GetSurveyResults(int surveyId)
        {
            var results = await _participationService.GetSurveyResults(surveyId);
            return Ok(results);
        }
      
    }
}
