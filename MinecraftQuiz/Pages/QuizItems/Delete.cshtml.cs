using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MinecraftQuiz.Models;

namespace MinecraftQuiz.Pages.QuizItems
{
    public class DeleteModel : PageModel
    {
        private readonly MinecraftQuiz.Models.MinecraftQuizContext _context;

        public DeleteModel(MinecraftQuiz.Models.MinecraftQuizContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuizItem = await _context.QuizItems.FindAsync(id);

            if (QuizItem != null)
            {
                _context.QuizItems.Remove(QuizItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
