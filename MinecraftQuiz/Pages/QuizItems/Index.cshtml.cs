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
    public class IndexModel : PageModel
    {
        private readonly MinecraftQuiz.Models.MinecraftQuizContext _context;

        public IndexModel(MinecraftQuiz.Models.MinecraftQuizContext context)
        {
            _context = context;
        }

        public IList<QuizItem> QuizItem { get;set; }

        public async Task OnGetAsync()
        {
            QuizItem = await _context.QuizItem.ToListAsync();
        }
    }
}
