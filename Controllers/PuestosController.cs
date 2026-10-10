using Microsoft.AspNetCore.Mvc;
using TAREA.Models;

namespace TAREA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuestosController : Controller
    {
        private readonly EmpresaContext _context;

        public PuestosController(EmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarPuestos")]
        public ActionResult<List<Puesto>> ListarPuestos()
        {
            return _context.Puestos.ToList();
        }

        [HttpGet("ObtenerPuesto/{id}")]
        public ActionResult<Puesto> ObtenerPuesto(int id)
        {
            return _context.Puestos.FirstOrDefault(e => e.IdPuesto == id);
        }

        [HttpPost("InsertarPuesto")]
        public ActionResult InsertarPuesto(Puesto puesto)
        {
            _context.Puestos.Add(puesto);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("ActualizarPuesto/{id}")]
        public ActionResult ActualizarPuesto(int id, Puesto puesto)
        {
            var datos = _context.Puestos.FirstOrDefault(e => e.IdPuesto == id);

            datos.Nombre = puesto.Nombre;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("EliminarPuesto/{id}")]
        public ActionResult EliminarPuesto(int id)
        {
            var puesto = _context.Puestos.FirstOrDefault(e => e.IdPuesto == id);

            _context.Puestos.Remove(puesto);
            _context.SaveChanges();

            return Ok();
        }
    }
}
