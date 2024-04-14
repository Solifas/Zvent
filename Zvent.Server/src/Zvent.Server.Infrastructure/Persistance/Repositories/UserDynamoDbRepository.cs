using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Infrastructure.Persistance.Repositories;

public class UserDynamoDbRepository(IAmazonDynamoDB dynamoDB) : IUserRepository
{
    public async Task<bool> CreateUser(User user)
    {
        var userDocument = Document.FromJson(JsonSerializer.Serialize(user));
        var request = new PutItemRequest
        {
            TableName = "Users",
            Item = userDocument.ToAttributeMap()
        };

        var response = await dynamoDB.PutItemAsync(request);

        return response.HttpStatusCode is HttpStatusCode.OK;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var request = new DeleteItemRequest
        {
            TableName = "Users",
            Key = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { S = id.ToString() } }
            }
        };

        var response = await dynamoDB.DeleteItemAsync(request);

        if (response.HttpStatusCode is not HttpStatusCode.OK)
        {
            throw new Exception("Failed to delete user");
        }

        return true;
    }

    public async Task<User?> GetUser(Guid id)
    {
        var request = new GetItemRequest
        {
            TableName = "Users",
            Key = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { S = id.ToString() } }
            }
        };

        var response = await dynamoDB.GetItemAsync(request);

        if (response.HttpStatusCode is not HttpStatusCode.OK)
        {
            return null;
        }

        if (response.Item.Count <= 0)
        {
            return null;
        }

        var userDocument = Document.FromAttributeMap(response.Item);
        return JsonSerializer.Deserialize<User>(userDocument.ToJson());
    }

    public IAsyncEnumerable<User> GetUsers(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}
