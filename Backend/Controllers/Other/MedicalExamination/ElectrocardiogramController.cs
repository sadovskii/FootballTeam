using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories.Other.MedicalExamination;
using Backend.Infrastructure.Converters.Common.InstrumentalStudies;
using Backend.Views.Common.InstrumentalStudies.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Other.MedicalExamination
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectrocardiogramController : ControllerBase
    {
        private readonly IElectrocardiogramRepository _electrocardiogramRepository;

        public ElectrocardiogramController(ApplicationContext applicationContext, IElectrocardiogramRepository electrocardiogramRepository)
        {
            _electrocardiogramRepository = electrocardiogramRepository;
        }

        // GET: api/Electrocardiogram
        [HttpGet]
        public IActionResult GetElectrocardiogram()
        {
            var elem = _electrocardiogramRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Electrocardiogram/5
        [HttpGet("{id}")]
        public IActionResult GetElectrocardiogram(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _electrocardiogramRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/Electrocardiogram
        [HttpPost]
        public IActionResult PostElectrocardiogram([FromBody] ElectrocardiogramView electrocardiogram)
        {
            try
            {
                if (electrocardiogram == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                electrocardiogram.Id = 0;
                _electrocardiogramRepository.Insert(electrocardiogram.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/Electrocardiogram/5
        [HttpPut]
        public IActionResult PutElectrocardiogram([FromBody]  ElectrocardiogramView electrocardiogram)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _electrocardiogramRepository.GetBy(t => t.Id == electrocardiogram.Id);

                if (elem != null)
                {
                    elem.Info = electrocardiogram.Info;

                    _electrocardiogramRepository.Update(elem);

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
        public IActionResult DeleteElectrocardiogram(int id)
        {
            var elem = _electrocardiogramRepository.GetBy(t => t.Id == id);

            if (elem != null)
                _electrocardiogramRepository.Delete(id);

            return NotFound();
        }
    }
}
