﻿using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class UserLoginRequest
    {
        [Required, EmailAddress] public string Email { get; set; } = String.Empty;
        [Required] public string Password { get; set; } = String.Empty;
    }
}