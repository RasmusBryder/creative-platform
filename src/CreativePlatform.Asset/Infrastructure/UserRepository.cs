using Bogus;

namespace CreativePlatform.Asset.Infrastructure;

internal interface IUserRepository
{
    string GetFullName(string username);
}

internal class UserRepository : IUserRepository
{
    private static readonly Faker Faker = new();
    public string GetFullName(string username)
    {
        return Faker.Name.FullName();
    }
}