using Microsoft.AspNetCore.Mvc;
using SmartFactory.Application.DTOs;
using SmartFactory.Application.Services;

namespace SmartFactory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachinesController : ControllerBase
{
    private readonly MachineService _machineService;

    public MachinesController(MachineService machineService)
    {
        _machineService = machineService;
    }

    [HttpPost]
    public IActionResult CreateMachine(CreateMachineRequest request)
    {
        var machine = _machineService.CreateMachine(request);

        return Ok(machine);
    }
}