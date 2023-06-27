using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Job
{
    [DisallowConcurrentExecution]
    public class SomeJob : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            var option = new DbContextOptionsBuilder<AppDbContext>();
            option.UseSqlServer(@"Server = .; Database=HavayarDB;Integrated Security=true");

            using (AppDbContext _ctx = new AppDbContext(option.Options))
            {
                // .... operation 
            }
            return Task.CompletedTask;
        }
    }
}
