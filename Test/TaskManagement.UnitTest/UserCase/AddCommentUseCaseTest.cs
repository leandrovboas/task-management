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

public class AddCommentUseCaseTest : BaseTest
{
    private WorkItemsRepository _workItemsRepository;
    private CommentRepository _commentRepository;
    private WorkItemsHistoryRepository _workItemsHistoryRepository;


    [SetUp]
    public void SetUp()
    {
        _commentRepository = new AutoFaker<CommentRepository>();
        _workItemsRepository = new AutoFaker<WorkItemsRepository>();
        _workItemsHistoryRepository = new AutoFaker<WorkItemsHistoryRepository>();
    }

    [Test]
    public void ShouldReturnExpectedResult()
    {
        var commentRequest = new AddCommentRequestBuilder().BuildObject();
        var workItem = new WorkitemBuilder().BuildObject();

        var workItemsRepository = new Mock<IWorkItemsRepository>();
        workItemsRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(workItem);

        var commentRepository = new Mock<ICommentRepository>();
        commentRepository
            .Setup(x => x.AddCommentAsync(It.IsAny<Comment>()))
            .ReturnsAsync(() => true);

        var _addCommentUseCase = new AddCommentUseCase(workItemsRepository.Object, commentRepository.Object, _workItemsHistoryRepository);

        var result =  _addCommentUseCase.ExecuteAsync(commentRequest);
        result.Should().BeOfType<Task<Guid>>();
    }

    [Test]
    public async Task ShouldThrowAnExceptionWhenWorkItemNotFound()
    {
        var commentRequest = new AddCommentRequestBuilder().BuildObject();

        var workItemsRepository = new Mock<IWorkItemsRepository>();
        workItemsRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(() => null);


        var _addCommentUseCase = new AddCommentUseCase(workItemsRepository.Object, _commentRepository, _workItemsHistoryRepository);

        Func<Task> act = async () => await _addCommentUseCase.ExecuteAsync(commentRequest);
            await act.Should().ThrowAsync<WorkItemException>()
                .WithMessage($"Não foi encontrado nenhum tarefa com o id {commentRequest.WorkItemsId}.");
    }

    [Test]
    public async Task ShouldThrowAnExceptionWhenNotAbleToCreateComment()
    {
        var commentRequest = new AddCommentRequestBuilder().BuildObject();
        var workItem = new WorkitemBuilder().BuildObject();

        var workItemsRepository = new Mock<IWorkItemsRepository>();
        workItemsRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(workItem);

        var commentRepository = new Mock<ICommentRepository>();
        commentRepository
            .Setup(x => x.AddCommentAsync(It.IsAny<Comment>()))
            .ReturnsAsync(() => false);

        var _addCommentUseCase = new AddCommentUseCase(workItemsRepository.Object, commentRepository.Object, _workItemsHistoryRepository);

        Func<Task> act = async () => await _addCommentUseCase.ExecuteAsync(commentRequest);
        await act.Should().ThrowAsync<WorkItemException>()
            .WithMessage($"Não foi possível inclir ol comentário na tarefa com id {commentRequest.WorkItemsId}.");
    }
}
