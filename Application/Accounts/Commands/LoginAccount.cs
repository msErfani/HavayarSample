using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Accounts.Commands
{
    public class LoginAccount : IRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
        public bool RememberMe { get; set; } = false;
    }
}
