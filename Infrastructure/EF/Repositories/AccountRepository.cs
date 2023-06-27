using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task Add(AppUser model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(AppUser model)
        {
            model.IsDeleted = true;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<AppUser> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> Save()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public Task Update(AppUser model)
        {
            throw new NotImplementedException();
        }
    }
}
