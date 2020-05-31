using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaryvetLogisticSupport.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FaryvetLogisticSupport.Server.Controllers
{
    /// <summary>
    /// Clase EntregaController.
    /// Controlador para los objectos de tipo Entrega.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EntregaController : Controller
    {
        private readonly ApplicationDbContext context;
        /// <summary>
        /// Constructor de la clase. Inicializa el context con el valor <paramref name="context"/>.
        /// </summary>
        /// <param name="context">Context para la inicializacion del Controller de Entrega.</param>
        public EntregaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Funcion que agrega una nueva entrega.
        /// </summary>
        /// <param name="entrega">Entrega que se agrega a la base de datos.</param>
        /// <returns>Retorna HTTP status 204.</returns>
        [HttpPost]
        public async Task<ActionResult> Post(Entrega entrega)
        {
            context.Add(entrega);
            await context.SaveChangesAsync();
            return NoContent();
            //return new CreatedAtRouteResult("obtenerEntrega", new { id = entrega.id }, entrega);
        }
        /// <summary>
        /// Funcion que devuelve una entrega segun el <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Identificador necesario para la busqueda</param>
        /// <returns>Devuelve un objeto de tipo Entrega segun el ID.</returns>
        [HttpGet("{id}", Name = "obtenerEntrega")]
        public async Task<ActionResult<Entrega>> Get(int id)
        {
            return await context.FLS_Entregas.FirstOrDefaultAsync(x => x.id == id);
        }
        /// <summary>
        /// Funcion que devuleve una lista de entregas que tienen su estado como pendiente.
        /// </summary>
        /// <returns>Una lista de entregas pendientes.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Entrega>>> Get()
        {
            return await context.FLS_Entregas.Include(x => x.ConductorNavigation).Include(x => x.VehiculoNavigation).Where(x => x.estado == "Entrega Pendiente").ToListAsync();
        }
        /// <summary>
        /// Funcion que devuelve una lista ordenada de entregas segun la <paramref name="fechaSalida"/>.
        /// </summary>
        /// <param name="fechaSalida">Fecha de Salida para el filtro.</param>
        /// <returns>Devuelve una lista ordenada de entregas.</returns>
        [HttpGet("{fechaSalida:DateTime}")]
        public async Task<ActionResult<Entrega>> Get(DateTime fechaSalida)
        {
            List<Entrega> entregas = await context.FLS_Entregas.Where(x => x.fechaSalida == fechaSalida).ToListAsync();
            entregas = entregas.OrderBy(x => x.id).ToList();
            return entregas.LastOrDefault();
        }
        ///<summary>
        /// Funcion que actualiza la entrega en la base de datos. Este recibe como parametro el valor de <paramref name="entrega"/>.
        /// </summary> 
        /// <param name="entrega">Objeto de tipo Entrega.</param>
        /// <returns>Retorna HTTP status 204.</returns>
        [HttpPut]
        public async Task<ActionResult> Put(Entrega entrega)
        {
            context.Entry(entrega).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
