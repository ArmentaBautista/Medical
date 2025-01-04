using Medical.Application.Appointments;
using Medical.Contracts.Appointments;
using MediatR;
using Medical.Application.Appointments.GetAppointments;
using Medical.Application.Appointments.ReserveAppointment;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly ISender sender;

        public AppointmentsController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAppointment(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetAppointmentQuery(id);
            var result = await sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ReserveAppointment([FromBody]
            ReserveAppointmentRequest request,
            CancellationToken cancellationToken)
        {
            var command = new RegisterDoctorCommand(
                request.doctorId,
                request.patientId,
                request.appointmentDate,
                request.price
            );

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetAppointment), new { id = result.Value }, result.Value);
        }
    }
}
