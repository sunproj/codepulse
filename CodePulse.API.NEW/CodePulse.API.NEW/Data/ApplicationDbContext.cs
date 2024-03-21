﻿using CodePulse.API.NEW.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CodePulse.API.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

        public DbSet<Category> Categories { get; set; }
		public DbSet<BlogPost> BlogPosts { get; set; }
	}
}
