using OneMits.Models.Category;
using OneMits.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Category
{
    public class CategoryTopicModel
    {
        public CategoryListingModel Category { get; set; }
        public IEnumerable<QuestionListingModel> Questions { get; set; }
        public string SearchQuery { get; set; }
    }
}
