using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Data.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionContent { get; set; }
        public DateTime QuestionCreated { get; set; }
        public int NumberViews { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
        
        public virtual IEnumerable<Answer> Answers { get; set; }
        public virtual IEnumerable<LikeQuestion> LikeQuestions { get; set; }
    }
}
