using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models.Contexto;
using WebApplication1.Models.Entidades;

namespace WebApplication1.Controllers
{
    public class LivrosController : Controller
    {

        private readonly Contexto _contexto;

        public LivrosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var lista = _contexto.Livros.ToList();
            CarregaTipo();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var livro = new Livros();
            CarregaTipo();
            return View(livro);
        }

        [HttpPost]
        public IActionResult Create(Livros livro)
        {
            if (ModelState.IsValid)
            {
                _contexto.Livros.Add(livro);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }

            CarregaTipo();
            return View(livro);
        }
        
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var livro = _contexto.Livros.Find(Id);

            CarregaTipo();
            return View(livro);
        }

        [HttpPost]
        public IActionResult Edit(Livros livro)
        {
            if (ModelState.IsValid)
            {
                _contexto.Livros.Update(livro);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                CarregaTipo();
                return View(livro);
            }
        }
        
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var livro = _contexto.Livros.Find(Id);
            CarregaTipo();
            return View(livro);
        }
        
        [HttpPost]
        public IActionResult Delete(Livros _livro)
        {
            var livro = _contexto.Livros.Find(_livro.Id);
            if (livro != null)
            {
                _contexto.Livros.Remove(livro);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(livro);
        }
        
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var livro = _contexto.Livros.Find(Id);
            CarregaTipo();
            return View(livro);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CarregaTipo()
        {
            var ItensTipo = new List<SelectListItem>
            {
                new SelectListItem{ Value ="1", Text ="Terror"},
                 new SelectListItem{ Value ="2", Text ="Romance"},
                  new SelectListItem{ Value ="3", Text ="Comédia"},
                   new SelectListItem{ Value ="4", Text ="Policial"}
            };

            ViewBag.Tipos = ItensTipo;
        }




    }
}