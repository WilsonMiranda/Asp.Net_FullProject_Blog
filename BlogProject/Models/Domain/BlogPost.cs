namespace BlogProject.Models.Domain
{
    public class BlogPost
    {
        //prop tab tab to create a property

        //Guid is a unique identifier
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

        //Build a relationship ManyToMany between BlogPost and Tag
        public ICollection<Tag> Tags { get; set; }

    }
}
