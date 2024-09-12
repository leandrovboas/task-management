using AutoBogus;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TaskManagement.Application.UseCases;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Repositories;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.UnitTest.Builders;

namespace TaskManagement.UnitTest.UserCase;

internal class ListWorkItemsUseCaseTest : BaseTest
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
        var listWorkItems = CreateWorkItemList(2);

        var workItemsRepository = new Mock<IWorkItemsRepository>();
        workItemsRepository
            .Setup(x => x.GetAllByProjectIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(listWorkItems);

        var listWorkItemsUseCase = new ListWorkItemsUseCase(workItemsRepository.Object);

        var result = await listWorkItemsUseCase.ExecuteAsync(Guid.NewGuid());
        var validateResult = Compare<List<WorkItems>>(listWorkItems, result.ToList());
        validateResult.Should().BeTrue();
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
