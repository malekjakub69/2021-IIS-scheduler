using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.Participants;
using App.Facades;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Leader")]
    public class ParticipantController : ControllerBase
    {

        private readonly ParticipantFacade participantFacade;

        public ParticipantController(ParticipantFacade participantFacade)
        {
            this.participantFacade = participantFacade;
        }

        [HttpGet]
        public ActionResult<List<ParticipantListModel>> GetAll()
        {
            return participantFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ParticipantDetailModel> GetById(Guid id)
        {
            return participantFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(ParticipantNewModel participant)
        {
            return participantFacade.Create(participant);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(ParticipantUpdateModel participant)
        {
            return participantFacade.Update(participant);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            participantFacade.Delete(id);
            return Ok();
        }
    }
}
