using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class ActivitiesController : BaseController
    {
        private readonly DataContext _datacontext;
        public ActivitiesController(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return Ok(await _datacontext.Activities.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity?>> GetActivity(Guid id)
        {
            return await _datacontext.Activities.FirstOrDefaultAsync(activity => activity.ID == id);
        }
    }
}

