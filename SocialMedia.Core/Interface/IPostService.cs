using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interface
{
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        Task<Post> GetById(int id);
        Task Add(Post post);
        void Update(Post post);
        Task Delete(int id);
    }
}
