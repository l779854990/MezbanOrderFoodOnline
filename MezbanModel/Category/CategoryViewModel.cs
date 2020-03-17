using MezbanData.DbContext;
using System;
using System.Collections.Generic;

namespace MezbanModel.Category
{
    public class CategoryViewModel : BaseViewModel
    {
        public Guid CategoryId { get; set; }
        public string Code { get; set; }
        public int SortOrder { get; set; }
        public IList<Language> Languages { get; set; }
        public ContentDefinition ContentDefinition { get; set; }
        public bool Status { get; set; }
    }
}
