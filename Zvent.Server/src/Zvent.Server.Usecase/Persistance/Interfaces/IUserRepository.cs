using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zvent.Server.Domain.Entities;

namespace Zvent.Server.Usecase.Persistance.Interfaces;

public interface IUserRepository
{
    Task<User> GetUser(string userName);
    IAsyncEnumerable<User> GetUsers(int page, int pageSize);
    Task<bool> CreateUser(User user);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(Guid id);
}