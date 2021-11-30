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
        [StringLength(80, ErrorMessage = "Va�e heslo mus� b�t dlouh� {2} a� {1} znak�", MinimumLength = 6)]
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