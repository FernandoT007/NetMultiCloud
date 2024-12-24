using Amazon.DynamoDBv2.DataModel;
using ServerlessAPI.Entities;

namespace ServerlessAPI.Repositories;

public class SedeRepository : ISedeRepository
{
    private readonly IDynamoDBContext _context;

    public SedeRepository(IDynamoDBContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Sede sede)
    {
        await _context.SaveAsync(sede);
    }

    public async Task<Sede?> GetByIdAsync(string id)
    {
        return await _context.LoadAsync<Sede>(id);
    }
}