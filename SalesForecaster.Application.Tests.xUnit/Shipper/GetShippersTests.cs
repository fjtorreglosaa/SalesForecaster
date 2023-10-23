using Moq;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Application.Tests.xUnit.Shipper
{
    /// <summary>
    /// Esto se hace de forma similar para todos los proyectos, tanto persistencia, como presentación, y para cada uno de los caminos posibles
    /// </summary>
    public class GetShippersTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IUnitOfWorkAdapter> _unitOfWorkAdapterMock;
        private readonly Mock<IUnitOfWorkRepository> _unitOfWorkRepositoryMock;
        private readonly Mock<IShipperRepository> _shipperRepositoryMock;

        public GetShippersTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _unitOfWorkAdapterMock = new Mock<IUnitOfWorkAdapter>();
            _unitOfWorkRepositoryMock = new Mock<IUnitOfWorkRepository>();

            _unitOfWorkMock.Setup(uow => uow.Create(It.IsAny<string>()))
                           .Returns(_unitOfWorkAdapterMock.Object);

            _unitOfWorkAdapterMock.SetupGet(uowAdapter => uowAdapter.Repositories)
                                  .Returns(_unitOfWorkRepositoryMock.Object);

            _shipperRepositoryMock = new Mock<IShipperRepository>();
            _shipperRepositoryMock.Setup(repo => repo.GetAllAsync())
                                 .ReturnsAsync(new List<ShipperModel>
                                 {
                                     new ShipperModel
                                     {
                                         ShipperId = 1,
                                         CompanyName = "SHIPPER 1",
                                         Phone = "444-444-444"
                                     },
                                     new ShipperModel
                                     {
                                         ShipperId = 2,
                                         CompanyName = "SHIPPER 2",
                                         Phone = "555-555-555"
                                     }
                                 });

            _shipperRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                                 .ReturnsAsync((int id) =>
                                 {
                                     return new ShipperModel { ShipperId = 1, CompanyName = "SHIPPER 1", Phone = "444-444-444" };
                                 });

            _unitOfWorkRepositoryMock.Setup(repo => repo.ShipperRepository)
                                     .Returns(_shipperRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle()
        {
            // Act
            var shippers = await _unitOfWorkRepositoryMock.Object.ShipperRepository.GetAllAsync();
            var result = shippers.ToList();

            // Assert
            Assert.Equal(2, result.Count);
        }
    }
}
