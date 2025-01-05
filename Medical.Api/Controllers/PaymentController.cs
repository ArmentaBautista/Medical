using MediatR;
using Medical.Application.Payments.Commands;
using Medical.Application.Payments.Queries;
using Medical.Contracts.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private ISender _sender;

    public PaymentController(ISender sender)
    {
        _sender = sender;
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetPaymentQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("by-appointment/{appointmentId:guid}")]
    public async Task<IActionResult> GetByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var query = new GetPaymentsByAppointmentQuery(appointmentId);

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterPaymentRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RegisterPaymentCommand(request.AppointmentId, request.Amount, request.PaymentDate);

        var result = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { Id = result.Value, result.Value });

    }

}