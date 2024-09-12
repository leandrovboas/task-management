using FluentAssertions;
using Moq;
using NUnit.Framework;
using TaskManagement.Application.UseCases;
using TaskManagement.Application.UseCases.Interfaces;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Enums;
using TaskManagement.Core.Exceptions;
using TaskManagement.Core.Repositories;
using TaskManagement.UnitTest.Builders;

namespace TaskManagement.UnitTest.UserCase;

public class DeleteProjectUseCaseTest : BaseTest
{
    private IProjectRepository _projectRepository;
    private IDeleteProjectsUseCase _deleteProjectsUseCase;


    [Test]
    public async Task ShouldReturnExpectedResult()
    {
        var project = new ProjectBuilder().BuildObject();
        project.WorkItems[0].ChangeStatus(WorkItemsStatus.Completed);

        var _projectRepository = new Mock<IProjectRepository>();
        _projectRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(project);

        _projectRepository.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

        _deleteProjectsUseCase = new DeleteProjectsUseCase(_projectRepository.Object);

        var result = await _deleteProjectsUseCase.ExecuteAsync(Guid.NewGuid());
        result.Should().BeTrue();
    }

    [Test]
    public async Task ShouldReturnProjectExceptionWhenWorkItemStatusIsInProgress()
    {
        List<WorkItems> _workItems = [];

        var project = new ProjectBuilder().BuildObject();
        project.WorkItems[0].ChangeStatus(WorkItemsStatus.InProgress);

        var _projectRepository = new Mock<IProjectRepository>();
        _projectRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(project);

        _projectRepository.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

        _deleteProjectsUseCase = new DeleteProjectsUseCase(_projectRepository.Object);


        Func<Task> act = async () => await _deleteProjectsUseCase.ExecuteAsync(Guid.NewGuid());
        await act.Should().ThrowAsync<ProjectException>()
            .WithMessage("Este projeto tem tarefas inacabadas. Para removê-lo, essas tarefas devem ser concluídas ou removidas.");

    }

    [Test]
    public async Task ShouldReturnProjectExceptionWhenWorkItemStatusIsPending()
    {
        List<WorkItems> _workItems = [];

        var project = new ProjectBuilder().BuildObject();
        project.WorkItems[0].ChangeStatus(WorkItemsStatus.Pending);

        var _projectRepository = new Mock<IProjectRepository>();
        _projectRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(project);

        _projectRepository.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

        _deleteProjectsUseCase = new DeleteProjectsUseCase(_projectRepository.Object);


        Func<Task> act = async () => await _deleteProjectsUseCase.ExecuteAsync(Guid.NewGuid());
        await act.Should().ThrowAsync<ProjectException>()
            .WithMessage("Este projeto tem tarefas inacabadas. Para removê-lo, essas tarefas devem ser concluídas ou removidas.");

    }

    [Test]
    public async Task ShouldReturnProjectExceptionWhenProjectNotFound()
    {
        var projectId = Guid.NewGuid();
        var _projectRepository = new Mock<IProjectRepository>();

        _projectRepository
            .Setup(x => x.GetByIdAsync(projectId))
            .ReturnsAsync(() => null);

        _projectRepository.Setup(x => x.DeleteAsync(projectId)).ReturnsAsync(true);

        _deleteProjectsUseCase = new DeleteProjectsUseCase(_projectRepository.Object);


        Func<Task> act = async () => await _deleteProjectsUseCase.ExecuteAsync(projectId);
        await act.Should().ThrowAsync<ProjectException>()
            .WithMessage($"Projeto não encontrado com o id {projectId} ");

    }
}
