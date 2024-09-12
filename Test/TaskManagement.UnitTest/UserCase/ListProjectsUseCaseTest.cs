using FluentAssertions;
using Moq;
using NUnit.Framework;
using TaskManagement.Application.UseCases;
using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Repositories;
using TaskManagement.UnitTest.Builders;

namespace TaskManagement.UnitTest.UserCase;

public class ListProjectsUseCaseTest : BaseTest
{
    private IListProjetcsUseCase _listProjetcsUseCase;

    [Test]
    public async Task ShouldReturnExpectedResult()
    {
        var projects = new List<Project>
        {
            new ProjectBuilder().BuildObject(),
            new ProjectBuilder().BuildObject(),
            new ProjectBuilder().BuildObject()
        };

        var _projectRepository = new Mock<IProjectRepository>();
        _projectRepository
            .Setup(x => x.GetAllByUserIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(projects);

        _listProjetcsUseCase = new ListProjectsUseCase(_projectRepository.Object);

        var result = await _listProjetcsUseCase.ExecuteAsync(Guid.NewGuid());
        var validateResult = Compare<List<Project>>(projects, result.ToList());
        validateResult.Should().BeTrue();
    }

    [Test]
    public async Task ShouldReturnExpectedResultToNotFoundProjects()
    {

        var _projectRepository = new Mock<IProjectRepository>();
        _projectRepository
            .Setup(x => x.GetAllByUserIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync([]);

        _listProjetcsUseCase = new ListProjectsUseCase(_projectRepository.Object);

        var result = await _listProjetcsUseCase.ExecuteAsync(Guid.NewGuid());
        var validateResult = Compare<List<Project>>([], result.ToList());
        validateResult.Should().BeTrue();
    }
}
