﻿using Bookstore.Api.Authors;

namespace Bookstore.Api.Books.Commands
{
    public class CreateBookCommandResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public IEnumerable<string>? AuthorNames { get; set; }

        public static CreateBookCommandResponse FromEntity(Book entity)
            => new()
            {
                Id = entity.Id,
                Title = entity.Title,
                Publisher = entity.Publisher,
                AuthorNames = entity.Authors.Select(s => s.Name)
            };
    }
}
