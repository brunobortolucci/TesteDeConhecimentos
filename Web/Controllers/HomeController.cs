using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Database;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var aplicacao = new Aplicacao();
            var ListClientes = aplicacao.SelectClientes();
            return View(ListClientes);
        }
    }
}
