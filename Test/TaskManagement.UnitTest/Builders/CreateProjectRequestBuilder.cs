using AutoBogus;
using TaskManagement.API.DTOs;
using TaskManagement.Core.Entities;

namespace TaskManagement.UnitTest.Builders;

internal class CreateProjectRequestBuilder : BaseBuilder<CreateProjectRequest>
{
    private List<WorkItems> _workItems = [];
    private WorkitemBuilder _workitemBuilder;

    public override CreateProjectRequest BuildObject() => CreateObject();
    private CreateProjectRequest CreateObject()
    {
        if (_workItems.Count >= 0)
        {
            _workitemBuilder = new WorkitemBuilder();
            _workItems.Add(_workitemBuilder.BuildObject());
        }

        var createProjectRequest = new AutoFaker<CreateProjectRequest>()
            .RuleFor(x => x.Name, Faker.Random.Word)
            .RuleFor(x => x.UserId, Faker.Random.Guid)
            .RuleFor(x => x.WorkItems, _workItems)
            .Generate();

        return createProjectRequest;
    }

    public CreateProjectRequestBuilder WithWorkItems(List<WorkItems> workItems)
    {
        _workItems = workItems;
        return this;
    }
}
