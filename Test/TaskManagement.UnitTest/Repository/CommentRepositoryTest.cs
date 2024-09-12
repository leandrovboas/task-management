using FluentAssertions;
using NUnit.Framework;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.UnitTest.Builders;

namespace TaskManagement.UnitTest.Repository;

internal class CommentRepositoryTest : BaseTest
{
    [Test]
    public async Task ShouldReturnExpectedResult()
    {
        var comment = new CommentBuilder().BuildObject();
        var updateWorkItemsUseCase = new CommentRepository();

        var result = await updateWorkItemsUseCase.AddCommentAsync(comment);
        result.Should().BeTrue();
    }
}
