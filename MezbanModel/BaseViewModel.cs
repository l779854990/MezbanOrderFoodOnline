using System;
using System.Collections.Generic;

namespace MezbanModel
{
    public class BaseViewModel
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<LanguageVm> LanguageVms { get; set; } = new List<LanguageVm>();
        public int CurrentPage { get; set; }
        public int? Page { get; set; }
    }
    public class LanguageVm
    {
        public int LanguageId { get; set; }
        public string Value { get; set; }
        public string Token { get; set; }
    }

}
