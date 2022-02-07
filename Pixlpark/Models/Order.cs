using Newtonsoft.Json;
using System;

namespace Pixlpark.Models
{
    public class Order
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("PhotolabId")]
        public string PhotolabId { get; set; }

        [JsonProperty("CustomId")]
        public string CustomId { get; set; }

        [JsonProperty("SourceOrderId")]
        public string SourceOrderId { get; set; }

        [JsonProperty("ManagerId")]
        public string ManagerId { get; set; }

        [JsonProperty("AssignedToId")]
        public string AssignedToId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("TrackingUrl")]
        public string TrackingUrl { get; set; }

        [JsonProperty("TrackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("RenderStatus")]
        public string RenderStatus { get; set; }

        [JsonProperty("PaymentStatus ")]
        public string PaymentStatus { get; set; }

        [JsonProperty("CommentsCount")]
        public int CommentsCount { get; set; }

        [JsonProperty("DownloadLink")]
        public string DownloadLink { get; set; }

        [JsonProperty("PreviewImageUrl")]
        public string PreviewImageUrl { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("DiscountPrice")]
        public decimal DiscountPrice { get; set; }

        [JsonProperty("DeliveryPrice")]
        public decimal DeliveryPrice { get; set; }

        [JsonProperty("TotalPrice")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("PaidPrice")]
        public decimal PaidPrice { get; set; }

        [JsonProperty("UserId ")]
        public long UserId { get; set; }

        [JsonProperty("UserCompanyAccountId")]
        public string UserCompanyAccountId { get; set; }

        [JsonProperty("DiscountTitle")]
        public string DiscountTitle { get; set; }

        [JsonProperty("DateCreated")]
        public DateTime DateCreated { get; set; } //???

        [JsonProperty("DateModified")]
        public DateTime? DateModified { get; set; }

        [JsonProperty("DatePaid")]
        public DateTime? DatePaid { get; set; }

        [JsonProperty("DateReady")]
        public DateTime? DateReady { get; set; }

        [JsonProperty("LastDownloadedPaymentDocument")]
        public string LastDownloadedPaymentDocument { get; set; } //?

        [JsonProperty("PaymentSystemUniqueId")]
        public string PaymentSystemUniqueId { get; set; }

        [JsonProperty("GoogleClientId")]
        public string GoogleClientId { get; set; }

        [JsonProperty("ContractorOrders")]
        public string ContractorOrders { get; set; }

        [JsonProperty("DeliveryAddress")]
        public DeliveryAddress DeliveryAddress { get; set; }

        [JsonProperty("Shipping")]
        public Shipping Shipping { get; set; }
               
    }
}
