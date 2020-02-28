using OneMits.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Question
{
    public class QuestionListingModel
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionCreated { get; set; }
        public string QuestionContent { get; set; }

        public int NumberView { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AnswerCount { get; set; }
        public virtual CategoryListingModel Category { get; set; }
    }
}
