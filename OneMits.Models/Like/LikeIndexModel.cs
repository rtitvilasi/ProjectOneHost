using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Like
{
    public class LikeIndexModel
    {
        public int Id { get; set; }
        public bool IsLike { get; set; }
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }

    }
}
