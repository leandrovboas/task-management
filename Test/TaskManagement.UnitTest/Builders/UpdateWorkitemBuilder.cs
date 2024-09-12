using TaskManagement.API.DTOs;
using TaskManagement.Core.Enums;

namespace TaskManagement.UnitTest.Builders;

internal class UpdateWorkitemBuilder : BaseBuilder<UpdateWorkItemsRequest>
{
    public override UpdateWorkItemsRequest BuildObject() => CreateWorkItem();

    private UpdateWorkItemsRequest CreateWorkItem() => new()
    {
        Title = Faker.Lorem.Sentence(5),
        Description = Faker.Lorem.Text(),
        Status = Faker.PickRandom<WorkItemsStatus>(),
        UpdatedBy = Faker.Random.Guid()
    };

}