using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.CourseParticipants;
using Microsoft.AspNetCore.Authorization;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseParticipantController : ControllerBase
    {

        private readonly CourseParticipantFacade courseParticipantFacade;

        public CourseParticipantController(CourseParticipantFacade courseParticipantFacade)
        {
            this.courseParticipantFacade = courseParticipantFacade;
        }

        [HttpGet]
        public ActionResult<List<CourseParticipantListModel>> GetAll()
        {
            return courseParticipantFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<CourseParticipantDetailModel> GetById(Guid id)
        {
            return courseParticipantFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(CourseParticipantNewModel courseParticipant)
        {
            return courseParticipantFacade.Create(courseParticipant);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(CourseParticipantUpdateModel courseParticipant)
        {
            return courseParticipantFacade.Update(courseParticipant);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            courseParticipantFacade.Delete(id);
            return Ok();
        }
    }
}
