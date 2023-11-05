﻿using BlogProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogDbContext blogDbContext;

        public BlogPostLikeRepository(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await blogDbContext.BlogPostLike.CountAsync(
                x => x.BlogPostId == blogPostId);
        }
    }
}
