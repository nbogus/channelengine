namespace ChannelEngine.Services.Models
{
    public class ProductStockUpdate
    {
        public string MerchantProductNo { get; set; }
        public int Stock { get; set; }
    }

    public class ProductStockUpdateRequest
    {
        public ProductStockUpdate[] ProductStockUpdate { get; set; }
    }

}
