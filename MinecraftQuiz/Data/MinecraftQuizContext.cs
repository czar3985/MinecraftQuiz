using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MinecraftQuiz.Models
{
    public class MinecraftQuizContext : DbContext
    {
        public MinecraftQuizContext (DbContextOptions<MinecraftQuizContext> options)
            : base(options)
        {
        }

        public DbSet<MinecraftQuiz.Models.QuizItem> QuizItems { get; set; }
    }
}
