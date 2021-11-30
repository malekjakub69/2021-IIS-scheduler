using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.Dones;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoneController : ControllerBase
    {

        private readonly DoneFacade doneFacade;

        public DoneController(DoneFacade doneFacade)
        {
            this.doneFacade = doneFacade;
        }

        [HttpGet]
        public ActionResult<List<DoneListModel>> GetAll()
        {
            return doneFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<DoneDetailModel> GetById(Guid id)
        {
            return doneFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(DoneNewModel course)
        {
            return doneFacade.Create(course);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(DoneUpdateModel course)
        {
            return doneFacade.Update(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            doneFacade.Delete(id);
            return Ok();
        }
    }
}
