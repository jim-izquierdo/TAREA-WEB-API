using Microsoft.AspNetCore.Mvc;
using TAREA.Models;

namespace TAREA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : Controller
    {
        private readonly EmpresaContext _context;

        public EmpleadosController(EmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarEmpleados")]
        public ActionResult<List<Empleado>> ListarEmpleados()
        {
            return _context.Empleados.ToList();
        }

        [HttpGet("ObtenerEmpleado/{id}")]
        public ActionResult<Empleado> ObtenerEmpleado(int id)
        {
            return _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id);
        }

        [HttpPost("InsertarEmpleado")]
        public ActionResult InsertarEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("ActualizarEmpleado/{id}")]
        public ActionResult ActualizarEmpleado(int id, Empleado empleado)
        {
            var datos = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id);

            datos.IdPuesto = empleado.IdPuesto;
            datos.Nombre = empleado.Nombre;
            datos.Apellidos = empleado.Apellidos;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("EliminarEmpleado/{id}")]
        public ActionResult EliminarEmpleado(int id)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id);

            _context.Empleados.Remove(empleado);
            _context.SaveChanges();

            return Ok();
        }
    }
}
