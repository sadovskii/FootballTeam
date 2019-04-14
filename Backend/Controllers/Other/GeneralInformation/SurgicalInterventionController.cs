using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories.Other.GeneralInformation;
using Backend.Infrastructure.Converters.GeneralInformationConverters;
using Backend.Views.GeneralInformationEntities.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Other.GeneralInformation
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgicalInterventionController : ControllerBase
    {
        private readonly ISurgicalInterventionRepository _surgicalInterventionRepository;

        public SurgicalInterventionController(ApplicationContext applicationContext, ISurgicalInterventionRepository surgicalInterventionRepository)
        {
            _surgicalInterventionRepository = surgicalInterventionRepository;
        }

        // GET: api/SurgicalIntervention
        [HttpGet]
        public IActionResult GetSurgicalIntervention()
        {
            var elem = _surgicalInterventionRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/SurgicalIntervention/5
        [HttpGet("{id}")]
        public IActionResult GetSurgicalIntervention(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _surgicalInterventionRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/SurgicalIntervention
        [HttpPost]
        public IActionResult PostSurgicalIntervention([FromBody] SurgicalInterventionView surgicalInterventionView)
        {
            try
            {
                if (surgicalInterventionView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                surgicalInterventionView.Id = 0;
                _surgicalInterventionRepository.Insert(surgicalInterventionView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/SurgicalIntervention
        [HttpPut]
        public IActionResult PutSurgicalIntervention([FromBody] SurgicalInterventionView surgicalInterventionView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _surgicalInterventionRepository.GetBy(t => t.Id == surgicalInterventionView.Id);

                if (elem != null)
                {
                    elem.Diagnosis = surgicalInterventionView.Diagnosis;
                    elem.ProcedureTime = surgicalInterventionView.ProcedureTime;
                    elem.InterventionType = surgicalInterventionView.InterventionType;

                    _surgicalInterventionRepository.Update(elem);

                    return Ok();
                }

                return NotFound();

            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSurgicalIntervention(int id)
        {
            var elem = _surgicalInterventionRepository.GetBy(t => t.Id == id);

            if (elem != null)
                _surgicalInterventionRepository.Delete(id);

            return NotFound();
        }
    }
}
