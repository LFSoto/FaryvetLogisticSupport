using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaryvetLogisticSupport.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FaryvetLogisticSupport.Server.Controllers
{
    /// <summary>
    /// Clase ConductorController.
    /// Controlador para los objectos de tipo Conductor.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ConductorController : Controller
    {
        private readonly ApplicationDbContext context;
        /// <summary>
        /// Constructor de la clase. Inicializa el context con el valor <paramref name="context"/>.
        /// </summary>
        /// <param name="context">Context para la inicializacion del Controller de Conductor.</param>
        public ConductorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Funcion que devuelve toda la lista de Conductores. 
        /// </summary>
        /// <returns>Devuelve toda la lista de Conductores en la base de datos.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Conductor>>> Get()
        {
            return await context.FLS_Conductores.ToListAsync();
        }
        /// <summary>
        /// Devuleve la lista de Conductores que cumplan con el requisito <paramref name="isDisponible"/>
        /// </summary>
        /// <param name="isDisponible">Estado de disponibilidad del conductor.</param>
        /// <returns>Devuelve una lista de los conductores disponibles si <paramref name="isDisponible"/> es true. Caso contrario, una
        /// lista de los conductores sin disponibilidad.</returns>
        [HttpGet("{isDisponible:bool}")]
        public async Task<ActionResult<List<Conductor>>> Get(bool isDisponible)
        {
            return await context.FLS_Conductores.Where(x => x.estado == "Disponible").ToListAsync();
        }
        /// <summary>
        /// Agrega un conductor nuevo a la base de datos.
        /// </summary>
        /// <param name="conductor">Objeto de tipo Conductor.</param>
        /// <returns>Devuelve el nuevo Conductor.</returns>
        [HttpPost]
        public async Task<ActionResult> Post(Conductor conductor)
        {
            context.Add(conductor);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerConductor", new { cedula = conductor.cedula }, conductor);
        }
        /// <summary>
        /// Devuelve un Conductor segun <paramref name="cedula"/>.
        /// </summary>
        /// <param name="cedula">Cedula del conductor.</param>
        /// <returns>Devuelve el objeto de tipo Conductor que coincide con la cedula por parametro.</returns>
        [HttpGet("{cedula}", Name = "obtenerConductor")]
        public async Task<ActionResult<Conductor>> Get(string cedula)
        {
            return await context.FLS_Conductores.FirstOrDefaultAsync(x => x.cedula == cedula);
        }

        ///<summary>
        /// Actualiza un conductor de la base de datos. Este recibe como parametro el valor de <paramref name="conductor"/>
        /// </summary> 
        /// <param name="conductor">Objeto de tipo Conductor.</param>
        /// <returns>Retorna HTTP status 204.</returns>
        [HttpPut]
        public async Task<ActionResult> Put(Conductor conductor)
        {
            context.Entry(conductor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        ///<summary>
        /// Elimina un conductor de la base de datos a traves de la cedula.
        /// </summary> 
        /// <param name="cedul">Cedula del conductor</param>
        /// <returns>Retorna HTTP status 204</returns>
        [HttpDelete("{cedul}")]
        public async Task<ActionResult> Delete(string cedul)
        {
            var conductor = new Conductor { cedula = cedul };
            context.Remove(conductor);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
