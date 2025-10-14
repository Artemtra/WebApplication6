using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using WebApplication1.DB;
//using WebApplication6.cqrs.Material;
using WebApplication6.cqrs.Student;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Mediator mediator;
        public StudentController(Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("ListGenders{id}")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> ListGenders(int id)
        {
            // 1. экземпляр команды 
            var command = new ListStudentByGroupIndexCommand {  IndexGroup = id};
            // 2. отправили команду на обработку в медиатор
            // 3. медиатор нашел обработчик, передал туда команду, получил результат
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

    }
}
