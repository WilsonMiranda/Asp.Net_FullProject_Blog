﻿using BlogProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        //Build the tables 
        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }


    }
}
