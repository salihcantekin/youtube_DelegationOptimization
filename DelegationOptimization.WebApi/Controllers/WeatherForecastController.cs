using DelegationOptimization.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DelegationOptimization.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IEmailService emailService;

    public WeatherForecastController(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    [HttpGet()]
    public IEnumerable<WeatherForecast> Get()
    {
        throw new Exception("Test Exception Message");
    }

    [HttpGet("Test")]
    public IActionResult TestEmail()
    {
        emailService.SendEmail("", "", "");

        return Ok();
    }
}