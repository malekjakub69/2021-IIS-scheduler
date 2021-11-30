using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.ScheduleDatas;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleDataController : ControllerBase
    {

        private readonly ScheduleDataFacade scheduleDataFacade;

        public ScheduleDataController(ScheduleDataFacade scheduleDataFacade)
        {
            this.scheduleDataFacade = scheduleDataFacade;
        }

        [HttpGet]
        public ActionResult<List<ScheduleDataListModel>> GetAll()
        {
            return scheduleDataFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ScheduleDataDetailModel> GetById(Guid id)
        {
            return scheduleDataFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(ScheduleDataNewModel scheduleData)
        {
            return scheduleDataFacade.Create(scheduleData);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(ScheduleDataUpdateModel scheduleData)
        {
            return scheduleDataFacade.Update(scheduleData);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            scheduleDataFacade.Delete(id);
            return Ok();
        }
    }
}
