

using Grpc.Core;
using gRPC_client.protos;
using Servver.Services;

const int Port = 50051;

Server? _server = null;

try
{
    _server = new Server()
    {
        Services = { ProductGRPService.BindService(new productServiceIm()) },
        Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
    };
    _server.Start();

    Console.WriteLine($"service Port {Port}");

    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
finally
{
    if (_server != null)
    {
        await _server.ShutdownAsync();
    }
}

