using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinecraftQuiz.Models;

namespace MinecraftQuiz.Pages.QuizItems
{
    public class CreateModel : PageModel
    {
        private readonly MinecraftQuiz.Models.MinecraftQuizContext _context;

        public CreateModel(MinecraftQuiz.Models.MinecraftQuizContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public QuizItem QuizItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.QuizItems.Add(QuizItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}