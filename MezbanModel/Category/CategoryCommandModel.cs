using System;
using System.Collections.Generic;
using System.Linq;
using MezbanData.DbContext;

namespace MezbanModel.Category
{
    public class CategoryCommandModel
    {
        public string Code { get; set; }
        public int SortOrder { get; set; }
        public long ContentDefinitionId { get; set; }
        public IList<Language> Languages { get; set; }
        public Contentdefinition ContentDefinition { get; set; }
    }
}
