using Microsoft.AspNetCore.Mvc;
using PropuestasLegislativas.Models;
using System.Text.Json;


namespace PropuestasLegislativas.Controllers
{
    public class PropuestasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EnviarPropuesta([FromBody] JsonElement modelo)
        {
            var json = JsonSerializer.Serialize(modelo);
            EscritorJson escritor = new EscritorJson();
            ModeloPropuestaLegislativa modeloPropuesta = JsonSerializer.Deserialize<ModeloPropuestaLegislativa>(json);
            bool estado = escritor.escribir(modeloPropuesta);
            return Json(estado);
        }

        public ActionResult Confirmacion()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
