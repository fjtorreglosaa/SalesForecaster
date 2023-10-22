using MediatR;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Product;

namespace SalesForecaster.Application.Features.Product.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<ResultModel<List<GetProductDto>>>
    {
    }
}
