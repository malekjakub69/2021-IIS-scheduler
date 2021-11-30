using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.TimeBlocks;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeBlockController : ControllerBase
    {

        private readonly TimeBlockFacade timeBlockFacade;

        public TimeBlockController(TimeBlockFacade timeBlockFacade)
        {
            this.timeBlockFacade = timeBlockFacade;
        }

        [HttpGet]
        public ActionResult<List<TimeBlockListModel>> GetAll()
        {
            return timeBlockFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TimeBlockDetailModel> GetById(Guid id)
        {
            return timeBlockFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(TimeBlockNewModel timeBlock)
        {
            return timeBlockFacade.Create(timeBlock);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(TimeBlockUpdateModel timeBlock)
        {
            return timeBlockFacade.Update(timeBlock);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            timeBlockFacade.Delete(id);
            return Ok();
        }
    }
}
