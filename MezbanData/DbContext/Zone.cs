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
    
    public partial class Zone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zone()
        {
            this.RestaurantAreas = new HashSet<RestaurantArea>();
        }
    
        public long ZoneId { get; set; }
        public long DistrictId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<bool> Status { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    
        public virtual District District { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestaurantArea> RestaurantAreas { get; set; }
    }
}
