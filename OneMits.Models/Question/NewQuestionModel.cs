using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Question
{
    public class NewQuestionModel
    {
        public string CategoryTitle { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string CategoryImageUrl { get; set; }

        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public string QuestionTitle { get; set; }
    }
}
