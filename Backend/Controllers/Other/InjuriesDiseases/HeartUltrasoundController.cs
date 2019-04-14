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
    public class HeartUltrasoundController : ControllerBase
    {
        private readonly IHeartUltrasoundRepository _heartUltrasoundRepository;

        public HeartUltrasoundController(ApplicationContext applicationContext, IHeartUltrasoundRepository heartUltrasoundRepository)
        {
            _heartUltrasoundRepository = heartUltrasoundRepository;
        }

        // GET: api/HeartUltrasound
        [HttpGet]
        public IActionResult GetHeartUltrasound()
        {
            var elem = _heartUltrasoundRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/HeartUltrasound/5
        [HttpGet("{id}")]
        public IActionResult GetHeartUltrasound(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _heartUltrasoundRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/HeartUltrasound
        [HttpPost]
        public IActionResult PostHeartUltrasound([FromBody] HeartUltrasoundView heartUltrasound)
        {
            try
            {
                if (heartUltrasound == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                heartUltrasound.Id = 0;
                _heartUltrasoundRepository.Insert(heartUltrasound.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/HeartUltrasound
        [HttpPut]
        public IActionResult PutHeartUltrasound([FromBody] HeartUltrasoundView heartUltrasound)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _heartUltrasoundRepository.GetBy(t => t.Id == heartUltrasound.Id);

                if (elem != null)
                {
                    elem.Info = heartUltrasound.Info;

                    _heartUltrasoundRepository.Update(elem);

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
            var elem = _heartUltrasoundRepository.GetBy(t => t.Id == id);

            if (elem != null)
                _heartUltrasoundRepository.Delete(id);

            return NotFound();
        }
    }
}
