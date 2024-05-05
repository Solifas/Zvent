using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Zvent.Server.Domain.Entities;
using Amazon.DynamoDBv2.DocumentModel;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Infrastructure.Persistance.Repositories;

public class TicketDynamoDbRepository(IAmazonDynamoDB dynamoDB) : ITicketRepository
{
    private const string TableName = "Tickets";

    public async Task<Guid> CreateTicket(Ticket ticket)
    {
        var ticketDocument = Document.FromJson(JsonSerializer.Serialize(ticket));
        var request = new PutItemRequest
        {
            TableName = TableName,
            Item = ticketDocument.ToAttributeMap()
        };
        var response = await dynamoDB.PutItemAsync(request);
        if (response.HttpStatusCode is HttpStatusCode.OK)
        {
            return ticket.Id;
        }
        throw new Exception("Failed to create ticket");
    }

    public async Task DeleteTicket(Guid id)
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
            throw new Exception("Failed to delete ticket");
        }
    }

    public async Task<Ticket?> GetTicket(Guid id)
    {
        var request = new GetItemRequest
        {
            TableName = TableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { S = id.ToString() } }
            }
        };
        var response = await dynamoDB.GetItemAsync(request);
        if (response.HttpStatusCode is not HttpStatusCode.OK)
        {
            throw new Exception("Failed to get ticket");
        }
        if (response.Item is null)
        {
            return null;
        }
        return JsonSerializer.Deserialize<Ticket>(response.Item["Item"].S);
    }

    public async IAsyncEnumerable<Ticket> GetTickets(int page, int pageSize)
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
        if (response.Items is null)
        {
            yield break;
        }

        foreach (var item in response.Items)
        {
            var itemValue = item.TryGetValue("Item", out var attributeValue) ? attributeValue.S : null;
            if (itemValue is not null)
            {
                yield return JsonSerializer.Deserialize<Ticket>(itemValue);
            }
        }

    }

    public async Task<bool> UpdateTicket(Ticket ticket)
    {
        //update ticket logic
        var ticketDocument = Document.FromJson(JsonSerializer.Serialize(ticket));
        var request = new PutItemRequest
        {
            TableName = TableName,
            Item = ticketDocument.ToAttributeMap()
        };
        var response = await dynamoDB.PutItemAsync(request);
        return response.HttpStatusCode is HttpStatusCode.OK;
    }
}
