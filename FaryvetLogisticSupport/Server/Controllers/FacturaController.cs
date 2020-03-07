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
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext context;

        public FacturaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task <ActionResult <List <Factura>>> Get ()
        {
            Console.WriteLine (":-D");
            return await context.FLS_Facturas.ToListAsync ();
        }

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

        [HttpGet("/Entregas")]
        public async Task<ActionResult<List<Factura>>> GetFromEntregas ()
        {
            return await context.FLS_Facturas.Where(F => F.formaDespacho == "CAMION" && F.estado == "Por Despachar").ToListAsync();
        }

        [HttpGet("/Entregas/{id:int}")]
        public async Task<ActionResult<List<Factura>>> GetFromEntregas(int id)
        {
            return await context.FLS_Facturas.Where(x => x.entrega == id).ToListAsync();
        }

        [HttpGet("/AdvanceSearch/{Id}")]
        public async Task <ActionResult <List <Factura>>> GetFromAdvanceSearch (string Id)
        {   Console.WriteLine (Id);
            return await context.FLS_Facturas/*.Where (X => X.entrega == 1)*/.ToListAsync ();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Factura factura)
        {
            context.Entry(factura).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Factura factura)
        {
            context.Add(factura);
            await context.SaveChangesAsync();
            return NoContent();
        }

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
