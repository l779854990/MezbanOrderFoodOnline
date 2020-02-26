using System;

namespace MezbanModel.Restaurant
{
    public class RestaurantListModel : BaseViewModel
    {
        public System.Guid RestaurantId { get; set; }
        public string Address { get; set; }
        public string Avartar { get; set; }
        public long ContendifinitionId { get; set; }
        public string Slogan { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<decimal> MinPrice { get; set; }
        public string EstimateTimeDelivery { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
    }
}
