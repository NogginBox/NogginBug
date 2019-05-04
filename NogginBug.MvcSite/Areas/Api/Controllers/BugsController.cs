using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using NogginBug.Data;
using NogginBug.Data.Extensions;
using NogginBug.Data.Model;
using NogginBug.MvcSite.Areas.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NogginBug.MvcSite.Areas.Api.Controllers
{
    [Route("api/v1/bugs")]
    [ApiController]
    public class BugsController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public BugsController(IDataContext data, ILogger<BugsController> logger, IMapper mapper) : base(data, logger)
        {
            _mapper = mapper;
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