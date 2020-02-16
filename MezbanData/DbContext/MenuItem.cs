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
    
    public partial class MenuItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuItem()
        {
            this.Options = new HashSet<Option>();
        }
    
        public System.Guid MenuItemId { get; set; }
        public string Code { get; set; }
        public long CondefinitionId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> HasCombo { get; set; }
        public Nullable<int> SortOder { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.Guid MenuId { get; set; }
        public long SeqId { get; set; }
    
        public virtual Contentdefinition Contentdefinition { get; set; }
        public virtual Menu Menu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Option> Options { get; set; }
    }
}
