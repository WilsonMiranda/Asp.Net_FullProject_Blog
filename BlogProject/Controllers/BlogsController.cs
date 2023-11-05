using BlogProject.Models.Domain;
using BlogProject.Models.ViewModels;
using BlogProject.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBlogPostCommentRepository blogPostCommentRepository;

        public BlogsController(IBlogPostRepository blogPostRepository,
            IBlogPostLikeRepository blogPostLikeRepository, 
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser>  userManager,
            IBlogPostCommentRepository blogPostCommentRepository )
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.blogPostCommentRepository = blogPostCommentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var blogPost = await blogPostRepository.GetByurlHandleAsync(urlHandle);
            var blogPostLikeViewModel = new BlogDetailsViewModel();
            var liked = false;

            if (blogPost != null)
            {
                var totalLikes =  await blogPostLikeRepository.GetTotalLikes(blogPost.Id);

                if(signInManager.IsSignedIn(User))
                {
                    //get like of this user for this blog
                    var likesForBlog =  await blogPostLikeRepository.GetLikeForBlog(blogPost.Id);

                    var userId =  userManager.GetUserId(User);

                    if (userId != null)
                    {
                        var likeFromUser = likesForBlog.FirstOrDefault(x => x.UserId == Guid.Parse(userId));
                        liked = likeFromUser != null;
                    }
                }

                //get comments for blogPost
                var blogCommentsDomainModel = await blogPostCommentRepository.GetCommentsByBlogIdAsync(blogPost.Id);

                var bloCommentsForView = new List<BlogComment>();

                foreach (var blogComment in blogCommentsDomainModel)
                {
                    bloCommentsForView.Add(new BlogComment
                    {
                        Description = blogComment.Description,
                        DateAdded = blogComment.DateAdded,
                        Username = (await userManager.FindByIdAsync(blogComment.UserId.ToString())).UserName
                    });
                }   


                blogPostLikeViewModel = new BlogDetailsViewModel
                {
                    Id = blogPost.Id,
                    Heading = blogPost.Heading,
                    PageTitle = blogPost.PageTitle,
                    Content = blogPost.Content,
                    ShortDescription = blogPost.ShortDescription,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    UrlHandle = blogPost.UrlHandle,
                    PublishedDate = blogPost.PublishedDate,
                    Author = blogPost.Author,
                    Visible = blogPost.Visible,
                    Tags = blogPost.Tags,
                    TotalLikes = totalLikes,
                    Liked = liked,
                    Comments = bloCommentsForView

                };
            }

            return View(blogPostLikeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BlogDetailsViewModel blogDetailsViewModel)
        {
            if(signInManager.IsSignedIn(User))
            {
                var domainModel = new BlogPostComment
                {
                    BlogPostId = blogDetailsViewModel.Id,
                    Description = blogDetailsViewModel.CommentDescription,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    DateAdded = DateTime.Now

                };

                await blogPostCommentRepository.AddAsync(domainModel);
                return RedirectToAction("Index", "Blogs", new { UrlHandle = blogDetailsViewModel.UrlHandle });
            }

            return View();
        }

    }
}
