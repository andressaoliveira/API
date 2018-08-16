using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conexao.Models;

namespace Conexao.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var appPessoa = new Pessoa();
            var listaConcorrentes = appPessoa.Mostrar();
            return View(listaConcorrentes);
            //Pessoa pessoa = new Pessoa { Nome = "João" };
            // return View("Index", pessoa);
        }

        public ActionResult Lista(string Nome, string Cor)
        {
            ViewData["Nome"] = Nome;
            ViewData["Cor"] = Cor;
            return View("Lista");
        }

        public ActionResult Sobre()
        {
            return View("Sobre");
        }

        public ActionResult Cadastrar()
        {
            var appConcorrente = new Pessoa();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Cadastrar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                var appConcorrente = new Pessoa();
                appConcorrente.Insert(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        public ActionResult Update(Pessoa pessoa)
        {
            pessoa = pessoa.Details(pessoa.Id);
            //var appConcorrente = new Pessoa();
            return View(pessoa);
        }
        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateConfirm(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                var appConcorrente = new Pessoa();
                appConcorrente.Update(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }


        public ActionResult Delete(Pessoa pessoa)
        {
            pessoa = pessoa.Details(pessoa.Id);
            return View(pessoa);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(Pessoa pessoa)
        {
            var appConcorrente = new Pessoa();
            appConcorrente.Delete(pessoa);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            var appPessoa = new Pessoa();
            //var listaConcorrentes = 
            appPessoa = appPessoa.Details(id);
            return View(appPessoa);
        }
    }
}