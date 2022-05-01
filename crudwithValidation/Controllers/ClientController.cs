using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudwithValidation.Models;

namespace crudwithValidation.Controllers
{
    public class ClientController : Controller
    {
        private ClientDbContext dbContext;

        public ClientController(ClientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Client> cli = dbContext.Clients.ToList();

            return View(cli);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Client cli)
        {
            if (ModelState.IsValid)
            {
                dbContext.Clients.Add(cli);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(cli);
            }
        }

        public IActionResult Delete(int Id)
        {
            var cli = dbContext.Clients.SingleOrDefault(e => e.Id == Id);
            if(cli!=null)
            {
                dbContext.Clients.Remove(cli);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }

        public IActionResult Edit(int Id)
        {
            var cli = dbContext.Clients.SingleOrDefault(e => e.Id == Id);

            return View(cli);
        }
        [HttpPost]
        public IActionResult Edit(Client cli)
        {
            dbContext.Clients.Update(cli);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
          
        }

    }
}
