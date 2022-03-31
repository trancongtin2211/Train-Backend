using System;
using System.Collections.Generic;
using Train.Models;
namespace Data.DTO
{
    public record ItemDTO
    {
        public Guid Id {get; init;}
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate{get; init;}
    }
}