using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaryvetLogisticSupport.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FaryvetLogisticSupport.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportesController : Controller
    {
        private readonly ApplicationDbContext context;

        public ReportesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{fechaInicio:DateTime}/{fechaFinal:DateTime}")]
        public async Task<ActionResult<object>> Get(DateTime fechaInicio, DateTime fechaFinal)
        {
            object obj = await context.FLS_Entregas
                .Where(x => x.fechaSalida >= fechaInicio && 
                x.fechaLlegada <= fechaFinal &&
                x.estado == "Entrega Finalizada")
                .GroupBy(x => x.chofer)
                .Select(g => new { chofer = g.Key, 
                    peso = g.Sum(i => i.peso), 
                    costo = g.Sum(i => i.costo), 
                    kilometrajeRecorrido = g.Sum(i => i.kilometrajeLlegada) - g.Sum(i => i.kilometrajeSalida),
                    cantidadEntregas = g.Count()})
                .ToListAsync();
            return obj;
        }
    }
}
