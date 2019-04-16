using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Backend.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Components
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IImageHandler _imageHandler;

        public UploadController(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        /// <summary>
        /// Uplaods an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                var a = await _imageHandler.UploadImage(file);
                return Ok(a);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
