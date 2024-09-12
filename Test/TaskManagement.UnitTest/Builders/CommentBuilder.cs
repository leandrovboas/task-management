using Bogus;
using TaskManagement.Core.Entities;

namespace TaskManagement.UnitTest.Builders;

internal class CommentBuilder : BaseBuilder<Comment>
{
    public override Comment BuildObject() => CreateWorkItem();

    private Comment CreateWorkItem() =>
         new(Faker.Lorem.Sentence(), Faker.Random.Guid(), Faker.Random.Guid());
    
}