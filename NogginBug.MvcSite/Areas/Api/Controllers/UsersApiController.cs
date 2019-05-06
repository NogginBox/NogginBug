using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NogginBug.Data;
using NogginBug.Data.Model;
using NogginBug.MvcSite.Areas.Api.Dtos;
using System;
using System.Threading.Tasks;

namespace NogginBug.MvcSite.Areas.Api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersApiController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public UsersApiController(IDataContext data, ILogger<BugsApiController> logger, IMapper mapper) : base(data, logger)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new user to the system.
        /// Unless a user with this name already exists
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(NogginBugUserDto userDto)
        {
            var exisitingUser = await Data.Users.FirstOrDefaultAsync(u => u.Name == userDto.Name);
            if(exisitingUser != null)
            {
                // 303: See other (consider 409: Conflict) 
                return StatusCode(303, _mapper.Map<NogginBugUserDto>(exisitingUser));
            }

            var newUser = NogginBugUser.CreateNewUser(userDto.Name);

            try
            {
                Data.Users.Add(newUser);
                await Data.SaveChangesAsync();

                var newUserDto = _mapper.Map<NogginBugUserDto>(newUser);
                return Ok(newUser);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Could save new user");
                return StatusCode(500);
            }
        }
    }
}