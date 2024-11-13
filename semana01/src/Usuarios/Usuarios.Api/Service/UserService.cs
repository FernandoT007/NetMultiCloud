using Usuarios.Api.Models;

namespace Usuarios.Api.Service;

public class UserService : IUserService
{
    private readonly Dictionary<Guid,UserModel> _users = new();
    public Task<UserModel> CreateUserAsync(UserModel user)
    {
        user.Id = Guid.NewGuid();
        _users[user.Id] = user;
        return Task.FromResult(user);
    }

    public Task<bool> DeleteUserAsync(Guid id) => 
        Task.FromResult(_users.Remove(id));

    public Task<UserModel?> GetUserByIdAsync(Guid id) =>
        Task.FromResult(_users.ContainsKey(id) ? _users[id] : null);

    public Task<UserModel?> UpdateUserAsync(Guid id, UserModel user)
    {
        if(!_users.ContainsKey(id)) return Task.FromResult<UserModel?>(null);
        user.Id = id;
        _users[user.Id] = user;
        return Task.FromResult<UserModel?>(user);
    }
}