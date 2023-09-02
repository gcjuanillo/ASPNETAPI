using WebApiAspNetCore.Entities;

namespace WebApiAspNetCore.Repositories
{
    public interface IAccountRepository
    {
        AccountEntity GetSingle(int id);

        void Add(AccountEntity account);
        void Delete(int id);
        AccountEntity Update(int id, AccountEntity account);
        IEnumerable<AccountEntity> GetAll();
        int Count();
        bool Save();
    }
}
