using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEntities.Entities;
using AppModels.Models.Verifications;
using App.Facades;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationController : ControllerBase
    {

        private readonly VerificationFacade verificationFacade;

        public VerificationController(VerificationFacade verificationFacade)
        {
            this.verificationFacade = verificationFacade;
        }

        [HttpGet]
        public ActionResult<List<VerificationListModel>> GetAll()
        {
            return verificationFacade.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<VerificationDetailModel> GetById(Guid id)
        {
            return verificationFacade.GetById(id);
        }

        [HttpPost]
        public ActionResult<Guid> Create(VerificationNewModel verification)
        {
            return verificationFacade.Create(verification);
        }

        [HttpPut]
        public ActionResult<Guid?> Update(VerificationUpdateModel verification)
        {
            return verificationFacade.Update(verification);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            verificationFacade.Delete(id);
            return Ok();
        }
    }
}
