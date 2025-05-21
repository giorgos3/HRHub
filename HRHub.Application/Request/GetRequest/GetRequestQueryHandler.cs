using Dapper;
using HRHub.Application.Abstractions.Data;
using HRHub.Application.Abstractions.Messaging;
using HRHub.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Application.Request.GetRequest
{
    internal sealed class GetRequestQueryHandler : IQueryHandler<GetRequestQuery, RequestResponse>
    {

        private readonly ISqlConnectionFactory _dbConnection;

        public GetRequestQueryHandler(ISqlConnectionFactory dbConnection) 
        {
            _dbConnection = dbConnection;
        }
        public async Task<Result<RequestResponse>> Handle(GetRequestQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dbConnection.CreateConnection();

            const string sql = @"
                SELECT *
                FROM requests
                WHERE id = @RequestId;
            ";

            var requestLeave = await connection.QueryFirstOrDefaultAsync<RequestResponse>(
                sql,
                new
                {
                    request.RequestId
                });


            return requestLeave;

        }
    }
}
