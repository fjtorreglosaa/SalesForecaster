using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Product;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Features.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ResultModel<List<GetProductDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetProductsQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultModel<List<GetProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            using (var context = _unitOfWork.Create())
            {
                try
                {
                    var products = await context.Repositories.ProductRepository.GetAllAsync();

                    if (!products.Any())
                    {
                        var errorMessage = "No hay resultados para mostrar";
                        var errorResult = ResultModel<GetProductDto>.GetResultModel(null, 0, errorMessage);
                        errorResult.Error = true;
                        return errorResult;
                    }

                    var data = _mapper.Map<List<GetProductDto>>(products);

                    data.OrderBy(x => x.ProductName).Paginate(request.Filters);

                    var result = ResultModel<GetProductDto>.GetResultModel(data, products.Count, null, request.Filters.RecordsPerPage);

                    result.Total = products.Count;

                    return result;
                }
                catch (Exception ex)
                {
                    var exceptionMessage = string.Format("Unexpected exception {0}", ex.Message);

                    _logger.LogError(exceptionMessage);

                    var exceptionResult = ResultModel<GetProductDto>.GetResultModel(null, 0, exceptionMessage);
                    exceptionResult.Error = true;

                    return exceptionResult;
                }
            }
        }
    }
}
