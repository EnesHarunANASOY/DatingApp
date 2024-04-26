using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepostory _userRepostory;
    private readonly IMapper _mapper;

    public UsersController(IUserRepostory userRepostory, IMapper mapper)
    {
        _userRepostory = userRepostory;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
       var users = await _userRepostory.GetMembersAsync();
       return Ok(users);

    }

    [HttpGet("{username}")] 
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _userRepostory.GetMemberAsync(username);
    }
}