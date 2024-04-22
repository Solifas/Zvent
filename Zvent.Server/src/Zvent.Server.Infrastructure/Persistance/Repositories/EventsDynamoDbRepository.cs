using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Zvent.Server.Domain.Entities;
using Amazon.DynamoDBv2.DocumentModel;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Infrastructure.Persistance.Repositories;

public class EventsDynamoDbRepository(IAmazonDynamoDB dynamoDB) : IEventsRepository
{
    public async Task<bool> CreateEvent(Event @event)
    {
        var eventDocument = Document.FromJson(JsonSerializer.Serialize(@event));
        var request = new PutItemRequest
        {
            TableName = "Events",
            Item = eventDocument.ToAttributeMap()
        };
        var response = await dynamoDB.PutItemAsync(request);
        return response.HttpStatusCode is HttpStatusCode.OK;

    }

    public async Task DeleteEvent(Guid id)
    {
        var request = new DeleteItemRequest
        {
            TableName = "Events",
            Key = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { S = id.ToString() } }
            }
        };
        var response = await dynamoDB.DeleteItemAsync(request);
        if (response.HttpStatusCode is not HttpStatusCode.OK)
        {
            throw new Exception("Failed to delete event");
        }
    }

    public async Task<Event?> GetEvent(Guid id)
    {
        var request = new GetItemRequest
        {
            TableName = "Events",
            Key = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { S = id.ToString() } }
            }
        };
        var response = await dynamoDB.GetItemAsync(request);
        if (response.HttpStatusCode is not HttpStatusCode.OK)
        {
            throw new Exception("Failed to get event");
        }
        if (response.Item is null)
        {
            return null;
        }
        return JsonSerializer.Deserialize<Event>(response.Item["Item"].S);
    }

    public async IAsyncEnumerable<Event> GetEvents(int page, int pageSize)
    {
        // var request = new QueryRequest
        // {
        //     TableName = "Events",
        //     Limit = pageSize,
        //     KeyConditionExpression = "id = :v_id",
        //     ExpressionAttributeValues = new Dictionary<string, AttributeValue> { { ":v_id", new AttributeValue { N = "123" } } }, // replace with your actual primary key value
        // };

        // var response = await dynamoDB.QueryAsync(request);

        // foreach (var item in response.Items)
        // {
        //     yield return JsonSerializer.Deserialize<Event>(item["Item"].S);
        // }
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateEvent(Event @event)
    {
        var eventDocument = Document.FromJson(JsonSerializer.Serialize(@event));
        var request = new PutItemRequest
        {
            TableName = "Events",
            Item = eventDocument.ToAttributeMap()
        };
        var response = await dynamoDB.PutItemAsync(request);
        return response.HttpStatusCode is HttpStatusCode.OK;
    }
}
