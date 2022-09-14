using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using DataModel = API.DataModel;
using API.Domain;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly UserRepository userRepository;
    private readonly IMapper mapper;

    public UsersController(UserRepository userRepository, IMapper mapper)
    {
      this.userRepository = userRepository;
      this.mapper = mapper;
    }

    [HttpGet]
    [Route("api/[controller]")]
    public async Task<IActionResult> GetUsers()
    {
      var users = await userRepository.GetUsers();

      return Ok(users);
    }

    [HttpGet]
    [Route("api/[controller]/{userId:int}")]
    public async Task<IActionResult> GetUser([FromRoute] int userId)
    {
      var user = await userRepository.GetUser(userId);

      if (user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }

    [HttpPut]
    [Route("api/[controller]/{userId:int}")]
    public async Task<IActionResult> UpdateUser([FromRoute] int userId, [FromBody] UserRequest request)
    {
      if (await userRepository.Exists(userId))
      {
        var updatedUser = await userRepository.UpdateUser(userId, mapper.Map<DataModel.AppUser>(request));

        if (updatedUser != null)
        {
          return Ok(updatedUser);
        }

      }

      return NotFound();
    }

    [HttpDelete]
    [Route("api/[controller]/{userId:int}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int userId)
    {
      if (await userRepository.Exists(userId))
      {
        return Ok(await userRepository.DeleteUser(userId));
      }

      return NotFound();
    }

    [HttpPost]
    [Route("api/[controller]/adduser")]
    public async Task<IActionResult> AddUser([FromBody] UserRequest request)
    {
      var newUser = await userRepository.AddUser(mapper.Map<DataModel.AppUser>(request));

      return Ok(newUser);
    }

  }
}