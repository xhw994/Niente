﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Niente.Models;

namespace Niente.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {  
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ValueConverter<Uri[], string> strArrayToUriArrayConverter = new ValueConverter<Uri[], string>(
                v => string.Join(";", Array.ConvertAll(v, item => item.OriginalString)),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries)
                      .Select(val => new Uri(val)).ToArray());

            builder.Entity<Article>().Property(a => a.CreateAt).ValueGeneratedOnAdd().HasDefaultValueSql("NOW()");
            builder.Entity<Article>().Property(a => a.LastEditAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("NOW()"); ;
            builder.Entity<Article>().Property(a => a.ImageUris).HasConversion(strArrayToUriArrayConverter);
        }

        public DbSet<Article> Articles { get; set; }
    }
}
