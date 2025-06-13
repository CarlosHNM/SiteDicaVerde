using Microsoft.AspNetCore.Mvc;
using DicaVerde.Models;
using System.Linq;
using DicaVerde.Context;

namespace DicaVerde.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly AppDbContext _context;

        public NoticiasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Noticias
        public IActionResult Index()
        {
            var noticias = _context.Noticias
                .OrderByDescending(n => n.DataPublicacao)
                .ToList();

            return View(noticias);
        }

        // GET: /Noticias/Detalhes/5
        public IActionResult Details(int id)
        {
            var noticia = _context.Noticias.FirstOrDefault(n => n.Id == id);
            if (noticia == null)
                return NotFound();

            // Captura da URL anterior (Referer)
            ViewBag.ReturnUrl = Request.Headers["Referer"].ToString();

            return View(noticia);
        }

    }
}
