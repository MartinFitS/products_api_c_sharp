using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShopApplication.Utilities.Mediator;

public class SimpleMediator(IServiceProvider sp) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var typeHandler = typeof(IrequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var test_case = sp.GetRequiredService(typeHandler);

        var method = typeHandler.GetMethod("Handle");

        return await (Task<TResponse>)method.Invoke(test_case, new object[] { request })!;
    }
}
