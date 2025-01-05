using MediatR;
using Medical.Application.Patiens.Commands;
using Medical.Application.Patiens.Queries;
using Medical.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController:ControllerBase
{
    private readonly ISender _sender;

    public PatientController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetPatient")]
    public async Task<IActionResult> GetPatientById([FromQuery] GetPatientRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPatientQuery(request.Id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ResgisterPatient([FromBody] RegisterPatientRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RegisterPatientCommand(request.Name, request.Email, request.PhoneNumber);

        var result = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetPatientById), result.Value, result.Value);

    }
}