using MediatR;
using Medical.Application.Doctors.ManageDoctors;
using Medical.Application.Doctors.SearchDoctors;
using Medical.Contracts.Doctors;
using Medical.Domain.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly ISender sender;

        public DoctorController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        [Route("SearchDoctor")]
        public async Task<IActionResult> SearchDoctors(
            [FromQuery]SearchDoctorRequest request, 
            CancellationToken cancellationToken)
        {
            var query = new SearchDoctorQuery(request.specialty);
            var result = await sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDoctor")]
        public async Task<IActionResult> GetDoctorById(
            [FromQuery] GetDoctorRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetDoctorQuery(request.DoctorId);
            var result = await sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDoctor(
            [FromBody] RegisterDoctorRequest request,
            CancellationToken cancellationToken)
        {
            var command = new RegisterDoctorCommand(
                request.Id,
                request.Name,
                request.LicenseNumber,
                new Specialty(){Name = request.Specialty});

            var result = await sender.Send(command, cancellationToken);
            
            return CreatedAtAction(nameof(GetDoctorById), new { id = result.Value }, result.Value);
        }

    }
}
