using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDescription { get; set; }
        public DateTime CategoryCreated { get; set; }
        public string CategoryImageUrl { get; set; }
        public virtual IEnumerable<Question> Questions { get; set; }
      
    }
}
