using System.Collections;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    private readonly IDataService _dataService;

    public Controller(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Project>>> GetProject([FromQuery]SearchProjectsDTO dto)
    {
        try
        {
            List<Project> projects= await _dataService.GetAllProjects(dto);
            return projects;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        } 
    }
    [HttpGet("by-id")]
    public async Task<ActionResult<Project>> GetProject([FromRoute]int id)
    {
        try
        {
            Project project= await _dataService.GetProject(id);
            return project;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        } 
    }
    [HttpPost("create-project")]
    public async Task<ActionResult<Project>> CreateProject([FromQuery]CreateProjectDTO dto)
    {
        try
        {
            Project nextProject = await _dataService.CreateProject(dto);
            return Ok(nextProject);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        } 
    }
    [HttpPatch("add-story")]
    public async Task<ActionResult<Project>> AddUserStory([FromQuery]AddUserStoryDTO dto)
    {
        try
        {
            Project nextProject = await _dataService.AddUserStory(dto);
            return Ok(nextProject);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        } 
    }

    
}