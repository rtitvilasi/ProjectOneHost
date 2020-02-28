using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Data.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerContent { get; set; }
        public DateTime AnswerCreated { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Question Question { get; set; }
        public virtual IEnumerable<LikeAnswer> LikeAnswers { get; set; }
    }
}
