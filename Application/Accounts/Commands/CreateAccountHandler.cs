using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Commands
{
    public class CreateAccountHandler : IRequestHandler<CreateAccount, bool>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<AppUser> _userManager;

        public CreateAccountHandler(IAccountRepository accountRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        async Task<bool> IRequestHandler<CreateAccount, bool>.Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<CreateAccount, AppUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
                return true;

            return false;
        }
    }
}
