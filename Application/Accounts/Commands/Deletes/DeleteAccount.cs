using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Application.Accounts.Commands.Deletes
{
    public class DeleteAccount : IRequest<bool>
    {
        [Required]
        public string Id { get; set; }
    }
}
