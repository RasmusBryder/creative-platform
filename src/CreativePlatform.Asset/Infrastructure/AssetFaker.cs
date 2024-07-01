using Bogus;
using CreativePlatform.Asset.Domain;

namespace CreativePlatform.Asset.Infrastructure;

internal sealed class AssetFaker : Faker<Domain.AssetResource>
{
    public AssetFaker()
    {
        var faker = new Faker();
        var idSuffix = faker.Random.Number(0, 99).ToString().PadLeft(2, '0');
        var extension = faker.System.CommonFileExt();

        RuleFor(a => a.AssetId, _ => $"ASSET0{idSuffix}");
        RuleFor(a => a.Name, a => a.Commerce.ProductName());
        RuleFor(a => a.Description, a => a.Commerce.ProductDescription());
        RuleFor(a => a.FileFormat, _ => "ToBeDefined");
        RuleFor(a => a.FileSize, _ => "ToBeDefined");
        RuleFor(a => a.Path, _ => $"/path/to/asset0{idSuffix}.{extension}");
        RuleFor(a => a.CreatedBy, a => a.Person.FullName);
        RuleFor(a => a.VersionNumber, _ => "1.0");
        RuleFor(a => a.Timestamp, _ => DateTimeOffset.UtcNow);
        RuleFor(a => a.UserName, a => a.Internet.UserName());
        RuleFor(a => a.Comments, a => a.Lorem.Sentence(5));
        RuleFor(a => a.Preview, _ => $"/path/to/preview/asset0{idSuffix}_preview.{extension}");
        RuleFor(a => a.Status, a => new[] { AssetStatus.Pending, AssetStatus.Approved }[a.Random.Number()]);
    }
}