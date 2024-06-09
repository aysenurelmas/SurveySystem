using Microsoft.AspNetCore.Mvc;
using Business.Dtos;
using Business.Abstracts;
using Core.DataAccess.Paging;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveysController : ControllerBase
{
    ISurveyService _surveyService;

    public SurveysController(ISurveyService surveyService)
    {
        _surveyService = surveyService;
    }

    [HttpPost]
    public async Task<ActionResult<CreatedSurveyResponse>> Add([FromBody] CreateSurveyRequest createSurveyRequest)
    {
        var result = await _surveyService.Add(createSurveyRequest);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSurveyResponse>> Update([FromBody] UpdateSurveyRequest updateSurveyRequest)
    {
        var result = await _surveyService.Update(updateSurveyRequest);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult<DeletedSurveyResponse>> Delete([FromBody] DeleteSurveyRequest deleteSurveyRequest)
    {
        var result = await _surveyService.Delete(deleteSurveyRequest);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _surveyService.GetList(pageRequest);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSurveyDetails(int id)
    {
        var result = await _surveyService.GetSurveyDetailsById(id);
        return Ok(result);
    }
}