using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GolfTrackerAPI.Services;
using GolfTrackerAPI.Models;
using GolfTrackerAPI.Data;

namespace GolfTrackerAPI.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class TeeController : ControllerBase
    {
        private ITeeService _teeService;

        public TeeController(ITeeService teeService)
        {
            _teeService = teeService;
        }

        [HttpGet("/api/tee")]
        public ActionResult<List<Tee>> GetTeeList()
        {
            return _teeService.GetList();
        }

        [HttpGet("/api/tee/{id}")]
        public ActionResult<Tee> GetProduct(string id)
        {
            return _teeService.GetItem(id);
        }

        [HttpPost("/api/tee")]
        public ActionResult<Tee> AddProduct(Tee tee)
        {
            _teeService.Create(tee);
            return tee;
        }

        [HttpPut("/api/tee/{id}")]
        public ActionResult<Tee> UpdateProduct(Tee tee)
        {
            _teeService.Update(tee);
            return tee;
        }

        [HttpDelete("/api/tee/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            _teeService.Delete(id);
            return id;
        }
    }
}
