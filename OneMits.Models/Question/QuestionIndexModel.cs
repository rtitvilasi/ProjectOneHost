using OneMits.Models.Answer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneMits.Models.Question
{
    public class QuestionIndexModel
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string AuthorId { get; set; }
        public int NumberView { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public int AnswerCount { get; set; }
        public DateTime QuestionCreated { get; set; }


        [Required]
        [MaxLength(10, ErrorMessage = "Description cannot be longer than 10 characters.")]
        public string QuestionContent { get; set; }
        public bool IsAuthorAdmin { get; set; }
        public int LikeCount { get; set; }
        public int LikeCountAnswer { get; set; }

        public int AnswerId { get; set; }
        public DateTime AnswerCreated { get; set; }
        public string AnswerContent { get; set; }


        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryImageUrl { get; set; }

        public IEnumerable<AnswerModel> Answers { get; set; }
    }
}
