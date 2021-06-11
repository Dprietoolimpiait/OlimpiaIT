using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OlimpiaIT.Punto1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiaIT.Punto1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static string[] extensiones = new string[] { ".txt", ".csv" };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(IFormFile file)
        {
            if (file.Length > 0)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!extensiones.Contains(extension))
                {
                    ViewBag.Error = "Extension no permitida";
                    return View();
                }
                    
                var lineas = await this.ProcessFile(file);

                StringBuilder response = new StringBuilder();

                lineas.ForEach(x => 
                {
                    byte[] digitos;
                    digitos = Array.ConvertAll(x.ToCharArray(), c => 
                    { 
                        byte valor = 0;

                        byte.TryParse(c.ToString(), out valor);

                        return valor;
                    });

                    if (digitos.Sum(x => x) % 3 == 0)
                        response.AppendLine("SI");
                    else
                        response.AppendLine("NO");
                });

                return File(Encoding.UTF8.GetBytes(response.ToString()), "text/txt", "respuesta.txt");
            }

            ViewBag.Error = "El archivo no tiene información";
            return View();
        }

        private async Task<List<string>> ProcessFile(IFormFile file) 
        {
            var result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.Add(await reader.ReadLineAsync());
            }
            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
