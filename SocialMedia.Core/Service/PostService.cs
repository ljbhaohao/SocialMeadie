using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interface;
using SocialMedia.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedList<Post> GetAll(PostQueryFilter filter)
        {
            var posts = _unitOfWork.PostRepository.GetAll();
            if (filter.Decription!=null)
            {
                posts = posts.Where(x => x.Desc.ToLower().Contains(filter.Decription.ToLower()));
            }
            if (filter.Date != null)
            {
                posts = posts.Where(x => x.LastModified.ToShortDateString() == filter.Date?.ToShortDateString());
            }
            if (filter.UserId != null)
            {
                posts = posts.Where(x => x.UserId == filter.UserId);
            }
            var pagePosts = PagedList<Post>.Create(posts, filter.PageNumber, filter.PageSize);
            return pagePosts;
        }
        public async Task<Post> GetById(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }
        public async Task Add(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user==null)
            {

            }
            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool>  Update(Post post)
        {
            var existingPost = await _unitOfWork.PostRepository.GetById(post.Id);
            existingPost.Image = post.Image;
            existingPost.Desc = post.Desc;
            _unitOfWork.PostRepository.Update(existingPost);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
