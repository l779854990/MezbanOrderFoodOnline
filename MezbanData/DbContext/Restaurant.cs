//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MezbanData.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            this.Comments = new HashSet<Comment>();
            this.Favories = new HashSet<Favory>();
            this.Menus = new HashSet<Menu>();
            this.Orders = new HashSet<Order>();
            this.PromotionLineItems = new HashSet<PromotionLineItem>();
            this.Ratings = new HashSet<Rating>();
            this.RestaurantAreas = new HashSet<RestaurantArea>();
            this.RestaurantCategories = new HashSet<RestaurantCategory>();
            this.UserRestaurants = new HashSet<UserRestaurant>();
            this.RestaurantWorkTimes = new HashSet<RestaurantWorkTime>();
        }
    
        public System.Guid RestaurantId { get; set; }
        public string Address { get; set; }
        public string Avartar { get; set; }
        public long ContendifinitionId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public string Slogan { get; set; }
        public string PhoneNumber { get; set; }
        public string KeySearch { get; set; }
        public Nullable<decimal> MinPrice { get; set; }
        public string EstimateTimeDelivery { get; set; }
        public long SeqId { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Name { get; set; }
        public string ShipArea { get; set; }
        public Nullable<long> DistrictId { get; set; }
        public Nullable<long> ZoneId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Contentdefinition Contentdefinition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favory> Favories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu> Menus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionLineItem> PromotionLineItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Ratings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurantArea> RestaurantAreas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurantCategory> RestaurantCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRestaurant> UserRestaurants { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurantWorkTime> RestaurantWorkTimes { get; set; }
    }
}