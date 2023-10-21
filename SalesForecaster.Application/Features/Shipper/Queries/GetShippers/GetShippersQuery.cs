using MediatR;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Shipper;

namespace SalesForecaster.Application.Features.Shipper.Queries.GetShippers
{
    public class GetShippersQuery : IRequest<ResultModel<List<GetShipperDto>>>
    {
        public PaginationDTO Filters { get; set; }
    }
}
