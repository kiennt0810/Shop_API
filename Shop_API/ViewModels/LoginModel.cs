﻿using System.ComponentModel.DataAnnotations;

namespace Shop_API.ViewModels
{
    public class LoginModel
    {
        [Required]
        [MaxLength(50)]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Password { get; set; }
    }
}
