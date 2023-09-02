using SampleWebApiAspNetCore.Repositories;
using WebApiAspNetCore.Repositories;

namespace SampleWebApiAspNetCore.Services
{
    public interface ISeedDataService
    {
        void Initialize(AccountDbContext context);
    }
}
