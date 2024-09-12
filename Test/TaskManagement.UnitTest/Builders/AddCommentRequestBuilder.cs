using Bogus;
using TaskManagement.Application.DTOs;

namespace TaskManagement.UnitTest.Builders;

internal class AddCommentRequestBuilder : BaseBuilder<AddCommentRequest>
{
    public override AddCommentRequest BuildObject() => CreateWorkItem();

    private AddCommentRequest CreateWorkItem()=> 
         new AddCommentRequest { 
            Content = Faker.Lorem.Sentence(), 
            CreatedBy = Faker.Random.Guid(), 
            WorkItemsId = Faker.Random.Guid() };
    
}