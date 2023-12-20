using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Customer;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Features.Customer.Queries.GetCustomersByFilter
{
    public class GetCustomersByFilterQueryHandler : IRequestHandler<GetCustomersByFilterQuery, ResultModel<List<GetCustomerDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCustomersByFilterQueryHandler> _logger;

        public GetCustomersByFilterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetCustomersByFilterQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultModel<List<GetCustomerDto>>> Handle(GetCustomersByFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var customersByFilter = await context.Repositories.CustomerRepository.GetCustomersFiltered(request.Filter);

                    if (!customersByFilter.Any())
                    {
                        var emptyResult = new List<GetCustomerDto>();
                        var errorMessage = "No results found.";
                        var errorResult = ResultModel<GetCustomerDto>.GetResultModel(emptyResult, 0, errorMessage);
                        errorResult.Error = true;

                        return errorResult;
                    }

                    var data = customersByFilter.ToList();

                    var customers = _mapper.Map<List<GetCustomerDto>>(data);

                    var result = new ResultModel<List<GetCustomerDto>>(customers);

                    return result;
                }
            }
            catch (Exception ex)
            {
                var exceptionMessage = string.Format("Unexpected exception {0}", ex.Message);

                _logger.LogError(exceptionMessage);

                var exceptionResult = ResultModel<GetCustomerDto>.GetResultModel(null, 0, exceptionMessage);
                exceptionResult.Error = true;

                return exceptionResult;
            }
        }
    }
}
