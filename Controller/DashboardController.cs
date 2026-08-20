using Microsoft.AspNetCore.Mvc;
using projectdashboard.Interface;
using projectdashboard.DTO;
namespace projectdashboard.Controller;

[ApiController]
[Route("api/[controller]")]

public class DashboardController: ControllerBase
{
    private readonly IProjectService _projectservice;
    public DashboardController(IProjectService projectservice)
    {
        _projectservice=projectservice;
    }
    [HttpGet]
    public async Task<IActionResult> GetTotal()
    {
        var totalproject = await _projectservice.GetTotalProjects();
        var totaltasks = await _projectservice.GetTotalTasks();

        return Ok(new ProjectDashboardDto
        {
            TotalProjects= totalproject,            // will return both results together
            TotalTasks= totaltasks
        });
    }

    
}