using Microsoft.AspNetCore.Mvc;
using TAREA.Models;

namespace TAREA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private readonly EmpresaContext _context;

        public ClientesController(EmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarUsuarios")]
        public ActionResult<List<Cliente>> ListarClientes()
        {
            return _context.Clientes.ToList();
        }
        [HttpGet("ObtenerUsuario/{id}")]
        public ActionResult<Cliente> ObtenerUsuario(int id)
        {
            return _context.Clientes.FirstOrDefault(e => e.IdClientes == id);
        }
        [HttpPost("InsertarUsuario")]
        public ActionResult InsertarUsuario(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPut("ActualizarUsuario/{id}")]
        public ActionResult ActualizarUsuario(int id, Cliente cliente)
        {
            var datos = _context.Clientes.FirstOrDefault(e => e.IdClientes == id);

            datos.Nombres = cliente.Nombres;
            datos.Apellidos = cliente.Apellidos;

            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete("EliminarUsuario/{id}")]
        public ActionResult EliminarUsuario(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(e => e.IdClientes == id);

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok();
        }
    }
}
