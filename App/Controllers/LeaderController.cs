using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.Leaders;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderController : ControllerBase
    {

        private readonly LeaderFacade leaderFacade;

        public LeaderController(LeaderFacade leaderFacade)
        {
            this.leaderFacade = leaderFacade;
        }

        [HttpGet]
        public ActionResult<List<LeaderListModel>> GetAll()
        {
            return leaderFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<LeaderDetailModel> GetById(Guid id)
        {
            return leaderFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(LeaderNewModel leader)
        {
            return leaderFacade.Create(leader);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(LeaderUpdateModel leader)
        {
            return leaderFacade.Update(leader);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            leaderFacade.Delete(id);
            return Ok();
        }
    }
}
