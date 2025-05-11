
using Grpc.Core;
using gRPC_client.protos;

string target = "localhost:50051";

var channel = new Channel(target, ChannelCredentials.Insecure);

try
{
    await channel.ConnectAsync();

    var clientproductService = new ProductGRPService.ProductGRPServiceClient(channel);

  /*  var result = clientproductService.CreateProduct(new CreateProductService()
    {
        Des = "dfdf",
        Title ="dfdf"
    });

    Console.WriteLine(result);

     var respone = clientproductService.GetProductBYTag(new GetProductBYTagRequset()
    {
        Tag = "fg"
    });

    while (await respone.ResponseStream.MoveNext())
    {
        Console.WriteLine(respone.ResponseStream.Current.Title);
    }*/

    var client = clientproductService.UpdateProduct();

    foreach (var item in Enumerable.Range(1,10))
    {
         await  client.RequestStream.WriteAsync(new UpdateProductRequsetDto()
        {
            Title = "product Update" + item,
            Des = ",xh djhf"
        });
    }

    await client.RequestStream.CompleteAsync();

    var r = await client.ResponseAsync;
    Console.WriteLine(r.Status + "--->" + r.Message);

    Console.ReadKey();

}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
finally
{
    await channel.ShutdownAsync();
}
