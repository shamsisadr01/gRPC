using Grpc.Core;
using gRPC_client.protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Product
    {
        private readonly ProductGRPService.ProductGRPServiceClient client;

        public Product(ProductGRPService.ProductGRPServiceClient client)
        {
            this.client = client;
        }

        public void CreateProduct()
        {
            var result = client.CreateProduct(new CreateProductService()
            {
                Des = "dfdf",
                Title = "dfdf"
            });

            Console.WriteLine(result);
        }

        public async void GetProductBYTag()
        {
            var respone = client.GetProductBYTag(new GetProductBYTagRequset()
            {
                Tag = "fg"
            });

            while (await respone.ResponseStream.MoveNext())
            {
                Console.WriteLine(respone.ResponseStream.Current.Title);
            }
        }
    }
}
