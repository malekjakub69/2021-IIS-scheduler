using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.CourseLeaders;
using Microsoft.AspNetCore.Authorization;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseLeaderController : ControllerBase
    {

        private readonly CourseLeaderFacade courseLeaderFacade;

        public CourseLeaderController(CourseLeaderFacade courseLeaderFacade)
        {
            this.courseLeaderFacade = courseLeaderFacade;
        }

        [HttpGet]
        public ActionResult<List<CourseLeaderListModel>> GetAll()
        {
            return courseLeaderFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<CourseLeaderDetailModel> GetById(Guid id)
        {
            return courseLeaderFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(CourseLeaderNewModel courseLeader)
        {
            return courseLeaderFacade.Create(courseLeader);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(CourseLeaderUpdateModel courseLeader)
        {
            return courseLeaderFacade.Update(courseLeader);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            courseLeaderFacade.Delete(id);
            return Ok();
        }
    }
}
