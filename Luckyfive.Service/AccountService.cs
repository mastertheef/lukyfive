using Luckyfive.DataAccess.Repositories;
using Luckyfive.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepo;

        public AccountService(IAccountRepository accountRepo)
        {
            this.accountRepo = accountRepo;
        }

        public async Task<bool> IsEmailUsed(string email)
        {
            return await Task.Run(() => { return this.accountRepo.GetAll().Any(x => x.Email == email); });
        }
    }
}
