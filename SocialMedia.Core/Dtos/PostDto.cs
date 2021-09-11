using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Dtos
{
    public class PostDto
    {
        public int UserId { get; set; }
        public string Desc { get; set; }
        public DateTime Updatetime { get; set; }
        public string Image { get; set; }
    }
}
