using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShopApplication.Utilities.Mediator;

public interface IRequest<TResponse>
{

}

public interface IrequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request);
}
