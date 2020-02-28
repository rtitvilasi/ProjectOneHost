using OneMits.Models.ApplicationUser;
using OneMits.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Search
{
    public class SearchModel
    {
        public IEnumerable<QuestionListingModel> Questions { get; set; }
        public IEnumerable<ProfileModel> UserList { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}
