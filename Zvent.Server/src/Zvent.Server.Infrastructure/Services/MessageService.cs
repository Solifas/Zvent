using Zvent.Server.Usecase.Persistance.Services;

namespace Zvent.Server.Infrastructure.Services;

public class MessageService : IMessageService
{
    // create an aws sns client and publish a message to a contact number
    public async Task SendMessage(string message)
    {
        // create an aws sns client
        // var client = new AmazonSimpleNotificationServiceClient(RegionEndpoint.USEast1);

        // // publish a message to a contact number
        // await client.PublishAsync(new PublishRequest
        // {
        //     Message = message,
        //     PhoneNumber = "+1234567890"
        // });
    }
}
