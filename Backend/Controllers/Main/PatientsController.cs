using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.BLL.Interfaces;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories;
using Backend.Infrastructure.Converters;
using Backend.Infrastructure.Converters.GeneralInformationConverters;
using Backend.Infrastructure.Converters.InjuriesDiseasesConverters;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;
using Backend.Infrastructure.Helpers;
using Backend.Views.Components;
using Backend.Views.GeneralInformationEntities.Components;
using Backend.Views.InjuriesDiseasesEntities.Components;
using Backend.Views.MedicalExaminationEntities.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly UploadFileAndSavePath _uploadFileAndSavePath;

        public PatientsController(IPatientRepository patientRepository, IImageHandler imageHandler)
        {
            _patientRepository = patientRepository;
            _uploadFileAndSavePath = new UploadFileAndSavePath(imageHandler);
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

            var elem = _patientRepository.GetGeneralInformationById(id).GeneralInformation.EntityToView();

            if (elem != null)
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

            var elem = _patientRepository.GetMedicalExaminationById(id).MedicalExaminations.EntityToView();

            if (elem != null)
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

            var elem = _patientRepository.GetInjuriesDiseasesById(id).InjuriesDiseases.EntityToView();

            if (elem != null)
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
        public async Task<IActionResult> Post(PatientView patient )
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
                await _uploadFileAndSavePath.UloadFile(patient);

                _patientRepository.InsertWithDefaultGeneralInformation(patient.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // POST: api/Patients/5/GeneralInformation
        [HttpPost("{id}/GeneralInformation")]
        public IActionResult PostWithGeneralInformation(int id, [FromForm] GeneralInformationView generalInformationView)
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

        // POST: api/Patients/5/MedicalExamination
        [HttpPost("{id}/MedicalExamination")]
        public async Task<IActionResult> PostWithMedicalExamination(int id, [FromForm] MedicalExaminationView medicalExaminationView)
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

                await _uploadFileAndSavePath.UloadFile(medicalExaminationView);

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
        public async Task<IActionResult> PostWithInjuriesDiseases(int id, [FromForm] InjuriesDiseasesView injuriesDiseasesView)
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

                await _uploadFileAndSavePath.UloadFile(injuriesDiseasesView);

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
        public async Task<IActionResult> Put([FromForm] PatientView patientView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _patientRepository.GetBy(t => t.Id == patientView.Id);

                if (elem != null)
                {
                    await _uploadFileAndSavePath.UloadFile(patientView);

                    elem.Name = patientView.Name;
                    elem.Photo = patientView.Photo;

                    _patientRepository.Update(elem);

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
        public IActionResult Delete(int id)
        {
            var elem = _patientRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _patientRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
}
