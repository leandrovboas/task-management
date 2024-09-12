using Bogus;
using TaskManagement.Core.Entities;

namespace TaskManagement.UnitTest.Builders;

internal class ProjectBuilder : BaseBuilder<Project>
{
    private List<WorkItems> _workItems = [];
    private WorkitemBuilder _workitemBuilder;

    public override Project BuildObject() => CreateProject();

    private Project CreateProject()
    {
        if (_workItems.Count >= 0)
        {
            _workitemBuilder = new WorkitemBuilder();
            _workItems.Add(_workitemBuilder.BuildObject());
        }

        Project project = new(Faker.Random.Word(), _workItems, Faker.Random.Guid());
        return project;
    }

    internal ProjectBuilder WithWorkItems (List<WorkItems> workItems)
    {
        _workItems = workItems;
        return this;
    }
}
