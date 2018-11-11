using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MinecraftQuiz.Models;

namespace MinecraftQuiz.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizApiController : ControllerBase
    {
        private readonly MinecraftQuiz.Models.MinecraftQuizContext _context;

        public QuizApiController(MinecraftQuizContext context)
        {
            _context = context;
        }

        // GET: api/QuizApi
        [HttpGet]
        public ActionResult<List<QuizItem>> GetAll()
        {
            return _context.QuizItems.ToList();
        }
    }
}
