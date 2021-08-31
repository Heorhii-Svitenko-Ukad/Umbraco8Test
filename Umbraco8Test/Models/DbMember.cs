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
        [Required]
        public DateTime Created { get; set; }
        public string FacebookId { get; set; }
        public bool EmailVerified { get; set; }
        public int Level { get; set; }
        public bool NotificationDonations { get; set; }
        public bool NotificationGroups { get; set; }
        public bool NotificationNews { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
    }
}