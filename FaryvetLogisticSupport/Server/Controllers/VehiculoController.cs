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
    [ApiController]
    [Route("[controller]")]
    public class VehiculoController : Controller
    {
        private readonly ApplicationDbContext context;
        /// <summary>
        /// Constructor de la clase. Inicializa el context con el valor <paramref name="context"/>.
        /// </summary>
        /// <param name="context">Context para la inicializacion del Controller de Vehiculos.</param>
        public VehiculoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Funcion que devuelve todos los vehiculos de la base de datos.
        /// </summary>
        /// <returns>Devuelve los vehiculos.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Vehiculo>>> Get()
        {
            return await context.FLS_Vehiculos.ToListAsync();
        }
        /// <summary>
        /// Funcion que agrega un nuevo vehiculo a la base de datos.
        /// </summary>
        /// <param name="vehiculo">Nuevo vehiculo entrante a la base de datos.</param>
        /// <returns>Devuelve el vehiculo nuevo, buscando por placa.</returns>
        [HttpPost]
        public async Task<ActionResult> Post(Vehiculo vehiculo)
        {
            context.Add(vehiculo);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerVehiculo", new { placa = vehiculo.placa }, vehiculo);
        }
        /// <summary>
        /// Funcion que devuelve un vehiculo segun la <paramref name="placa"/>.
        /// </summary>
        /// <param name="placa">Identificador del vehiculo.</param>
        /// <returns>Devuelve el vehiculo segun la placa.</returns>
        [HttpGet("{placa}", Name = "obtenerVehiculo")]
        public async Task<ActionResult<Vehiculo>> Get(string placa)
        {
            return await context.FLS_Vehiculos.FirstOrDefaultAsync(x => x.placa == placa);
        }
        /// <summary>
        /// Funcion que devuelve una lista de vehiculos de reparto y si estan disponibles al momento.
        /// </summary>
        /// <param name="isEntrega">Valor booleano para filtar los vehiculos de reparto.</param>
        /// <returns>Devuelve una lista de vehiculos.</returns>
        [HttpGet("{isEntrega:bool}")]
        public async Task<ActionResult<List<Vehiculo>>> Get(bool isEntrega)
        {           
            return await context.FLS_Vehiculos.Where(x=> x.isReparto == isEntrega && x.estado == "Disponible").ToListAsync();
        }
        /// <summary>
        /// Funcion que actualiza un vehiculo. 
        /// </summary>
        /// <param name="vehiculo">Objeto de tipo vehiculo.</param>
        /// <returns>Retorna HTTP status 204.</returns>
        [HttpPut]
        public async Task<ActionResult> Put(Vehiculo vehiculo)
        {
            context.Entry(vehiculo).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// Funcion que elimina un vehiculo segun la placa.
        /// </summary>
        /// <param name="id">Placa del vehiculo.</param>
        /// <returns>Retorna HTTP status 204.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var vehiculo = new Vehiculo { placa = id };
            context.Remove(vehiculo);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
