//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrpcServices
{
    using System.Threading.Tasks;
    using Grpc.Core;
    using Grpc.Core.Interceptors;
    using Microsoft.Extensions.Logging;
    using GrpcSecurity;
    
    
    public class ServerLoggerInterceptor : Interceptor
    {
        
        private readonly ILogger<ServerLoggerInterceptor> _logger;
        
        public ServerLoggerInterceptor(ILogger<ServerLoggerInterceptor> logger)
        {
            _logger = logger;
        }
        
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            GrpcSecurityService.ValidateUser(context);
            return await  base.UnaryServerHandler(request, context, continuation);
        }
        
        public override async Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, ServerCallContext context, ClientStreamingServerMethod<TRequest, TResponse> continuation)
        {
            GrpcSecurityService.ValidateUser(context);
            return await base.ClientStreamingServerHandler(requestStream, context, continuation);
        }
        
        public override Task ServerStreamingServerHandler<TRequest, TResponse>(TRequest request, IServerStreamWriter<TResponse> responseStream, ServerCallContext context, ServerStreamingServerMethod<TRequest, TResponse> continuation)
        {
            GrpcSecurityService.ValidateUser(context);
            return base.ServerStreamingServerHandler(request, responseStream, context, continuation);
        }
        
        public override Task DuplexStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, IServerStreamWriter<TResponse> responseStream, ServerCallContext context, DuplexStreamingServerMethod<TRequest, TResponse> continuation)
        {
            GrpcSecurityService.ValidateUser(context);
            return base.DuplexStreamingServerHandler(requestStream, responseStream, context, continuation);
        }
    }
}
