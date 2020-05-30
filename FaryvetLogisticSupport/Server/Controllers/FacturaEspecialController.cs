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
    public class FacturaEspecialController : Controller
    {
        private readonly ApplicationDbContext context;
        /// <summary>
        /// Constructor de la clase. Inicializa el context con el valor <paramref name="context"/>.
        /// </summary>
        /// <param name="context">Context para la inicializacion del Controller de FacturaEspecial.</param>
        public FacturaEspecialController(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Funcion que devuelve una lista de faturas siempre y cuando su forma de despacho sea 'Camion'.
        /// </summary>
        /// <returns>Devuelve una lista de facturas.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Factura>>> Get()
        {
            return await context.FLS_Facturas.Where(F => F.formaDespacho == "CAMION").ToListAsync();
        }
    }
}
