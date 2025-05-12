

using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Reflection;
using Grpc.Reflection.V1Alpha;
using gRPC_client.protos;
using Servver.Interceptors;
using Servver.Services;

const int Port = 50051;

Server? _server = null;

var caCrt = File.ReadAllText("ssl/ca.crt");
var serverCrt = File.ReadAllText("ssl/server.crt");
var serverKey = File.ReadAllText("ssl/server.key");

var keyPair = new KeyCertificatePair(serverCrt, serverKey);

var credentials = new SslServerCredentials(new List<KeyCertificatePair>()
{
    keyPair
},caCrt,true);

try
{
    var reflections = new ReflectionServiceImpl(ProductGRPService.Descriptor,MathService.Descriptor);
    _server = new Server()
    {
        Services = {
            ProductGRPService.BindService(new productServiceIm()) ,
            MathService.BindService(new MathServiceIm()).Intercept(new LogInterceptor()),
            ServerReflection.BindService(reflections)
        },
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

