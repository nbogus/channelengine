using ChannelEngine.BusinessLogic;
using ChannelEngine.Services;
using Moq;
using Xunit;

namespace ChannelEngine.Tests
{

    public class ChannelEngineApiServiceTests
    {
        private readonly IChannelEngineProductService _channelEngineProductService;
        Mock<IChannelEngineApiService> _apiServiceMock;
        public ChannelEngineApiServiceTests()
        {
            _apiServiceMock = new Mock<IChannelEngineApiService>();
            _apiServiceMock.Setup(a=>a.FetchAllOrders()).ReturnsAsync(DataGenerator.CreateDummyData());
            _channelEngineProductService = new ChannelEngineProductService(_apiServiceMock.Object);
        }

        [Fact]
        public void ShouldReturnTop5Products()
        {
            //arrange
            //act
            var result =  _channelEngineProductService.GetProductsFromOrders().Result;
            //assert
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void ShouldReturnOrderedProducts()
        {
            //arrange
            //act
            var result = _channelEngineProductService.GetProductsFromOrders().Result;
            //assert
            Assert.Equal(20, result[0].Quantity);
            Assert.Equal(5, result[1].Quantity);
        }

        [Fact]
        public void ShouldReturnThrowExceptionWhenResponseIsNotSuccess()
        {
            //arrange
            var dummyData = DataGenerator.CreateDummyData();
            dummyData.Success = false;
            _apiServiceMock.Setup(a => a.FetchAllOrders()).ReturnsAsync(dummyData);
            //act
            var ex = Record.Exception(()=>_channelEngineProductService.GetProductsFromOrders().Result);
            //assert
            Assert.NotNull(ex);
            Assert.Equal("Error during getting data from api.",ex.InnerException.Message);
        }
    }
}
