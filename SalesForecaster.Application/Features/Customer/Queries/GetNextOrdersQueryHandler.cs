using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Features.Customer.Queries
{
    public class GetNextOrdersQueryHandler : IRequestHandler<GetNextOrdersQuery, ResultModel<List<NextOrderDTO>>>
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

        public async Task<ResultModel<List<NextOrderDTO>>> Handle(GetNextOrdersQuery request, CancellationToken cancellationToken)
        {
            using (var context = _unitOfWork.Create())
            {
                try
                {
                    var nextOrders = await context.Repositories.CustomerRepository.GetCustomersNextOrders();

                    if (!nextOrders.Any())
                    {
                        var errorMessage = "No results found.";
                        var errorResult = ResultModel<NextOrderDTO>.GetResultModel(null, 0, errorMessage);
                        errorResult.Error = true;

                        return errorResult;
                    }

                    var data = _mapper.Map<List<NextOrderDTO>>(nextOrders);

                    var paginatedData = data.OrderBy(x => x.CompanyName).Paginate(request.Filters);

                    var result = ResultModel<NextOrderDTO>.GetResultModel(paginatedData.ToList(), nextOrders.Count, null, request.Filters.RecordsPerPage);

                    result.Total = nextOrders.Count;

                    return result;
                }
                catch (Exception ex)
                {
                    var exceptionMessage = string.Format("Unexpected exception {0}", ex.Message);

                    _logger.LogError(exceptionMessage);

                    var exceptionResult = ResultModel<NextOrderDTO>.GetResultModel(null, 0, exceptionMessage);
                    exceptionResult.Error = true;

                    return exceptionResult;
                }
            }
        }
    }
}
