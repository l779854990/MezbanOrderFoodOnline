using System;

namespace MezbanModel.Category
{
    public class CategoryCommandModel
    {
        public Guid CategoryId { get; set; }
        public string Code { get; set; }
        public int SortOrder { get; set; }
        public string NameVi { get; set; }
        public string DiscriptionVi { get; set; }
        public string NameEn { get; set; }
        public string DiscriptionEn { get; set; }
        public bool Status { get; set; }
    }
}
