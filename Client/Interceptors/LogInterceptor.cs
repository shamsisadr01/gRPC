using Grpc.Core;
using Grpc.Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interceptors
{
    public class LogInterceptor : Interceptor
    {
        public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(ClientInterceptorContext<TRequest, TResponse> context, AsyncClientStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            Console.WriteLine(".... LogInterceptor.AsyncClientStreamingCall() ....");
            return base.AsyncClientStreamingCall(context, continuation);
        }
    }
}
