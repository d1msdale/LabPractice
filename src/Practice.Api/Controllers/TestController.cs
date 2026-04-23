using Microsoft.AspNetCore.Mvc;
using Practice.Application.Interfaces;

namespace LabPractice.Controllers;

[ApiController]
[Route("api/test")]
public class TestController(ITestService testService) : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return testService.GetResponse();
    }
    
    
}