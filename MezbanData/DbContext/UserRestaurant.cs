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
    
    public partial class UserRestaurant
    {
        public long UserRestaurantId { get; set; }
        public System.Guid RestaurantId { get; set; }
        public string UserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
