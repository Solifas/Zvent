namespace Zvent.Server.Usecase.Persistance.Services;

public interface IMessageService
{
    Task SendMessage(string message);
}