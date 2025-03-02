﻿using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class ProductDetails
    {
        
            [Key]
            public int Id { get; set; }
        [Required]
        
            public int Products_Id { get; set; }
        [Required]
            public string? Images { get; set; }
        [Required]
            public double Price { get; set; }
            [Required]
            public int Qty { get; set; }
        [Required]
            public string? Color { get; set; }
        }
    }
