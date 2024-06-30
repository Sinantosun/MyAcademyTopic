using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.WebUI.Dtos.QuestionDtos
{
    public class UpdateQuestionDto
    {
        public int QuestionsID { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
    }
}
