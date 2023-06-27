using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Accounts.Queries
{
    public class GetAllAccount : IRequest<IEnumerable<GetAllAcoountDTO>>
    {
    }
}
