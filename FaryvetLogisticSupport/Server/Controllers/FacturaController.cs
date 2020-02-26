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
            return await context.FLS_Facturas.ToListAsync ();
        }

        [HttpGet("/Entregas")]
        public async Task<ActionResult<List<Factura>>> GetFromEntregas ()
        {
            return await context.FLS_Facturas.Where(F => F.formaDespacho == "CAMION" && F.estado == "Por Despachar").ToListAsync();
        }

        [HttpGet("/AdvanceSearch")]
        public async Task <ActionResult <List <Factura>>> Get ([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var queryable= context.FLS_Facturas.AsQueryable ();

            queryable= queryable.Where (F => F.fecha >= startDate && F.fecha <= endDate);
            return await queryable.ToListAsync ();

            //return await context.FLS_Facturas.Where (F => F.fecha >= startDate && F.fecha <= endDate).ToListAsync ();
        }
    }
}
