using AutoBogus;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TaskManagement.Application.UseCases;
using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Enums;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.UnitTest.Builders;

namespace TaskManagement.UnitTest.UserCase;

internal class UpdateWorkItemsUseCaseTest : BaseTest
{
    private WorkItemsRepository _workItemsRepository;
    private WorkItemsHistoryRepository _workItemsHistoryRepository;


    [SetUp]
    public void SetUp()
    {
        _workItemsRepository = new AutoFaker<WorkItemsRepository>();
        _workItemsHistoryRepository = new AutoFaker<WorkItemsHistoryRepository>();
    }

    [Test]
    public async Task ShouldReturnExpectedResult()
    {
        var updateWorkItemsRequest = new UpdateWorkitemBuilder().BuildObject();
        var updateWorkItemsUseCase = new UpdateWorkItemsUseCase(_workItemsRepository, _workItemsHistoryRepository);

        var result = await updateWorkItemsUseCase.ExecuteAsync(Guid.NewGuid(), updateWorkItemsRequest);
        result.Should().BeTrue();
    }

    [Test]
    public async Task ShouldReturnExpectedResultChangeState()
    {
        var updateWorkItemsRequest = new UpdateWorkitemBuilder().BuildObject();
        updateWorkItemsRequest.Status = WorkItemsStatus.Completed;
        var workItem = new WorkitemBuilder().BuildObject();
        workItem.ChangeStatus(WorkItemsStatus.Pending);

        var workItemsRepository = new Mock<IWorkItemsRepository>();
        workItemsRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(workItem);

        var updateWorkItemsUseCase = new UpdateWorkItemsUseCase(_workItemsRepository, _workItemsHistoryRepository);

        var result = await updateWorkItemsUseCase.ExecuteAsync(Guid.NewGuid(), updateWorkItemsRequest);
        result.Should().BeTrue();
    }

    [Test]
    public async Task ShouldReturnExpectedResultChangeDescription()
    {
        var updateWorkItemsRequest = new UpdateWorkitemBuilder().BuildObject();
        updateWorkItemsRequest.Description = "Teste 1";
        var workItem = new WorkitemBuilder().BuildObject();
        workItem.ChangeDescription("Teste 2");

        var workItemsRepository = new Mock<IWorkItemsRepository>();
        workItemsRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(workItem);

        var updateWorkItemsUseCase = new UpdateWorkItemsUseCase(_workItemsRepository, _workItemsHistoryRepository);

        var result = await updateWorkItemsUseCase.ExecuteAsync(Guid.NewGuid(), updateWorkItemsRequest);
        result.Should().BeTrue();
    }

    [Test]
    public async Task ShouldReturnExpectedResultChangeTitle()
    {
        var updateWorkItemsRequest = new UpdateWorkitemBuilder().BuildObject();
        updateWorkItemsRequest.Title = "Title 1";
        var workItem = new WorkitemBuilder().BuildObject();
        workItem.ChangeTitle("Title 2");

        var workItemsRepository = new Mock<IWorkItemsRepository>();
        workItemsRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(workItem);

        var updateWorkItemsUseCase = new UpdateWorkItemsUseCase(_workItemsRepository, _workItemsHistoryRepository);

        var result = await updateWorkItemsUseCase.ExecuteAsync(Guid.NewGuid(), updateWorkItemsRequest);
        result.Should().BeTrue();
    }

    [Test]
    public async Task ShouldThrowAnExceptionWhenWorkItemNotFound()
    {
        var updateWorkItemsRequest = new UpdateWorkitemBuilder().BuildObject();

        var workItemsRepository = new Mock<IWorkItemsRepository>();
        workItemsRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(() => null);

        var updateWorkItemsUseCase = new UpdateWorkItemsUseCase(workItemsRepository.Object, _workItemsHistoryRepository);

        Func<Task> act = async () => await updateWorkItemsUseCase.ExecuteAsync(Guid.NewGuid(), updateWorkItemsRequest);
        await act.Should().ThrowAsync<WorkItemException>()
            .WithMessage($"Tarefa não encontrada.");
    }
}
