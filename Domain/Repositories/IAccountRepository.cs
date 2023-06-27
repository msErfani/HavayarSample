using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository : IDisposable
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser> Get(int id);

        Task Add(AppUser model);
        Task Update(AppUser model);
        Task Delete(AppUser model);

        Task<bool> Save();

    }
}
