using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject.Models.ViewModels
{
    public class EditBlogPostRequest
    {
        public Guid Id { get; set; }

        public string Heading { get; set; }

        public string PageTitle { get; set; }

        public string Content { get; set; }

        public string ShortDescription { get; set; }

        public string FeaturedImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        //to alow null values, add a question mark after the type like this:  public string? Author { get; set; }
        public string Author { get; set; }

        public bool Visible { get; set; }

        //Display tags in the blog post
        public IEnumerable<SelectListItem> Tags { get; set; }

        //Collect the selected tag
        public string[] SelectedTags { get; set; } = Array.Empty<string>();
    }
}
