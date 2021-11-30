using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.Competences;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceController : ControllerBase
    {

        private readonly CompetenceFacade competenceFacade;

        public CompetenceController(CompetenceFacade competenceFacade)
        {
            this.competenceFacade = competenceFacade;
        }

        [HttpGet]
        public ActionResult<List<CompetenceListModel>> GetAll()
        {
            return competenceFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<CompetenceDetailModel> GetById(Guid id)
        {
            return competenceFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(CompetenceNewModel competence)
        {
            return competenceFacade.Create(competence);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(CompetenceUpdateModel competence)
        {
            return competenceFacade.Update(competence);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            competenceFacade.Delete(id);
            return Ok();
        }
    }
}
