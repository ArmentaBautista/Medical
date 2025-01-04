using System.Data;
using Dapper;
using Medical.Application.Abstractions.CQRS;
using Medical.Application.Abstractions.Data;
using Medical.Domain.Abstractions;

namespace Medical.Application.Appointments.GetAppointments
{
    internal sealed class GetAppointmentQueryHandler 
        : IQueryHandler<GetAppointmentQuery, AppointmentResponse>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public GetAppointmentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<AppointmentResponse>> Handle(
            GetAppointmentQuery request,
            CancellationToken cancellationToken)
        {
            using var connection = sqlConnectionFactory.CreateConnection();

            const string SqlObject = "pGetAppointments";
            var args = new DynamicParameters();
            args.Add("@AppointmentId", request.AppointmentId);


            var appointment = await connection.QueryFirstOrDefaultAsync<AppointmentResponse>(
                SqlObject,
                args,
                commandType: CommandType.StoredProcedure);

            return appointment;
        }
    }
}
