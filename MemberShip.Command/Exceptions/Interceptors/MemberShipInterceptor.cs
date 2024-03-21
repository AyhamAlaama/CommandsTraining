using Grpc.Core;
using Grpc.Core.Interceptors;
using MemberShip.Command.Exceptions;

namespace MemberShip.Command.Exceptions.Interceptors
{
    public class MemberShipInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await base.UnaryServerHandler(request, context, continuation);

            }
            catch (AlreadyException e)
            {
                throw new RpcException(new Status(StatusCode.Unknown, e.Message));
            }
            catch (NotFoundException e)
            {
                throw new RpcException(new Status(StatusCode.NotFound, e.Message));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
