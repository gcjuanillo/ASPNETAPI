using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Repositories;
using WebApiAspNetCore.Entities;
using WebApiAspNetCore.Repositories;

namespace SampleWebApiAspNetCore.Services
{
    public class SeedDataService : ISeedDataService
    {
        public void Initialize(FoodDbContext context)
        {
            context.FoodItems.Add(new FoodEntity() { Calories = 1000, Type = "Starter", Name = "Lasagne", Created = DateTime.Now });
            context.FoodItems.Add(new FoodEntity() { Calories = 1100, Type = "Main", Name = "Hamburger", Created = DateTime.Now });
            context.FoodItems.Add(new FoodEntity() { Calories = 1200, Type = "Dessert", Name = "Spaghetti", Created = DateTime.Now });
            context.FoodItems.Add(new FoodEntity() { Calories = 1300, Type = "Starter", Name = "Pizza", Created = DateTime.Now });

            context.SaveChanges();
        }

        public void Initialize(AccountDbContext context)
        {
            context.Account.Add(new AccountEntity() { FName = "Juan", LName = "Dela Cruz", ContactNum = "09123456789", AccType = "Standard", IsSubscribed = false, AccCreated = DateTime.Now });
            context.Account.Add(new AccountEntity() { FName = "Adan", LName = "Cabildo", ContactNum = "09246810121", AccType = "Premium", IsSubscribed = true, AccCreated = DateTime.Now });
            context.Account.Add(new AccountEntity() { FName = "Jasper Daniel", LName = "Abogado", ContactNum = "09481216202", AccType = "Free", IsSubscribed = false, AccCreated = DateTime.Now });

            context.SaveChanges();
        }
    }
}
