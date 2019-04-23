using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories.Other.GeneralInformation;
using Backend.Infrastructure.Converters.GeneralInformationConverters;
using Backend.Views.GeneralInformationEntities.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Other.GeneralInformation
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationStatusController : ControllerBase
    {
        private readonly IVaccinationStatusRepository _vaccinationStatusRepository;

        public VaccinationStatusController(ApplicationContext applicationContext, IVaccinationStatusRepository vaccinationStatusRepository)
        {
            _vaccinationStatusRepository = vaccinationStatusRepository;
        }

        // GET: api/VaccinationStatus
        [HttpGet]
        public IActionResult GetVaccinationStatus()
        {
            var elem = _vaccinationStatusRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/VaccinationStatus/5
        [HttpGet("{id}")]
        public IActionResult GetVaccinationStatusn(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _vaccinationStatusRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/VaccinationStatus
        [HttpPost]
        public IActionResult PostVaccinationStatus([FromBody] VaccinationStatusView vaccinationStatus)
        {
            try
            {
                if (vaccinationStatus == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                vaccinationStatus.Id = 0;
                _vaccinationStatusRepository.Insert(vaccinationStatus.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/VaccinationStatus
        [HttpPut]
        public IActionResult PutVaccinationStatus([FromBody] VaccinationStatusView vaccinationStatusView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _vaccinationStatusRepository.GetBy(t => t.Id == vaccinationStatusView.Id);

                if (elem != null)
                {
                    elem.Information = vaccinationStatusView.Information;
                    elem.ProcedureTime = vaccinationStatusView.ProcedureTime;

                    _vaccinationStatusRepository.Update(elem);

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
        public IActionResult DeleteVaccinationStatus(int id)
        {
            var elem = _vaccinationStatusRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _vaccinationStatusRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
    
}
