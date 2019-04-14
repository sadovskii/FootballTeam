using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories.Other.InjuriesDiseases;
using Backend.Infrastructure.Converters.Common.InstrumentalStudies;
using Backend.Views.Common.InstrumentalStudies.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Other.InjuriesDiseases
{
    [Route("api/[controller]")]
    [ApiController]
    public class MRIController : ControllerBase
    {
        private readonly IMRIRepository _MRIRepository;

        public MRIController(ApplicationContext applicationContext, IMRIRepository MRIRepository)
        {
            _MRIRepository = MRIRepository;
        }
        // GET: api/MRI
        [HttpGet]
        public IActionResult GetHeartUltrasound()
        {
            var elem = _MRIRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/MRI/5
        [HttpGet("{id}")]
        public IActionResult GetHeartUltrasound(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _MRIRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/MRI
        [HttpPost]
        public IActionResult PostHeartUltrasound([FromBody] MRIView mri)
        {
            try
            {
                if (mri == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                mri.Id = 0;
                _MRIRepository.Insert(mri.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/MRI
        [HttpPut]
        public IActionResult PutHeartUltrasound([FromBody] MRIView mri)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _MRIRepository.GetBy(t => t.Id == mri.Id);

                if (elem != null)
                {
                    elem.Info = mri.Info;

                    _MRIRepository.Update(elem);

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
        public IActionResult DeleteHeartUltrasound(int id)
        {
            var elem = _MRIRepository.GetBy(t => t.Id == id);

            if (elem != null)
                _MRIRepository.Delete(id);

            return NotFound();
        }
    }
}
