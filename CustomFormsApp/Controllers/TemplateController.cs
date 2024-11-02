using CustomFormsApp.Db_Context;
using CustomFormsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomFormsApp.Controllers
{
    public class TemplateController : Controller
    {
        private readonly AppDbContext _context;

        public TemplateController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var templates = _context.Templates.ToList();
            return View(templates);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Template model)
        {
            if (ModelState.IsValid)
            {
                _context.Templates.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var template = _context.Templates.Find(id);
            if (template == null) return NotFound();
            return View(template);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Template template)
        {
            if (ModelState.IsValid)
            {
                _context.Templates.Update(template);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(template);
        }


        public IActionResult Delete(int id)
        {
            var template = _context.Templates.Find(id);
            return View(template);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var template = await _context.Templates.FindAsync(id);
            _context.Templates.Remove(template);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

