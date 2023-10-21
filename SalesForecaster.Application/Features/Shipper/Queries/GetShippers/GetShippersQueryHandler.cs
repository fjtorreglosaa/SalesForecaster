using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Shipper;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Features.Shipper.Queries.GetShippers
{
    public class GetShippersQueryHandler : IRequestHandler<GetShippersQuery, ResultModel<List<GetShipperDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetShippersQueryHandler> _logger;

        public GetShippersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetShippersQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultModel<List<GetShipperDto>>> Handle(GetShippersQuery request, CancellationToken cancellationToken)
        {
            using (var context = _unitOfWork.Create())
            {
                try
                {
                    var shippers = await context.Repositories.ShipperRepository.GetAllAsync();

                    if (!shippers.Any())
                    {
                        var errorMessage = "No hay resultados para mostrar";
                        var errorResult = ResultModel<GetShipperDto>.GetResultModel(null, 0, errorMessage);
                        errorResult.Error = true;
                        return errorResult;
                    }

                    var data = _mapper.Map<List<GetShipperDto>>(shippers);

                    data.OrderBy(x => x.CompanyName).Paginate(request.Filters);

                    var result = ResultModel<GetShipperDto>.GetResultModel(data, shippers.Count, null, request.Filters.RecordsPerPage);

                    result.Total = shippers.Count;

                    return result;
                }
                catch (Exception ex)
                {
                    var exceptionMessage = string.Format("Unexpected exception {0}", ex.Message);

                    _logger.LogError(exceptionMessage);

                    var exceptionResult = ResultModel<GetShipperDto>.GetResultModel(null, 0, exceptionMessage);
                    exceptionResult.Error = true;

                    return exceptionResult;
                }
            }
        }
    }
}
