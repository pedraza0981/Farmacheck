using Microsoft.AspNetCore.Mvc;
using Farmacheck.Models;
using System.Collections.Generic;
using System.Linq;

namespace Farmacheck.Controllers
{
    public class MarcaController : Controller
    {
        private static readonly List<Marca> _marcas = new();
        private static int _nextId = 1;

        public IActionResult Index(int unidadId)
        {
            ViewBag.UnidadId = unidadId;
            var lista = _marcas.Where(m => m.UnidadDeNegocioId == unidadId).ToList();
            return View(lista);
        }

        [HttpGet]
        public JsonResult Listar(int unidadId)
        {
            var lista = _marcas.Where(m => m.UnidadDeNegocioId == unidadId).ToList();
            return Json(new { success = true, data = lista });
        }

        [HttpGet]
        public JsonResult Obtener(int id)
        {
            var entidad = _marcas.FirstOrDefault(x => x.Id == id);
            if (entidad == null)
                return Json(new { success = false, error = "No encontrado" });

            return Json(new { success = true, data = entidad });
        }

        [HttpPost]
        public JsonResult Guardar([FromBody] Marca model)
        {
            if (string.IsNullOrWhiteSpace(model.Nombre))
                return Json(new { success = false, error = "El nombre es obligatorio." });

            if (model.Id == 0)
            {
                model.Id = _nextId++;
                _marcas.Add(model);
            }
            else
            {
                var existente = _marcas.FirstOrDefault(x => x.Id == model.Id);
                if (existente == null)
                    return Json(new { success = false, error = "No encontrado" });

                existente.Nombre = model.Nombre;
                existente.Logotipo = model.Logotipo;
                existente.UnidadDeNegocioId = model.UnidadDeNegocioId;
            }

            return Json(new { success = true, id = model.Id });
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            var entidad = _marcas.FirstOrDefault(x => x.Id == id);
            if (entidad == null)
                return Json(new { success = false, error = "No encontrado" });

            _marcas.Remove(entidad);
            return Json(new { success = true });
        }
    }
}
