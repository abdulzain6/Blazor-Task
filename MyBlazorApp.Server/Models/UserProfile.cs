using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Server.Models
{
    public class UserProfile
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Bio { get; set; }
    }
}
