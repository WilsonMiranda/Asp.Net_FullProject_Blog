using BlogProject.Models.Domain;

namespace BlogProject.Models.ViewModels
{
    //using that  to put together the blogpost and tag
    public class HomeViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
