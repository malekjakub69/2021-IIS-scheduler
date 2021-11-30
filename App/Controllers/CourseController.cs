using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "Leader")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly CourseFacade courseFacade;

        public CourseController(CourseFacade courseFacade)
        {
            this.courseFacade = courseFacade;
        }

        [HttpGet]
        public ActionResult<List<CourseListModel>> GetAll()
        {
            return courseFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<CourseDetailModel> GetById(Guid id)
        {
            return courseFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(CourseNewModel course)
        {
            return courseFacade.Create(course);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(CourseUpdateModel course)
        {
            return courseFacade.Update(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            courseFacade.Delete(id);
            return Ok();
        }
    }
}
