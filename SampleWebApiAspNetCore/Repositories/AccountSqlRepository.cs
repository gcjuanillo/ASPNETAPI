using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Repositories;
using WebApiAspNetCore.Entities;
using System.Linq.Dynamic.Core;
using SampleWebApiAspNetCore.Helpers;

namespace WebApiAspNetCore.Repositories
{
    public class AccountSqlRepository : IAccountRepository
    {
        private readonly AccountDbContext _accountDbContext;

        public AccountSqlRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }
        public IEnumerable<AccountEntity> GetAll()
        {
            return _accountDbContext.Account.ToList();
        }

        public AccountEntity GetSingle(int id)
        {
            return _accountDbContext.Account.FirstOrDefault(x => x.Id == id);
        }

        public void Add(AccountEntity account)
        {
            _accountDbContext.Account.Add(account);
        }

        public void Delete(int id)
        {
            AccountEntity account = GetSingle(id);
            _accountDbContext.Account.Remove(account);
        }

        public AccountEntity Update(int id, AccountEntity account)
        {
            _accountDbContext.Account.Update(account);
            return account;
        }

        public int Count()
        {
            return _accountDbContext.Account.Count();
        }

        public bool Save()
        {
            return (_accountDbContext.SaveChanges() >= 0);
        }
        
    }
}
