using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShopApplication.Utilities.Mediator;

public interface IMediator
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
}
