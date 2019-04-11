using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Entities;
using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.DAL.Interfaces.Repositories;
using Backend.Infrastructure.Converters;
using Backend.Infrastructure.Converters.GeneralInformationConverters;
using Backend.Infrastructure.Converters.InjuriesDiseasesConverters;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;
using Backend.Views;
using Backend.Views.GeneralInformationEntities;
using Backend.Views.InjuriesDiseasesEntities;
using Backend.Views.MedicalExaminationEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(ApplicationContext applicationContext, IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET: api/Patients
        [HttpGet]
        public IActionResult GetPatient()
        {
            var elem = _patientRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _patientRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();

        }

        // GET: api/Patients/5/GeneralInformation
        [HttpGet("{id}/GeneralInformation")]
        public IActionResult GetWithGeneralInformation(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _patientRepository.GetGeneralInformationById(id).EntityToView();

            if (elem != null && elem.GeneralInformation != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/GeneralInformation/Full
        [HttpGet("{id}/GeneralInformation/Full")]
        public IActionResult GetWithGeneralInformationFull(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _patientRepository.GetGeneralInformationByIdFull(id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/MedicalExamination
        [HttpGet("{id}/MedicalExamination")]
        public IActionResult GetWithMedicalExamination(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _patientRepository.GetMedicalExaminationById(id).EntityToView();

            if (elem != null && elem.MedicalExaminations != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/MedicalExamination/Full
        [HttpGet("{id}/MedicalExamination/Full")]
        public IActionResult GetWithMedicalExaminationFull(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _patientRepository.GetMedicalExaminationByIdFull(id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/InjuriesDiseases
        [HttpGet("{id}/InjuriesDiseases")]
        public IActionResult GetWithInjuriesDiseases(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _patientRepository.GetInjuriesDiseasesById(id).EntityToView();

            if (elem != null && elem.InjuriesDiseases != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/InjuriesDiseases/Full
        [HttpGet("{id}/InjuriesDiseases/Full")]
        public IActionResult GetWithInjuriesDiseasesFull(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _patientRepository.GetInjuriesDiseasesByIdFull(id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/Patients
        [HttpPost]
        public IActionResult Post([FromBody] PatientView patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _patientRepository.Insert(patient.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // POST: api/Patients/5/GeneralInformation
        [HttpPost("{id}/GeneralInformation")]
        public IActionResult PostWithGeneralInformation(int id, [FromBody] GeneralInformationView generalInformationView)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (generalInformationView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _patientRepository.InsertGeneralInformation(id, generalInformationView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/InjuriesDiseases
        [HttpPost("{id}/MedicalExamination")]
        public IActionResult PostWithMedicalExamination(int id, [FromBody] MedicalExaminationView medicalExaminationView)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (medicalExaminationView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _patientRepository.InsertMedicalExamination(id, medicalExaminationView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/InjuriesDiseases
        [HttpPost("{id}/InjuriesDiseases")]
        public IActionResult PostWithInjuriesDiseases(int id, [FromBody] InjuriesDiseasesView injuriesDiseasesView)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (injuriesDiseasesView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _patientRepository.InsertInjuriesDiseases(id, injuriesDiseasesView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // PUT: api/Patients
        [HttpPut]
        public IActionResult Put([FromBody] PatientView patientView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                _patientRepository.Update(patientView.ViewToEntity());
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Patients/5/GeneralInformation
        [HttpPut("{id}/GeneralInformation")]
        public IActionResult PutGeneralInformation(int id, [FromBody] GeneralInformationView generalInformationView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _patientRepository.GetGeneralInformationById(id);

                if(elem.GeneralInformation.Id == generalInformationView.Id)
                {
                    elem.GeneralInformation.Bithday = generalInformationView.Bithday;
                    elem.GeneralInformation.ArterialPressure = generalInformationView.ArterialPressure;
                    elem.GeneralInformation.BloodType = generalInformationView.BloodType;
                    elem.GeneralInformation. = generalInformationView.Bithday;
                    elem.GeneralInformation.Bithday = generalInformationView.Bithday;
                }

                _patientRepository.Update(elem);
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
            _patientRepository.Delete(id);
        }
    }
}
