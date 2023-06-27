using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Commands.Deletes
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccount, bool>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<AppUser> _userManager;

        public DeleteAccountHandler(IAccountRepository accountRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        async Task<bool> IRequestHandler<DeleteAccount, bool>.Handle(DeleteAccount request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.Id);

            await _accountRepository.Delete(user);
            await _accountRepository.Save();
            return true;
        }
    }
}
