using AutoBogus;
using FluentAssertions;
using NUnit.Framework;
using TaskManagement.API.DTOs;
using TaskManagement.Application.UseCases;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Exceptions;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.UnitTest.Builders;

namespace TaskManagement.UnitTest.UserCase;

public class CreateProjectUseCaseTest : BaseTest
{
    private CreateProjectRequest _createProjectRequest;
    private CreateProjectUseCase _createProjectUseCase;
    private ProjectRepository _projectRepository;

    [SetUp]
    public void SetUp()
    {
        _createProjectRequest = new CreateProjectRequestBuilder().BuildObject();

        _projectRepository = new AutoFaker<ProjectRepository>();
        _createProjectUseCase = new CreateProjectUseCase(_projectRepository);
    }

    [Test]
    public void ShouldReturnExpectedResult()
    {
        var result = _createProjectUseCase.ExecuteAsync(_createProjectRequest);
        result.Should().BeOfType<Task<Guid>>();
    }

    [Test]
    public async Task ShouldThrowAnExceptionWhenHavingMoreThanTwentyWorkItems()
    {
        List<WorkItems> _workItems = CreateWorkItemList(21);
        var createProjectRequest = new CreateProjectRequestBuilder().WithWorkItems(_workItems).BuildObject();

        Func<Task> act = async () => await _createProjectUseCase.ExecuteAsync(createProjectRequest);
        await act.Should().ThrowAsync<MaxWorkItemException>()
            .WithMessage("O limite máximo de itens para este projeto foi excedido");
    }

    private List<WorkItems> CreateWorkItemList(int qtd)
    {
        List<WorkItems> _workItems = [];
        for (int i = 0; i < qtd; i++)
        {
            _workItems.Add(new WorkitemBuilder().BuildObject());
        }
        return _workItems;
    }
}
