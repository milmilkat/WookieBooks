﻿using System;
using System.Threading.Tasks;
using WookieBooks.Models.Dbs;

namespace WookieBooks.Data
{
    public class DataGenerator
    {
        public async Task SeedAsync(WookieContext context)
        {
            var cSharpBookStringBytes = "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";
            var javaBookStringBytes = "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";


            context.Authors.AddRange(
                    new Author
                    {
                        Id = 1,
                        Name = "Author1"
                    },
                    new Author
                    {
                        Id = 2,
                        Name = "Author2"
                    }
                );

            context.Books.AddRange(
                new Book
                {
                    Id = 1,
                    Title = "C# Book",
                    Description = "A book about C#",
                    AuthorId = 1,
                    CoverImage = Convert.FromBase64String(cSharpBookStringBytes),
                    Price = 20
                },
                new Book
                {
                    Id = 2,
                    Title = "Java Book",
                    Description = "A book about Java",
                    AuthorId = 2,
                    CoverImage = Convert.FromBase64String(javaBookStringBytes),
                    Price = 5
                }
            );

            await context.SaveChangesAsync();
        }
    }
}