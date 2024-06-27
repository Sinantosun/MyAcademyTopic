using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinnesLayer.Abstract;
using Topic.DtoLayer.ManuelDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManuelsController : ControllerBase
    {
        private readonly IManuelService _manuelService;
        private readonly IMapper _mapper;

        public ManuelsController(IManuelService manuelService, IMapper mapper)
        {
            _manuelService = manuelService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllManuels()
        {
            var values = _manuelService.TGetList();
            var categories = _mapper.Map<List<ResultManuelDto>>(values);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetManuelById(int id)
        {
            var value = _manuelService.TGetById(id);
            var Manuel = _mapper.Map<ResultManuelDto>(value);
            return Ok(Manuel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteManuel(int id)
        {
            _manuelService.TDelete(id);
            return Ok("Kayıt Silindi");
        }

        [HttpPost]
        public IActionResult CreateManuel(CreateManuelDto model)
        {
            var Manuel = _mapper.Map<Manuel>(model);
            _manuelService.TCreate(Manuel);
            return Ok("Kayıt eklendi");
        }

        [HttpPut]
        public IActionResult UpdateManuel(UpdateManuelDto model)
        {
            var Manuel = _mapper.Map<Manuel>(model);
            _manuelService.TUpdate(Manuel);
            return Ok("Kayıt Güncellendi");
        }
    }
}
