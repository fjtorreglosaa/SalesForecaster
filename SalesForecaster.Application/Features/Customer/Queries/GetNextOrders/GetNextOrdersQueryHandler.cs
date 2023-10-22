using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Order;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Features.Customer.Queries.GetNextOrders
{
    public class GetNextOrdersQueryHandler : IRequestHandler<GetNextOrdersQuery, ResultModel<List<NextOrderDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetNextOrdersQuery> _logger;

        public GetNextOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetNextOrdersQuery> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultModel<List<NextOrderDto>>> Handle(GetNextOrdersQuery request, CancellationToken cancellationToken)
        {
            using (var context = _unitOfWork.Create())
            {
                try
                {
                    var nextOrders = await context.Repositories.CustomerRepository.GetCustomersNextOrders();

                    if (!nextOrders.Any())
                    {
                        var emptyResult = new List<NextOrderDto>();
                        var errorMessage = "No results found.";
                        var errorResult = ResultModel<NextOrderDto>.GetResultModel(emptyResult, 0, errorMessage);
                        errorResult.Error = true;

                        return errorResult;
                    }

                    var data = _mapper.Map<List<NextOrderDto>>(nextOrders);

                    var result = ResultModel<NextOrderDto>.GetResultModel(data.ToList(), nextOrders.Count, null);

                    result.Total = nextOrders.Count;

                    return result;
                }
                catch (Exception ex)
                {
                    var exceptionMessage = string.Format("Unexpected exception {0}", ex.Message);

                    _logger.LogError(exceptionMessage);

                    var exceptionResult = ResultModel<NextOrderDto>.GetResultModel(null, 0, exceptionMessage);
                    exceptionResult.Error = true;

                    return exceptionResult;
                }
            }
        }
    }
}
