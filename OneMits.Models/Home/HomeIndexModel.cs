using OneMits.Models.Category;
using OneMits.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public string IpAddress { get; set; }
        public IEnumerable<QuestionListingModel> RecentQuestion { get; set; }
        public IEnumerable<QuestionListingModel> PopularQuestion { get; set; }
        public IEnumerable<QuestionListingModel> MostResponseQuestion { get; set; }
        public IEnumerable<QuestionListingModel> PriorityQuestion { get; set; }

    }
}
