using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.User;
using SmartTransit.Domain.Security.Criptography;
using SmartTransit.Domain.Security.Tokens;
using SmartTransit.Infrastructure.Entities;
using SmartTransit.Infrastructure.Persistence;

namespace SmartTransit.Infrastructure.Repositories;

public class UserRepository : IUserRepositoryGateway
{
    private readonly SmartTransitDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserRepository(SmartTransitDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<UserDTO> RegisterUser(UserDTO userDto)
    {
        var userEntity = _mapper.Map<UserEntity>(userDto);
        
        userEntity.Id = Guid.NewGuid();
        userEntity.UserIdentifier = Guid.NewGuid();
        
        await _dbContext.UserEntities.AddAsync(userEntity);
        await _dbContext.SaveChangesAsync();
        
        return _mapper.Map<UserDTO>(userEntity);
    }

    public async Task<UserDTO?> GetByEmail(string email)
    {
        var normalizedEmail = email.ToLower();

        var userEntity = await _dbContext.UserEntities
            .FirstOrDefaultAsync(user => user.Email.ToLower() == normalizedEmail);

        if (userEntity == null)
            return null;

        return _mapper.Map<UserDTO>(userEntity);
    }

    public async Task<UserDTO?> GetById(Guid userId)
    {
        var userEntity = await _dbContext.UserEntities
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (userEntity == null)
            return null;
        
        return _mapper.Map<UserDTO>(userEntity);
    }
 
}