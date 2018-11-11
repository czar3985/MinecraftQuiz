using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinecraftQuiz.Models;

namespace MinecraftQuiz.Pages.QuizItems
{
    public class EditModel : PageModel
    {
        private readonly MinecraftQuiz.Models.MinecraftQuizContext _context;

        public EditModel(MinecraftQuiz.Models.MinecraftQuizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public QuizItem QuizItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuizItem = await _context.QuizItems.FirstOrDefaultAsync(m => m.ID == id);

            if (QuizItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(QuizItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizItemExists(QuizItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuizItemExists(int id)
        {
            return _context.QuizItems.Any(e => e.ID == id);
        }
    }
}
