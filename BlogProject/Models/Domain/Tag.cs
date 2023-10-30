namespace BlogProject.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        //Build a relationship ManyToMany between BlogPost and Tag
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
