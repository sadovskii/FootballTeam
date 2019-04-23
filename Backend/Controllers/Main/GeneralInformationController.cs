using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories;
using Backend.Infrastructure.Converters.GeneralInformationConverters;
using Backend.Views.GeneralInformationEntities.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Backend.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralInformationController : ControllerBase
    {
        IGeneralInformationRepository _generalInformationRepository;

        public GeneralInformationController(ApplicationContext applicationContext, IGeneralInformationRepository generalInformationRepository)
        {
            _generalInformationRepository = generalInformationRepository;
        }

        // GET: api/GeneralInformation
        [HttpGet]
        public IActionResult GetGeneralInformation()
        {
            var elem = _generalInformationRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        #region GET
        // GET: api/GeneralInformation/5
        [HttpGet("{id}")]
        public IActionResult GetGeneralInformation(int id)
        {
            if(id == 0)
                return BadRequest("id is zero");

            var elem = _generalInformationRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/GeneralInformation/5/Fluorography
        [HttpGet("{id}/Fluorography")]
        public IActionResult GetWithFluorography(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _generalInformationRepository.GetFluorographyById(id)?.Fluorographies.EntityToView();

            return Ok(elem);
        }

        // GET: api/GeneralInformation/5/VaccinationStatus
        [HttpGet("{id}/VaccinationStatus")]
        public IActionResult GetWithVaccinationStatus(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _generalInformationRepository.GetVaccinationStatusById(id)?.VaccinationStatuses?.EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/GeneralInformation/5/SurgicalIntervention
        [HttpGet("{id}/SurgicalIntervention")]
        public IActionResult GetWithSurgicalIntervention(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _generalInformationRepository.GetSurgicalInterventionById(id)?.SurgicalIntervention.EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }
        #endregion

        #region POST
        // POST: api/GeneralInformation/5/Fluorography
        [HttpPost("{id}/Fluorography")]
        public IActionResult PostFluorography(int id, [FromBody] FluorographyView fluorographyView)
        {
            try
            {
                if (fluorographyView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _generalInformationRepository.InsertFluorography(id, fluorographyView.ViewToEntity());

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/GeneralInformation/5/VaccinationStatus
        [HttpPost("{id}/VaccinationStatus")]
        public IActionResult PostVaccinationStatus(int id, [FromBody] VaccinationStatusView vaccinationStatusView)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (vaccinationStatusView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _generalInformationRepository.InsertVaccinationStatus(id, vaccinationStatusView.ViewToEntity());

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

        // POST: api/GeneralInformation/5/SurgicalIntervention
        [HttpPost("{id}/SurgicalIntervention")]
        public IActionResult PostSurgicalIntervention(int id, [FromBody] SurgicalInterventionView surgicalInterventionView)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (surgicalInterventionView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _generalInformationRepository.InsertSurgicalIntervention(id, surgicalInterventionView.ViewToEntity());

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // PUT: api/GeneralInformation/6
        [HttpPut]
        public IActionResult Put([FromBody] GeneralInformationView generalInformationView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _generalInformationRepository.GetBy(t => t.Id == generalInformationView.Id);

                if (elem != null)
                {
                    elem.Bithday = generalInformationView.Birthday;
                    elem.Weight = generalInformationView.Weight;
                    elem.Height = generalInformationView.Height;
                    elem.ArterialPressure = generalInformationView.ArterialPressure;
                    elem.BloodType = generalInformationView.BloodType;

                    _generalInformationRepository.Update(elem);

                    return Ok();
                }

                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var elem = _generalInformationRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _generalInformationRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
}
