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
    
    public partial class ContentEntry
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public string Token { get; set; }
        public int LanguageId { get; set; }
        public long ContendefinitionId { get; set; }
    
        public virtual Contentdefinition Contentdefinition { get; set; }
        public virtual Language Language { get; set; }
    }
}
