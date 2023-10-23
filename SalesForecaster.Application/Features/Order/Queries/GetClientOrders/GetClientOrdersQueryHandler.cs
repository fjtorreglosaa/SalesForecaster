using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Order;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Features.Order.Queries.GetClientOrders
{
    public class GetClientOrdersQueryHandler : IRequestHandler<GetClientOrdersQuery, ResultModel<List<GetOrderDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetClientOrdersQueryHandler> _logger;

        public GetClientOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetClientOrdersQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultModel<List<GetOrderDto>>> Handle(GetClientOrdersQuery request, CancellationToken cancellationToken)
        {
            using (var context = _unitOfWork.Create())
            {
                try
                {
                    var validations = ModelValidations(request);

                    if (validations != null) return validations;

                    var clientOrders = await context.Repositories.OrderRepository.GetByCustomerIdAsync(request.ClientId.Value);

                    if (!clientOrders.Any())
                    {
                        var errorMessage = "No results found";
                        var emptyResult = new List<GetOrderDto>();
                        var errorResult = ResultModel<GetOrderDto>.GetResultModel(emptyResult, 0, errorMessage);
                        errorResult.Error = false;
                        return errorResult;
                    }

                    foreach (var order in clientOrders)
                    {
                        var orderDetails = await context.Repositories.OrderDetailRepository.GetByOrderId(order.OrderId);
                        order.OrderDetails = orderDetails.ToList();
                    }

                    var data = _mapper.Map<List<GetOrderDto>>(clientOrders);

                    var result = ResultModel<GetOrderDto>.GetResultModel(data, clientOrders.Count, null);

                    result.Total = clientOrders.Count;

                    return result;
                }
                catch (Exception ex)
                {
                    var exceptionMessage = string.Format("Unexpected exception {0}", ex.Message);

                    _logger.LogError(exceptionMessage);

                    var exceptionResult = ResultModel<GetOrderDto>.GetResultModel(null, 0, exceptionMessage);
                    exceptionResult.Error = true;

                    return exceptionResult;
                }
            }
        }

        private ResultModel<List<GetOrderDto>> ModelValidations(GetClientOrdersQuery request)
        {
            if (request.ClientId == null || request.ClientId <= 0)
            {
                var errorMessage = "No results found";
                var emptyResult = new List<GetOrderDto>();
                var errorResult = ResultModel<GetOrderDto>.GetResultModel(emptyResult, 0, errorMessage);
                errorResult.Error = false;

                return errorResult;
            }

            return null;
        }
    }
}
