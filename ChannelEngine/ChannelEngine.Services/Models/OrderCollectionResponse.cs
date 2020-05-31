using System;

namespace ChannelEngine.Services.Models
{
    public class OrderCollectionResponse
    {
        public Order[] Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public int? LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ValidationErrors ValidationErrors { get; set; }
    }

    public class ValidationErrors
    {
        public string[] AdditionalProp1 { get; set; }
        public string[] AdditionalProp2 { get; set; }
        public string[] AdditionalProp3 { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public int GlobalChannelId { get; set; }
        public string ChannelOrderSupport { get; set; }
        public string ChannelOrderNo { get; set; }
        public string Status { get; set; }
        public bool IsBusinessOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string MerchantComment { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public double SubTotalInclVat { get; set; }
        public double SubTotalVat { get; set; }
        public double ShippingCostsVat { get; set; }
        public double TotalInclVat { get; set; }
        public double TotalVat { get; set; }
        public double OriginalSubTotalInclVat { get; set; }
        public double OriginalSubTotalVat { get; set; }
        public double OriginalShippingCostsInclVat { get; set; }
        public double OriginalShippingCostsVat { get; set; }
        public double OriginalTotalInclVat { get; set; }
        public double OriginalTotalVat { get; set; }
        public Line[] Lines { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CompanyRegistrationNo { get; set; }
        public string VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public double ShippingCostsInclVat { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string ChannelCustomerNo { get; set; }
        public ExtraData ExtraData { get; set; }
    }

    public class BillingAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public string HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryIso { get; set; }
        public string Original { get; set; }
    }

    public class ShippingAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public string HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryIso { get; set; }
        public string Original { get; set; }
    }

    public class ExtraData
    {
        public string AdditionalProp1 { get; set; }
        public string AdditionalProp2 { get; set; }
        public string AdditionalProp3 { get; set; }
    }

    public class Line
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string MerchantProductNo { get; set; }
        public string Gtin { get; set; }
        public double UnitVat { get; set; }
        public double LineTotalInclVat { get; set; }
        public double LineVat { get; set; }
        public double OriginalUnitPriceInclVat { get; set; }
        public double OriginalUnitVat { get; set; }
        public double OriginalLineTotalInclVat { get; set; }
        public double OriginalLineVat { get; set; }
        public string BundleProductMerchantProductNo { get; set; }
        public ExtraInformation[] ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string Quantity { get; set; }
        public int CancellationRequestedQuantity { get; set; }
        public double UnitPriceInclVat { get; set; }
        public double FeeFixed { get; set; }
        public double FeeRate { get; set; }
        public string Condition { get; set; }
    }

    public class ExtraInformation
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}