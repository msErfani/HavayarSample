using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Queries
{
    public class GetAllAccountHandler : IRequestHandler<GetAllAccount,IEnumerable<GetAllAcoountDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public GetAllAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<GetAllAcoountDTO>> IRequestHandler<GetAllAccount, IEnumerable<GetAllAcoountDTO>>.Handle(GetAllAccount request, CancellationToken cancellationToken)
        {
         return _mapper.Map<IEnumerable<AppUser>,IEnumerable<GetAllAcoountDTO>>(await _accountRepository.GetAll());
        }
    }
}
