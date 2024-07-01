using Bogus;
using CreativePlatform.Order.Domain;

namespace CreativePlatform.Order.Infrastructure;

internal sealed class BriefFaker : Faker<BriefResource>
{
    public BriefFaker()
    {
        CustomInstantiator(x => new BriefResource(x.Commerce.ProductName()));
        RuleFor(x => x.BriefId, x => $"BRIEF0{x.Random.Number(1, 99).ToString().PadLeft(2, '0')}");
        RuleFor(x => x.Quantity, x => x.Random.WeightedRandom([1, 2, 3], [0.75f, 0.15f, 0.1f]));
        RuleFor(x => x.Description, x => x.Commerce.ProductDescription());
        RuleFor(x => x.CreatedDate, _ => DateTime.Now.Date);
        RuleFor(x => x.CreatedBy, x => x.Person.FullName);
        RuleFor(x => x.Status, _ => BriefStatus.Released);
    }
}