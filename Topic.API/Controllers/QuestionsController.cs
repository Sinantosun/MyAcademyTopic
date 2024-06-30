using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinnesLayer.Abstract;
using Topic.DtoLayer.QuestionDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionsService;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionService questionsService, IMapper mapper)
        {
            _questionsService = questionsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllQuestionss()
        {
            var values = _questionsService.TGetList();
            var questions = _mapper.Map<List<ResultQuestionDto>>(values);
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestionsById(int id)
        {
            var value = _questionsService.TGetById(id);
            var questions = _mapper.Map<ResultQuestionDto>(value);
            return Ok(questions);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestions(int id)
        {
            _questionsService.TDelete(id);
            return Ok("Kayıt Silindi");
        }

        [HttpPost]
        public IActionResult CreateQuestions(CreateQuestionDto model)
        {
            var questions = _mapper.Map<Questions>(model);
            _questionsService.TCreate(questions);
            return Ok("Kayıt eklendi");
        }

        [HttpPut]
        public IActionResult UpdateQuestions(UpdateQuestionDto model)
        {
            var questions = _mapper.Map<Questions>(model);
            _questionsService.TUpdate(questions);
            return Ok("Kayıt Güncellendi");
        }
    }
}
