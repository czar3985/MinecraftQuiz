using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinecraftQuiz.Models
{
    public class QuizItem
    {
        public int ID { get; set; }

        [StringLength(250, MinimumLength = 3)]
        [Required]
        public string Question { get; set; }

        [StringLength(60)]
        [Required]
        public string Answer { get; set; }
    }
}
