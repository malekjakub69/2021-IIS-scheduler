using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.Schedules;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {

        private readonly ScheduleFacade scheduleFacade;

        public ScheduleController(ScheduleFacade scheduleFacade)
        {
            this.scheduleFacade = scheduleFacade;
        }

        [HttpGet]
        public ActionResult<List<ScheduleListModel>> GetAll()
        {
            return scheduleFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ScheduleDetailModel> GetById(Guid id)
        {
            return scheduleFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(ScheduleNewModel schedule)
        {
            return scheduleFacade.Create(schedule);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(ScheduleUpdateModel schedule)
        {
            return scheduleFacade.Update(schedule);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            scheduleFacade.Delete(id);
            return Ok();
        }
    }
}
