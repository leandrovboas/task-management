using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;

namespace TaskManagement.UnitTest.Builders;

internal class WorkitemBuilder : BaseBuilder<WorkItems>
{
    private WorkItems _workItem;

    public override WorkItems BuildObject() => CreateWorkItem();

    private WorkItems CreateWorkItem() {
        _workItem = new(
           Faker.Lorem.Sentence(5),
                Faker.Lorem.Text(),
                Faker.PickRandom<WorkItemsPriority>(),
                Faker.Random.Guid(),
                Faker.Random.Guid()
                );
        return _workItem;
    }

}
