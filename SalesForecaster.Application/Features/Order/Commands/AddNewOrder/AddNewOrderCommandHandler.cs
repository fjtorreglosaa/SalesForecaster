using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Features.Order.Commands.AddNewOrder
{
    public class AddNewOrderCommandHandler : IRequestHandler<AddNewOrderCommand, ResultModel<List<string>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddNewOrderCommandHandler> _logger;

        public AddNewOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddNewOrderCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultModel<List<string>>> Handle(AddNewOrderCommand request, CancellationToken cancellationToken)
        {
            using (var context = _unitOfWork.Create())
            {
                try
                {
                    var modelValidations = ValidateModel(request);

                    if (modelValidations.Any())
                    {
                        var errorMessage = "Bad Request";

                        _logger.LogError(errorMessage);
                        modelValidations.ForEach(x => _logger.LogError(x));

                        var errorResult = ResultModel<List<string>>.GetResultModel(modelValidations, errorMessage);
                        errorResult.Error = true;

                        return errorResult;
                    }

                    var newOrder = new OrderModel
                    {
                        EmpId = request.Order.EmployeeId.Value,
                        CustId = request.Order.CustId.Value,
                        ShipperId = request.Order.ShipperId.Value,
                        ShipName = request.Order.ShipName,
                        ShipAddress = request.Order.ShipAddress,
                        ShipCountry = request.Order.ShipCountry,
                        OrderDate = request.Order.OrderDate.Value,
                        RequiredDate = request.Order.RequiredDate.Value,
                        ShippedDate = request.Order.ShippedDate,
                        Freight = request.Order.Freight.Value,
                        ShipCity = request.Order.ShipCity
                    };

                    var orderId = await context.Repositories.OrderRepository.AddAsync(newOrder);

                    foreach (var orderDetail in request.Order.OrderDetails)
                    {
                        var detail = _mapper.Map<OrderDetailModel>(orderDetail);
                        detail.OrderId = orderId;
                        await context.Repositories.OrderDetailRepository.AddAsync(detail);
                    }

                    context.Commit();

                    var result = ResultModel<List<string>>.GetResultModel(null, "Success");

                    return result;
                }
                catch (Exception ex)
                {
                    var exceptionMessage = string.Format("Unexpected exception {0}", ex.Message);

                    _logger.LogError(exceptionMessage);

                    var exceptionResult = ResultModel<List<string>>.GetResultModel(null, exceptionMessage);
                    exceptionResult.Error = true;

                    return exceptionResult;
                }
            }
        }

        private List<string> ValidateModel(AddNewOrderCommand request)
        {
            var errorMessages = new List<string>();

            if (request.Order?.ShipCountry?.Length > 15)
                errorMessages.Add("The length of the ShipCountry field cannot be longer than 15 characters.");
            if (request.Order?.ShipName?.Length > 40)
                errorMessages.Add("The length of the ShipName field cannot be longer than 40 characters.");
            if (request.Order?.ShippedDate < DateTime.Now)
                errorMessages.Add("The date of shipment cannot be less than the current date.");
            if (request.Order?.EmployeeId == null)
                errorMessages.Add("The EmployeeId field cannot be empty.");
            if (request.Order?.Freight == null || request.Order?.Freight.Value == 0)
                errorMessages.Add("The Freight field cannot be empty or zero.");
            if (request.Order?.ShipperId == null)
                errorMessages.Add("The ShipperId field cannot be empty.");
            if (!request.Order.OrderDetails.Any())
                errorMessages.Add("The detail of the order can not be empty.");
            if (request.Order.RequiredDate< DateTime.Now)
                errorMessages.Add("The required date cannot be less than the current date.");
            if (request.Order?.ShipAddress?.Length > 40)
                errorMessages.Add("The length of the ShipAddress field cannot be longer than 60 characters.");
            if (request.Order?.ShipCity?.Length > 15)
                errorMessages.Add("The length of the ShipCity field cannot be longer than 15 characters.");

            foreach (var detail in request.Order.OrderDetails)
            {
                if (detail?.ProductId == null)
                    errorMessages.Add("Detail of the order: the product field cannot be empty.");
                if (detail?.Qty == null)
                    errorMessages.Add("Detail of the order: the quantity field cannot be empty.");
                if (detail?.UnitPrice == null)
                    errorMessages.Add("Detail of the order: the unit price field cannot be empty.");
                if (detail?.Discount == null)
                    errorMessages.Add("Detail of the order: the discount field cannot be empty.");
            }

            return errorMessages;
        }
    }
}
