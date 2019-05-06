using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NogginBug.Data;
using NogginBug.Data.Extensions;
using NogginBug.Data.Model;
using NogginBug.MvcSite.Areas.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NogginBug.MvcSite.Areas.Api.Controllers
{
    [Route("api/v1/bugs")]
    [ApiController]
    public class BugsApiController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public BugsApiController(IDataContext data, ILogger<BugsApiController> logger, IMapper mapper) : base(data, logger)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets details of a bug
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Guid.TryParse(id, out var guidId);
            if (guidId == null) return NotFound();
            var bug = await Data.Bugs.FirstOrDefaultAsync(b => b.IdExternal == guidId);
            if (bug == null) return NotFound();

            var bugDto = _mapper.Map<BugDto>(bug);
            return Ok(bugDto);
        }

        /// <summary>
        /// Shows a list of all bugs
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var bugs = await Data.Bugs
                .WhereVisible()
                .OrderBy(p => p.OpenedDate)
                .ToListAsync();

            var bugDtos = _mapper.Map<List<BugDto>>(bugs);

            return Ok(bugDtos);
        }

        /// <summary>
        /// Replace the current list of bugs with a new list of bugs.
        /// (Old bugs are marked for deletion)
        /// </summary>
        /// <param name="bugs"></param>
        /// <response code="201">Successfully imported new bugs</response>
        [HttpPut]
        public async Task<IStatusCodeActionResult> Put(IList<BugDto> bugs)
        {
            try
            {
                var newBugs = _mapper.Map<List<Bug>>(bugs);

                Data.Bugs.DeleteAll();
                Data.Bugs.AddRange(newBugs);
                await Data.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Failed to import new bugs through API");
                return StatusCode(500);
            }

            return StatusCode(201);
        }
    }
}