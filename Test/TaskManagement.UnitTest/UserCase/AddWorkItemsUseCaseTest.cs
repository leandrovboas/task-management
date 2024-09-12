using AutoBogus;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TaskManagement.Application.UseCases;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.UnitTest.Builders;

namespace TaskManagement.UnitTest.UserCase;

public class AddWorkItemsUseCaseTest : BaseTest
{
    private ProjectRepository _projectRepository;
    private WorkItemsRepository _workItemsRepository;


    [SetUp]
    public void SetUp()
    {
        _projectRepository = new AutoFaker<ProjectRepository>();
        _workItemsRepository = new AutoFaker<WorkItemsRepository>();
    }

    [Test]
    public void ShouldReturnExpectedResult()
    {
        var workItemsRequest = new AddWorkItemsRequestBuilder().BuildObject();

        var addWorkItemsUseCase = new AddWorkItemsUseCase(_workItemsRepository, _projectRepository);

        var result = addWorkItemsUseCase.ExecuteAsync(workItemsRequest);
        result.Should().BeOfType<Task<Guid>>();
    }

    [Test]
    public async Task ShouldThrowAnExceptionWhenProjectNotFound()
    {
        var workItemsRequest = new AddWorkItemsRequestBuilder().BuildObject();

        var projectRepository = new Mock<IProjectRepository>();
        projectRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(() => null);


        var addWorkItemsUseCase = new AddWorkItemsUseCase(_workItemsRepository, projectRepository.Object);

        Func<Task> act = async () => await addWorkItemsUseCase.ExecuteAsync(workItemsRequest);
            await act.Should().ThrowAsync<ProjectException>()
                .WithMessage($"Projeto com o id {workItemsRequest.ProjectId} não foi encontrado.");
    }

    [Test]
    public async Task ShouldThrowAnExceptionWhenMaxWorkItemInProject()
    {
        var workItemsRequest = new AddWorkItemsRequestBuilder().BuildObject();
        List<WorkItems> _workItems = CreateWorkItemList(20);
        var projectBuilder = new ProjectBuilder().WithWorkItems(_workItems).BuildObject();

        var projectRepository = new Mock<IProjectRepository>();
        projectRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(projectBuilder);


        var addWorkItemsUseCase = new AddWorkItemsUseCase(_workItemsRepository, projectRepository.Object);

        Func<Task> act = async () => await addWorkItemsUseCase.ExecuteAsync(workItemsRequest);
        await act.Should().ThrowAsync<MaxWorkItemException>()
            .WithMessage("Não é possível adicionar mais de 20 tarefas a um projeto.");
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
