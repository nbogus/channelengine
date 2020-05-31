using ChannelEngine.Domain;
using ChannelEngine.Web.Models;

namespace ChannelEngine.Web.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel MapToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                EAN = product.EAN,
                MerchantProductNo = product.MerchantProductNo,
                Quantity = product.Quantity
            };
        }
    }
}