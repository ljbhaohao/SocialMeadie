using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interface
{
    public interface IPostService
    {
        PagedList<Post> GetAll(PostQueryFilter filter);
        Task<Post> GetById(int id);
        Task Add(Post post);
        Task<bool> Update(Post post);
        Task<bool> Delete(int id);
    }
}
