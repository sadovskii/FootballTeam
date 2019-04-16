using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Interfaces
{
    public interface IImageHandler
    {
        Task<IActionResult> UploadImage(IFormFile file);

        Task<string> UploadImagePath(IFormFile file);
    }
}
