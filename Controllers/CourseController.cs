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
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("/api/course/{id}")]
        public ActionResult<Course> GetProduct(string id)
        {
            return _courseService.GetItem(id);
        }

        [HttpGet("/api/course")]
        public ActionResult<List<Course>> GetCourseList()
        {
            return _courseService.GetList();
        }

        [HttpPost("/api/course")]
        public ActionResult<Course> AddProduct(Course course)
        {
            _courseService.Create(course);
            return course;
        }

        [HttpPut("/api/course/{id}")]
        public ActionResult<Course> UpdateProduct(Course course)
        {
            _courseService.Update(course);
            return course;
        }

        [HttpDelete("/api/course/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            _courseService.Delete(id);
            return id;
        }
    }
}
