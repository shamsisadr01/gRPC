using Grpc.Core;
using gRPC_client.protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servver.Services
{
    public class MathServiceIm : MathService.MathServiceBase
    {
        public override async Task<DivisionResponseDto> CalculateDivision(DivisionRequseyDto request, ServerCallContext context)
        {
            if(request.Number == 0)
            {
                throw new RpcException(new Status(StatusCode.Internal, "value canot equals zero"));
            }

            int result = request.Number / 2;
            return new DivisionResponseDto()
            {
                Result = result
            };
        }
    }
}
