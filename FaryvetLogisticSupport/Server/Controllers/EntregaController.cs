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
    [ApiController]
    [Route("[controller]")]
    public class EntregaController : Controller
    {
        private readonly ApplicationDbContext context;
        public EntregaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Entrega entrega)
        {
            context.Add(entrega);
            await context.SaveChangesAsync();
            return NoContent();
            //return new CreatedAtRouteResult("obtenerEntrega", new { id = entrega.id }, entrega);
        }

        [HttpGet("{id}", Name = "obtenerEntrega")]
        public async Task<ActionResult<Entrega>> Get(int id)
        {
            return await context.FLS_Entregas.FirstOrDefaultAsync(x => x.id == id);
        }

        [HttpGet("{fechaSalida:DateTime}")]
        public async Task<ActionResult<Entrega>> Get(DateTime fechaSalida)
        {
            List<Entrega> entregas = await context.FLS_Entregas.Where(x => x.fechaSalida == fechaSalida).ToListAsync();
            entregas = entregas.OrderBy(x => x.id).ToList();
            return entregas.LastOrDefault();
        }
    }
}
