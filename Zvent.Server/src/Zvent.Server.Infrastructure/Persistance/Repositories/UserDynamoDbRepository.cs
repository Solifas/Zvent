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
    private const string TableName = "Users";
    public async Task<bool> CreateUser(User user)
    {
        var userDocument = Document.FromJson(JsonSerializer.Serialize(user));
        var request = new PutItemRequest
        {
            TableName = TableName,
            Item = userDocument.ToAttributeMap()
        };

        var response = await dynamoDB.PutItemAsync(request);

        return response.HttpStatusCode is HttpStatusCode.OK;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var request = new DeleteItemRequest
        {
            TableName = TableName,
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

    public async Task<User?> GetUser(string userName)
    {
        var request = new GetItemRequest
        {
            TableName = TableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "userName", new AttributeValue { S = userName } }
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

    public async Task<IEnumerable<User>> GetUsers(int page, int pageSize)
    {
        var request = new QueryRequest
        {
            TableName = TableName,
            Limit = pageSize,
            ExclusiveStartKey = null
        };

        var response = await dynamoDB.QueryAsync(request);

        if (response.HttpStatusCode is not HttpStatusCode.OK)
        {
            throw new Exception("Failed to get tickets");
        }
        var users = new List<User>();
        if (response.Items is null)
        {
            return users;
        }

        foreach (var item in response.Items)
        {
            var userDocument = Document.FromAttributeMap(item);
            users.Add(JsonSerializer.Deserialize<User>(userDocument.ToJson()));
        }
        return users;
    }

    public async Task<bool> UpdateUser(User user)
    {
        var userDocument = Document.FromJson(JsonSerializer.Serialize(user));

        var request = new UpdateItemRequest
        {
            TableName = TableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { S = user.Id.ToString() } }
            },
            ExpressionAttributeValues = userDocument.ToAttributeMap(),
            UpdateExpression = "SET #userName = :userName, #password = :password, #email = :email",
            ExpressionAttributeNames = new Dictionary<string, string>
            {
                { "#userName", "userName" },
                { "#password", "password" },
                { "#email", "email" }
            },
            ReturnValues = ReturnValue.ALL_NEW
        };

        var response = await dynamoDB.UpdateItemAsync(request);

        return response.HttpStatusCode is HttpStatusCode.OK;
    }
}
