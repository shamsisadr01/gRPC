

using Grpc.Core;
using gRPC_client.protos;

namespace Client
{
    public class Math
    {
        private readonly MathService.MathServiceClient clinet;

        public Math(MathService.MathServiceClient clinet)
        {
            this.clinet = clinet;
        }

        public void Division()
        {
            try
            {
                var response = clinet.CalculateDivision(new DivisionRequseyDto()
                {
                    Number = 5
                },deadline:DateTime.UtcNow.AddSeconds(5));
                Console.WriteLine($"Division Result {response.Result}");
            }
            catch(RpcException e)
            {
                Console.WriteLine(e.StatusCode + "====>" + e.Message);
            }
        }
    }
}
