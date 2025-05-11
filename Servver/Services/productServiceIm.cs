using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using gRPC_client.protos;

namespace Servver.Services
{
    public class productServiceIm : ProductGRPService.ProductGRPServiceBase
    {
        public override Task<ProductResponeDto> CreateProduct(CreateProductService request, ServerCallContext context)
        {
            return Task.FromResult(new ProductResponeDto()
            {
                Name = "jhghjg"
            });
        }

        public  override async Task GetProductBYTag(GetProductBYTagRequset request, IServerStreamWriter<GetProductBYResponse> responseStream, ServerCallContext context)
        {
            await Console.Out.WriteAsync(request.Tag);
            foreach (var item in Enumerable.Range(1,10))
            {
                
                await responseStream.WriteAsync(new GetProductBYResponse()
                {
                    Id = 1,
                    Title = "djmfk"
                });
            }
        }

        public override async Task<UpdateProductResponsDto> UpdateProduct(IAsyncStreamReader<UpdateProductRequsetDto> requestStream, ServerCallContext context)
        {
            string result = String.Empty;
            while (await requestStream.MoveNext())
            {
                result += requestStream.Current.Title + " ";
            }
            Console.WriteLine(result);
            return new UpdateProductResponsDto()
            {
                Message = "ksdjhk jhsgdehjs",
                Status = 200
            };
        }
    }
}
