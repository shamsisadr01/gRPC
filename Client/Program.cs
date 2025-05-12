
using Client;
using Grpc.Core;
using gRPC_client.protos;

string target = "localhost:50051";

var channel = new Channel(target, ChannelCredentials.Insecure);

try
{
    await channel.ConnectAsync();

    var clientproductService = new ProductGRPService.ProductGRPServiceClient(channel);

    Product product = new Product(clientproductService);

    var mathserviceClient = new MathService.MathServiceClient(channel);
    Client.Math math = new Client.Math(mathserviceClient);
    math.Division();

    /* var client = clientproductService.UpdateProduct();

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
     Console.WriteLine(r.Status + "--->" + r.Message);*/

   /* var client = clientproductService.GetProductByID();
    foreach (var item in Enumerable.Range(1, 10))
    {
        await client.RequestStream.WriteAsync(new GetProductByIDRequsetDto()
        {
            ProductID = item
        });

    }

    await client.RequestStream.CompleteAsync();

    while(await client.ResponseStream.MoveNext())
    {
        Console.WriteLine("Get Data ---> " + client.ResponseStream.Current.Result + "---->");
    }*/
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
