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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
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
            var elem = _generalInformationRepository.GetAll();

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

            var elem = _generalInformationRepository.GetBy(t => t.Id == id);

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

            var elem = _generalInformationRepository.GetFluorographyById(id).Fluorographies;

            if (elem == null)
                elem = new List<Fluorography>();

            return Ok(elem);
        }

        // GET: api/GeneralInformation/5/VaccinationStatus
        [HttpGet("{id}/VaccinationStatus")]
        public IActionResult GetWithVaccinationStatus(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _generalInformationRepository.GetVaccinationStatusById(id);

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

            var elem = _generalInformationRepository.GetSurgicalInterventionById(id);

            if (elem != null && elem.SurgicalIntervention != null)
                return Ok(elem);

            return NotFound();
        }
        #endregion

        #region POST
        // POST: api/GeneralInformation/5/Fluorography
        [HttpPost("{id}/Fluorography")]
        public IActionResult PostWithGeneralInformation(int id, [FromBody] Fluorography fluorography)
        {
            try
            {
                if (fluorography == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _generalInformationRepository.InsertFluorography(id, fluorography);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/GeneralInformation/5/VaccinationStatus
        [HttpPost("{id}/VaccinationStatus")]
        public IActionResult PostWithMedicalExamination(int id, [FromBody] VaccinationStatus vaccinationStatus)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (vaccinationStatus == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _generalInformationRepository.InsertVaccinationStatus(id, vaccinationStatus);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

        // POST: api/GeneralInformation/5/SurgicalIntervention
        [HttpPost("{id}/SurgicalIntervention")]
        public IActionResult PostWithInjuriesDiseases(int id, [FromBody] SurgicalIntervention surgicalIntervention)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (surgicalIntervention == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _generalInformationRepository.InserSurgicalIntervention(id, surgicalIntervention);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        // PUT: api/GeneralInformation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GeneralInformation value)
        {
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
