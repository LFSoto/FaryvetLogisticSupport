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
    public class ConductorController : Controller
    {
        private readonly ApplicationDbContext context;

        public ConductorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Conductor>>> Get()
        {
            return await context.FLS_Conductores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Conductor conductor)
        {
            context.Add(conductor);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerConductor", new { cedula = conductor.cedula }, conductor);
        }

        [HttpGet("{cedula}", Name = "obtenerConductor")]
        public async Task<ActionResult<Conductor>> Get(string cedula)
        {
            return await context.FLS_Conductores.FirstOrDefaultAsync(x => x.cedula == cedula);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Conductor conductor)
        {
            context.Entry(conductor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

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
