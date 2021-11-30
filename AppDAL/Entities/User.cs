using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using AppEntities.Enums;

namespace AppEntities.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(80, ErrorMessage = "Vaše heslo musí být dlouhé {2} až {1} znakù", MinimumLength = 6)]
        public string PasswordHash { get; set; }

        public Roles Role { get; set; }

        //relationships
        
        // 1:1
        public Guid? ParticipantId { get; set; }
        public Participant Participant { get; set; }
        // 1:1
        public Guid? LeaderId { get; set; }
        public Leader Leader { get; set; }
    }
}