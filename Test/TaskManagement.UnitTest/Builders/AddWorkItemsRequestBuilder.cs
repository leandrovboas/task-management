using TaskManagement.API.DTOs;
using TaskManagement.Core.Enums;

namespace TaskManagement.UnitTest.Builders;

internal class AddWorkItemsRequestBuilder : BaseBuilder<AddWorkItemsRequest>
{
    public override AddWorkItemsRequest BuildObject() => CreateWorkItem();

    private AddWorkItemsRequest CreateWorkItem() =>
         new AddWorkItemsRequest {
             Title = Faker.Lorem.Sentence(5),
             Description = Faker.Lorem.Text(),
             Priority =  Faker.PickRandom<WorkItemsPriority>(),
             ProjectId = Faker.Random.Guid(),
             CreatedBy = Faker.Random.Guid()
                };

}
