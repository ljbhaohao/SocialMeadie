using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Entities
{
  public  class Post:BaseEntity
    {
        public int UserId { get; set; }
        public string Desc { get; set; }
        public DateTime LastModified { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
