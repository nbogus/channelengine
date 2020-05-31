using ChannelEngine.Services.Models;

namespace ChannelEngine.Tests
{
    public class DataGenerator
    {
        public static OrderCollectionResponse CreateDummyData()
        {
            var product = new Line
            {
                Quantity = "20",
                MerchantProductNo = "MSGH1-S",
                Gtin = "1234567890"
            };

            var productSecond = new Line
            {
                Quantity = "5",
                MerchantProductNo = "MSGH1-X",
                Gtin = "1234567890"
            };

            var productSecondThird = new Line
            {
                Quantity = "4",
                MerchantProductNo = "MSGH1-M",
                Gtin = "1234567890"
            };

            var productSecondFourth = new Line
            {
                Quantity = "3",
                MerchantProductNo = "MSGH1-M1",
                Gtin = "1234567890"
            };

            var productSecondFifth = new Line
            {
                Quantity = "2",
                MerchantProductNo = "MSGH1-M2",
                Gtin = "1234567890"
            };

            var productSecondSixth = new Line
            {
                Quantity = "1",
                MerchantProductNo = "MSGH1-M3",
                Gtin = "1234567890"
            };

            var order = new Order
            {
                Lines = new Line[2] { product, productSecond }
            };

            var order2 = new Order
            {
                Lines = new Line[4] { productSecondThird, productSecondFourth, productSecondFifth, productSecondSixth }
            };

            var response = new OrderCollectionResponse
            {
                Content = new Order[2] { order, order2 },
                Success = true
            };
            return response;
        }
    }
}
