using AutoBogus;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TaskManagement.Application.UseCases;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.UnitTest.Builders;

namespace TaskManagement.UnitTest.UserCase;

internal class DeleteWorkItemUseCaseTest : BaseTest
{
    private WorkItemsRepository _workItemsRepository;


    [SetUp]
    public void SetUp()
    {
        _workItemsRepository = new AutoFaker<WorkItemsRepository>();
    }

        [Test]
    public async Task ShouldReturnExpectedResult()
    {
        var deleteWorkItemUseCase   = new DeleteWorkItemUseCase(_workItemsRepository);

        var result = await deleteWorkItemUseCase.ExecuteAsync(Guid.NewGuid());
        result.Should().BeTrue();
    }

    [Test]
    public async Task ShouldThrowAnExceptionWhenWorkItemNotFound()
    {
        var workItemsRequest = new AddWorkItemsRequestBuilder().BuildObject();
        var id = Guid.NewGuid();

        var workItemsRepository = new Mock<IWorkItemsRepository>();
        workItemsRepository
            .Setup(x => x.GetByIdAsync(id))
            .ReturnsAsync(() => null);


        var addWorkItemsUseCase = new DeleteWorkItemUseCase(workItemsRepository.Object);

        Func<Task> act = async () => await addWorkItemsUseCase.ExecuteAsync(id);
        await act.Should().ThrowAsync<WorkItemException>()
            .WithMessage($"tarefa não encontrado com o id {id}");
    }
}
