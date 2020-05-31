namespace ChannelEngine.Services.Models
{
    public class ProductStockUpdate
    {
        public string MerchantProductNo { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }

    public class ProductsStockUpdateRequest
    {
        public ProductStockUpdate[] Products { get; set; }
    }

}
