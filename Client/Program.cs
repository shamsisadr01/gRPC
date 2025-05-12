
using Client;
using Client.Interceptors;
using Grpc.Core;
using Grpc.Core.Interceptors;
using gRPC_client.protos;

string target = "localhost:50051";

var caCrt = File.ReadAllText("ssl/ca.crt");
var clientCrt = File.ReadAllText("ssl/client.crt");
var clientKey = File.ReadAllText("ssl/client.key");

var channelCredential = new SslCredentials(caCrt, new KeyCertificatePair(clientCrt, clientKey));


var channel = new Channel(target, ChannelCredentials.Insecure);
var callInvoker = channel.Intercept(new LogInterceptor());

try
{
    await channel.ConnectAsync();

    var clientproductService = new ProductGRPService.ProductGRPServiceClient(callInvoker);

    Product product = new Product(clientproductService);

    var mathserviceClient = new MathService.MathServiceClient(callInvoker);
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
