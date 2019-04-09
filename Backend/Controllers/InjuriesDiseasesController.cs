using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjuriesDiseasesController : ControllerBase
    {
        IInjuriesDiseasesRepository _injuriesDiseasesRepository;

        public InjuriesDiseasesController(IInjuriesDiseasesRepository injuriesDiseasesRepository)
        {
            _injuriesDiseasesRepository = injuriesDiseasesRepository;
        }

        // GET: api/InjuriesDiseases
        [HttpGet]
        public IActionResult GetInjuriesDiseases()
        {
            var elem = _injuriesDiseasesRepository.GetAll();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/InjuriesDiseases/5
        [HttpGet("{id}")]
        public IActionResult GetGetMedicalExamination(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _injuriesDiseasesRepository.GetBy(t => t.Id == id);

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/InjuriesDiseases/5/MRIs
        [HttpGet("{id}", Name = "MRIs")]
        public IActionResult GetWithMRI(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _injuriesDiseasesRepository.GetMRIById(id);

            if (elem != null && elem.MRIs != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/GeneralInformation/5/HeartUltrasounds
        [HttpGet("{id}", Name = "HeartUltrasounds")]
        public IActionResult GetWithHeartUltrasound(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _injuriesDiseasesRepository.GetHeartUltrasoundById(id);

            if (elem != null && elem.HeartUltrasounds != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/Patients/5/MRI
        [HttpPost("{id}/MRI")]
        public IActionResult PostWithMRI(int id, [FromBody] MRI mri)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (mri == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _injuriesDiseasesRepository.InsertMRI(id, mri);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/HeartUltrasound
        [HttpPost("{id}/HeartUltrasound")]
        public void PostWithHeartUltrasound(int id, [FromBody] HeartUltrasound heartUltrasound)
        {
            _injuriesDiseasesRepository.InsertHeartUltrasound(id, heartUltrasound);
        }

        // PUT: api/InjuriesDiseases/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
