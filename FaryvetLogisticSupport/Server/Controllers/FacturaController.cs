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
    /// Clase FacturaController.
    /// Controlador para los objectos de tipo Factura.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext context;
        /// <summary>
        /// Constructor de la clase. Inicializa el context con el valor <paramref name="context"/>.
        /// </summary>
        /// <param name="context">Context para la inicializacion del Controller de Factura.</param>
        public FacturaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Funcion que devuelve la lista de todas las facturas en la base de datos.
        /// </summary>
        /// <returns>Devuelve la lista de las facturas.</returns>
        [HttpGet]
        public async Task <ActionResult <List <Factura>>> Get ()
        {
            Console.WriteLine (":-D");
            return await context.FLS_Facturas.ToListAsync ();
        }
        /// <summary>
        /// Funcion que devuelve una lista de facturas en base a ciertas condiciones.
        /// </summary>
        /// <param name="sDSF">sDSF</param>
        /// <param name="sDS">sDF</param>
        /// <param name="eDSF">eDSF</param>
        /// <param name="eDS">eDS</param>
        /// <returns>Devuelve una lista de facturas.</returns>
        [HttpGet("{sDSF:bool}/{sDS:DateTime}/{eDSF:bool}/{eDS:DateTime}")]
        public async Task <ActionResult <List <Factura>>> Get (bool sDSF, DateTime sDS, bool eDSF, DateTime eDS)
        {
            if (sDSF && !eDSF)
            {
                return await context.FLS_Facturas.Where (F=> F.fecha >= sDS).ToListAsync ();
            }
            if (!sDSF && eDSF)
            {
                return await context.FLS_Facturas.Where (F=> F.fecha <= eDS).ToListAsync ();
            }
            if (sDSF && eDSF)
            {
                return await context.FLS_Facturas.Where (F=> F.fecha >= sDS && F.fecha <= eDS).ToListAsync ();
            }
            else
            {
                return await context.FLS_Facturas.ToListAsync ();
            }
        }
        /// <summary>
        /// Funcion que devuelve una lista de facturas en base a ciertas condiciones.
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="sDSF">sDSF</param>
        /// <param name="sDS">sDF</param>
        /// <param name="eDSF">eDSF</param>
        /// <param name="eDS">eDS</param>
        /// <returns>Devuelve una lista de facturas.</returns>
        [HttpGet("{Id}/{sDSF:bool}/{sDS:DateTime}/{eDSF:bool}/{eDS:DateTime}")]
        public async Task <ActionResult <List <Factura>>> Get ( string Id, bool sDSF, DateTime sDS, bool eDSF, DateTime eDS)
        {
            if (sDSF && !eDSF)
            {
                return await context.FLS_Facturas.Where (X=> X.id== Id && X.fecha >= sDS).ToListAsync ();
            }
            if (!sDSF && eDSF)
            {
                return await context.FLS_Facturas.Where (X=> X.id== Id && X.fecha <= eDS).ToListAsync ();
            }
            if (sDSF && eDSF)
            {
                return await context.FLS_Facturas.Where (X=> X.id == Id && X.fecha >= sDS && X.fecha <= eDS).ToListAsync ();
            }
            else
            { 
                return await context.FLS_Facturas.Where (X=> X.id== Id).ToListAsync ();
            }
        }
        /// <summary>
        /// Funcion que devuelve todas las facturas que su forma de despacho sea 'Camion' y su estado esté por despachar.
        /// </summary>
        /// <returns>Devuelve una lista de facturas.</returns>
        [HttpGet("/Entregas")]
        public async Task<ActionResult<List<Factura>>> GetFromEntregas ()
        {
            return await context.FLS_Facturas.Include(x => x.DivisionGeograficaNavigation).Where(F => F.formaDespacho == "CAMION" && F.estado == "Por Despachar").ToListAsync();
        }
        /// <summary>
        /// Funcion que devuelve las facturas asociadas con el <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Id de la entrega</param>
        /// <returns>Devuelve la lista de facturas por una entrega especifica.</returns>
        [HttpGet("/Entregas/{id:int}")]
        public async Task<ActionResult<List<Factura>>> GetFromEntregas(int id)
        {
            return await context.FLS_Facturas.Include(x => x.DivisionGeograficaNavigation).Where(x => x.entrega == id).ToListAsync();
        }
        /// <summary>
        /// Funcion que devuelve una lista de facturas segun el id.
        /// </summary>
        /// <param name="Id">Id de la factura</param>
        /// <returns>Devuelve la lista de facturas seun el id.</returns>
        [HttpGet("/AdvanceSearch/{Id}")]
        public async Task <ActionResult <List <Factura>>> GetFromAdvanceSearch (string Id)
        {   Console.WriteLine (Id);
            return await context.FLS_Facturas/*.Where (X => X.entrega == 1)*/.ToListAsync ();
        }
        /// <summary>
        /// Funcion que actualiza una factura.
        /// </summary>
        /// <param name="factura">Factura actualizada.</param>
        /// <returns>Retorna HTTP status 204.</returns>
        [HttpPut]
        public async Task<ActionResult> Put(Factura factura)
        {
            context.Entry(factura).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// Funcion que agrega una nueva factura a la base de datos.
        /// </summary>
        /// <param name="factura">Nueva factura.</param>
        /// <returns>Retorna HTTP status 204</returns>
        [HttpPost]
        public async Task<ActionResult> Post(Factura factura)
        {
            context.Add(factura);
            await context.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// Funcion que elimina una factura de la base de datos segun el id.
        /// </summary>
        /// <param name="id">Id de la fatura.</param>
        /// <returns>Retorna HTTP status 204</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var factura = new Factura { id = id };
            context.Remove(factura);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
