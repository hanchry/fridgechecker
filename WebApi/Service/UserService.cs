using AutoMapper;
using fridgechecker.Legacy;
using fridgechecker.Legacy.Entities;
using fridgechecker.Legacy.Models;
using Microsoft.EntityFrameworkCore;

namespace fridgechecker.Service;

public interface IUserService
{
    Task<bool> Authenticate(UserDB user);
    Task Register(UserDB user);
    Task<User> GetById(int id);
    Task<IList<User>> GetByName(string name);
}
public class UserService: IUserService
{
    private readonly FridgeLegacyContext _legacy;
    private readonly IMapper _mapper;

    public UserService(FridgeLegacyContext legacy, IMapper mapper)
    {
        _legacy = legacy;
        _mapper = mapper;
    }
    
    //Have to do it correctly
    public async Task<bool> Authenticate(UserDB user)
    {
        var userEntity = await _legacy.Users.FirstOrDefaultAsync(u => u.Name == user.Name && u.Password == user.Password);
        return userEntity != null;
    }

    //Have to do it correctly
    public async Task Register(UserDB user)
    {
        _legacy.Users.Add(_mapper.Map<User>(user));
        await _legacy.SaveChangesAsync();
    }

    public async Task<User> GetById(int id)
    {
        var user = await _legacy.Users.FindAsync(id);
        return _mapper.Map<User>(user);
    }
    

    public async Task<IList<User>> GetByName(string name)
    {
        var users = await _legacy.Users.Where(u => u.Name.Contains(name)).ToListAsync();
        return _mapper.Map<IList<User>>(users);
    }
}