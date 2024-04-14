using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zvent.Server.Domain.Entities;

namespace Zvent.Server.Usecase.Persistance.Interfaces;

public interface IUserRepository
{
    Task<User> GetUser(Guid id);
    IAsyncEnumerable<User> GetUsers(int page, int pageSize);
    Task<bool> CreateUser(User user);
    Task<User> UpdateUser(User user);
    Task<bool> DeleteUser(Guid id);
}