using ServerlessAPI.Entities;

namespace ServerlessAPI.Repositories;

public interface ISedeRepository
{
    Task<Sede?> GetByIdAsync(string id);
    Task CreateAsync(Sede sede);
}