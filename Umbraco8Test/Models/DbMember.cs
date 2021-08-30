using System;
using System.ComponentModel.DataAnnotations;

namespace Umbraco8Test.Models
{
    public class DbMember
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
    }
}