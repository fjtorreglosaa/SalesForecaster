using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesForecaster.Application.Features.Employee.Queries.GetEmployeedFiltered;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Employee;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Features.Employee.Queries.GetEmployeedByFiltered
{
    public class
        GetEmployeeByFilteredQueryHandler : IRequestHandler<GetEmployeeByFilteredQuery,ResultModel<List<GetEmployeeDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetEmployeeByFilteredQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultModel<List<GetEmployeeDto>>> Handle(GetEmployeeByFilteredQuery request,CancellationToken cancellationToken)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var employeebyFilter = await context.Repositories.EmployeeRepository.GetEmployeeFiltered(request.Filter);

                    if (!employeebyFilter.Any()) 
                    {
                        return null;
                    }

                    var data = employeebyFilter.ToList();

                    var employee = _mapper.Map<List<GetEmployeeDto>>(data);

                    var result = new ResultModel<List<GetEmployeeDto>>(employee);

                    return result;
                }
            }

            catch (Exception ex)

            {
                var exceptionMessage = string.Format("Unexpected exception {0}", ex.Message);

                _logger.LogError(exceptionMessage);

                var exceptionResult = ResultModel<GetEmployeeDto>.GetResultModel(null, 0, exceptionMessage);
                exceptionResult.Error = true;

                return exceptionResult;
            }
        }
    }
}

