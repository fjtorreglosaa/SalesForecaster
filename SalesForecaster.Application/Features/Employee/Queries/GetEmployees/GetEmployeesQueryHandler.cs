using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Employee;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Features.Employee.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, ResultModel<List<GetEmployeeDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEmployeesQueryHandler> _logger;

        public GetEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetEmployeesQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultModel<List<GetEmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            using (var context = _unitOfWork.Create())
            {
                try
                {
                    var employees = await context.Repositories.EmployeeRepository.GetAllAsync();

                    if (!employees.Any())
                    {
                        var errorMessage = "No results found.";
                        var errorResult = ResultModel<GetEmployeeDto>.GetResultModel(null, 0, errorMessage);
                        errorResult.Error = true;

                        return errorResult;
                    }

                    var data = _mapper.Map<List<GetEmployeeDto>>(employees);

                    var paginatedData = data.OrderBy(x => x.FullName).Paginate(request.Filters);
                    
                    var result = ResultModel<GetEmployeeDto>.GetResultModel(paginatedData.ToList(), employees.Count, null, request.Filters.RecordsPerPage);
                    
                    result.Total = employees.Count;

                    return result;
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
}
