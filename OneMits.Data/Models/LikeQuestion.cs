using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Data.Models
{
    public class LikeQuestion
    {
        public int Id { get; set; }
        public bool IsLike { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Question Question { get; set; }
    }
}
