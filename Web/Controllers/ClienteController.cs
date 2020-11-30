using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Database;

namespace Web.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            var aplicacao = new Aplicacao();
            var ListClientes = aplicacao.SelectClientes();
            return View(ListClientes);
        }
        public ActionResult Create(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new Aplicacao();
                aplicacao.InsertOrUpdate(clientes);                
            } else
            {
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var aplicacao = new Aplicacao();
                var cliente = aplicacao.SelectIdClientes(id);
                return View(cliente);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult Edit(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new Aplicacao();
                aplicacao.InsertOrUpdate(clientes);
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View(clientes);
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new Aplicacao();
                aplicacao.DeleteClientes(id);
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }

}
