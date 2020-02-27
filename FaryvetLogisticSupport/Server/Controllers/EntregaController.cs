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
            return new CreatedAtRouteResult("obtenerEntrega", new { id = entrega.id }, entrega);
        }

        [HttpGet("{id}", Name = "obtenerEntrega")]
        public async Task<ActionResult<Entrega>> Get(int id)
        {
            return await context.FLS_Entregas.FirstOrDefaultAsync(x => x.id == id);
        }

        [HttpGet("{final:bool}")]
        public async Task<ActionResult<Entrega>> Get(bool final)
        {
            return await context.FLS_Entregas.LastOrDefaultAsync();
        }
    }
}
