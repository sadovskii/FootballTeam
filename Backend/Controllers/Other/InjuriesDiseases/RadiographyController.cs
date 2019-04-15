using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories.Other.InjuriesDiseases;
using Backend.Infrastructure.Converters.Common.InstrumentalStudies;
using Backend.Views.Components.Common.InstrumentalStudies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Other.InjuriesDiseases
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadiographyController : ControllerBase
    {
        private readonly IRadiographyRepository _radiographyRepository;

        public RadiographyController(ApplicationContext applicationContext, IRadiographyRepository radiographyRepository)
        {
            _radiographyRepository = radiographyRepository;
        }

        // GET: api/Radiography
        [HttpGet]
        public IActionResult Get()
        {
            var elem = _radiographyRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Radiography/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _radiographyRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/Radiography
        [HttpPost]
        public IActionResult Post([FromBody] RadiographyView radiography)
        {
            try
            {
                if (radiography == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                radiography.Id = 0;
                _radiographyRepository.Insert(radiography.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/Radiography/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RadiographyView radiography)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _radiographyRepository.GetBy(t => t.Id == radiography.Id);

                if (elem != null)
                {
                    elem.Info = radiography.Info;

                    _radiographyRepository.Update(elem);

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
            var elem = _radiographyRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _radiographyRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
}
