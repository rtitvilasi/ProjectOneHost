using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Answer
{
    public class AnswerModel
    {
        public int AnswerId { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public int LikeCountAnswer { get; set; }

        public DateTime AnswerCreated { get; set; }
        public string AnswerContent { get; set; }
        public bool IsAuthorAdmin { get; set; }
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionContent { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
