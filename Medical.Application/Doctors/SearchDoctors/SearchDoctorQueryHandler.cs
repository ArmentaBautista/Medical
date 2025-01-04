using System.Data;
using Dapper;
using Medical.Application.Abstractions.CQRS;
using Medical.Application.Abstractions.Data;
using Medical.Domain.Abstractions;
using Medical.Domain.Appointments;

namespace Medical.Application.Doctors.SearchDoctors
{
    internal sealed class SearchDoctorQueryHandler
        : IQueryHandler<SearchDoctorQuery, IReadOnlyList<DoctorResponse>>
    {
        
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public SearchDoctorQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IReadOnlyList<DoctorResponse>>> Handle(SearchDoctorQuery request,
            CancellationToken cancellationToken)
        {
            
            using var connection = sqlConnectionFactory.CreateConnection();

            const string sqlObject = "pSearchDoctorsBySpecialty";
            var param = new DynamicParameters();
            param.Add("@pSpecialty", request.specialty);

            var doctors = await connection
                .QueryAsync<DoctorResponse>(
                    sqlObject,
                    param,
                    commandType:CommandType.StoredProcedure);

            return doctors.ToList();
        }




    }
}
