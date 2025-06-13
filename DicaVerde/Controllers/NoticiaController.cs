using DicaVerde.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DicaVerde.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly AppDbContext _context;

        public NoticiaController(AppDbContext context)
        {
            _context = context;
        }

        
        // GET: /Projetos/Details/5
        public IActionResult Details(int id)
        {
            var noticia = _context.Noticias.FirstOrDefault(n => n.Id == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

    }
}
