using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Data.Models
{
    public class LikeAnswer
    {
        public int Id { get; set; }
        public bool IsLike { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
