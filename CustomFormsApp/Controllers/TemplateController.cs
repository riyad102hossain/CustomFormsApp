using CustomFormsApp.Db_Context;
using CustomFormsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomFormsApp.Controllers
{
    public class TemplateController : Controller
    {
        private readonly AppDbContext _context;

        public TemplateController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult AddQuestion(int templateId)
        {
            ViewData["TemplateId"] = templateId;
            return View(new Question { TemplateId = templateId });
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new { id = question.TemplateId });
            }
            return View(question);
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
        public async Task<IActionResult> Edit(int id)
        {
            var template = await _context.Templates
                .Include(t => t.Questions)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (template == null) return NotFound();
            return View(template);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Template template)
        {
            if (ModelState.IsValid)
            {
                _context.Templates.Update(template);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(template);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var template = await _context.Templates.FindAsync(id);
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
