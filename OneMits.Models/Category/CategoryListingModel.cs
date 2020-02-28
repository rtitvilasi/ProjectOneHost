using OneMits.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;
using OneMits.Data.Models;

namespace OneMits.Models.Category
{
    public class CategoryListingModel
    {

        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryImageUrl { get; set; }
        public int QuestionCount { get; set; }
        public virtual IEnumerable<QuestionListingModel> Questions { get; set; }
        
    }
}
