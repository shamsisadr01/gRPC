using Grpc.Core;
using Grpc.Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servver.Interceptors
{
    public class LogInterceptor : Interceptor
    {
        public override Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, ServerCallContext context, ClientStreamingServerMethod<TRequest, TResponse> continuation)
        {
            Console.WriteLine("LogInterceptor.ClientStreamingServerHandler() ...");
            return base.ClientStreamingServerHandler(requestStream, context, continuation);
        }
    }
}
