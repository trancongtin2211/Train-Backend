using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Train.Models;
namespace Data.DTO
{
    public record UpdateItemDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1,1000)]
        public decimal Price { get; init; }
    }
}