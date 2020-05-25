using Microsoft.AspNetCore.Mvc;
using eCommerceCrud.Models;
using System.Linq;

namespace eCommerceCrud.Controllers
{
    [Route("produto")]
    public class ProdutoController : Controller
    {
        private DataContext db = new DataContext();
        
        [Route("produto")]
        [Route("index")]
        [Route("~/")]

        public IActionResult Index()
        {
            ViewBag.produtos = db.Produtos.ToList();
            return View();
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        { 
            return View("Add");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            db.Produtos.Remove(db.Produtos.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Edite/{id}")]
        public IActionResult Edite(string id)
        {
            return View("Edite", db.Produtos.Find(id));
        }

        [HttpPost]
        [Route("Edite/{id}")]
        public IActionResult Edite(Produto produto)
        {
            db.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}