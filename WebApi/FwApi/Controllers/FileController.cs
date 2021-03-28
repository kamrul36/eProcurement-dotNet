using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FwApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly AppDataDbContext _context;
        private IHostingEnvironment henv;

        public FileController(AppDataDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            henv = hostingEnvironment;
        }
        [HttpPost]
        [Route("PostFile")]
        public async Task<IActionResult> PostFile(IFormFile file, int TendersId)
        {
            if (file == null || file.Length == 0) return Content("File not selected");

            string path_root = henv.WebRootPath;
            string path_to_Image = path_root + "\\UploadFile\\" + file.FileName;

            using (var stream = new FileStream(path_to_Image, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TenderFile tf = new TenderFile();
            tf.FileName = file.FileName;
            tf.FilePath = path_to_Image;
            _context.TenderFiles.Add(tf);
            _context.SaveChanges();
            return Ok("Upload File successful");
        }
    }
}
