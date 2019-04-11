using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.DAL.Interfaces.Repositories;
using Backend.Infrastructure.Converters.GeneralInformationConverters;
using Backend.Views.GeneralInformationEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            var elem = _generalInformationRepository.GetFluorographyById(id).Fluorographies.EntityToView();

            return Ok(elem);
        }

        // GET: api/GeneralInformation/5/VaccinationStatus
        [HttpGet("{id}/VaccinationStatus")]
        public IActionResult GetWithVaccinationStatus(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _generalInformationRepository.GetVaccinationStatusById(id).EntityToView();

            if (elem != null && elem.VaccinationStatuses != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/GeneralInformation/5/SurgicalIntervention
        [HttpGet("{id}/SurgicalIntervention")]
        public IActionResult GetWithSurgicalIntervention(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _generalInformationRepository.GetSurgicalInterventionById(id).EntityToView();

            if (elem != null && elem.SurgicalIntervention != null)
                return Ok(elem);

            return NotFound();
        }
        #endregion

        #region POST
        // POST: api/GeneralInformation/5/Fluorography
        [HttpPost("{id}/Fluorography")]
        public IActionResult PostWithGeneralInformation(int id, [FromBody] FluorographyView fluorographyView)
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
        public IActionResult PostWithMedicalExamination(int id, [FromBody] VaccinationStatusView vaccinationStatusView)
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
        public IActionResult PostWithInjuriesDiseases(int id, [FromBody] SurgicalInterventionView surgicalInterventionView)
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

                _generalInformationRepository.InserSurgicalIntervention(id, surgicalInterventionView.ViewToEntity());

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // PUT: api/GeneralInformation
        [HttpPut]
        public IActionResult Put([FromBody] GeneralInformationView valueView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                _generalInformationRepository.Update(valueView.ViewToEntity());
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _generalInformationRepository.Delete(id);
        }
    }
}
