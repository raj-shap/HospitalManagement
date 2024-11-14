using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models.Users
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyy")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PassowordHash { get; set; }
        [Required]
        public string ConfirmPassowordHash { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime LastLogOn { get; set; }
        public string Role {  get; set; }
    }
}
