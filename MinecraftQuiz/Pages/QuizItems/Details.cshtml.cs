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
    public class DetailsModel : PageModel
    {
        private readonly MinecraftQuiz.Models.MinecraftQuizContext _context;

        public DetailsModel(MinecraftQuiz.Models.MinecraftQuizContext context)
        {
            _context = context;
        }

        public QuizItem QuizItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuizItem = await _context.QuizItem.FirstOrDefaultAsync(m => m.ID == id);

            if (QuizItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
