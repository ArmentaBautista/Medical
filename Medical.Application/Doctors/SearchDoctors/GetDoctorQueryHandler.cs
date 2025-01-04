using System.Data;
using Dapper;
using Medical.Application.Abstractions.CQRS;
using Medical.Application.Abstractions.Data;
using Medical.Domain.Abstractions;
using Medical.Domain.Appointments;

namespace Medical.Application.Doctors.SearchDoctors
{
    internal sealed class GetDoctorQueryHandler
        : IQueryHandler<GetDoctorQuery, DoctorResponse>
    {
        
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public GetDoctorQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        
        public async Task<Result<DoctorResponse>> Handle(
            GetDoctorQuery request, 
            CancellationToken cancellationToken)
        {
            using var connection = sqlConnectionFactory.CreateConnection();

            const string sqlObject = "pGetDoctorsById";
            var param = new DynamicParameters();
            param.Add("@pDoctorId", request.DoctorId);

            var doctor = await connection
                .QueryFirstOrDefaultAsync<DoctorResponse>(
                    sqlObject,
                    param,
                    commandType:CommandType.StoredProcedure);

            return doctor;
        }

       
    }
}
