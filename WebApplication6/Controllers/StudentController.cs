using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using WebApplication1.DB;
//using WebApplication6.cqrs.Material;
using WebApplication6.cqrs.Student;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [HttpGet("ListStudent/{id}")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> ListStudent(int id)
        {
            // 1. экземпляр команды 
            var command = new ListStudentByGroupIndexCommand { IndexGroup1 = id };
            // 2. отправили команду на обработку в медиатор
            // 3. медиатор нашел обработчик, передал туда команду, получил результат
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }
        [HttpGet("InfoStudentGender/{gender}")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> InfoStudentGender(int gender)
        {
            var command = new ListStudentGender { IndexGroup2 = gender };
            var result = await mediator.SendAsync(command);

            return Ok(result);
        }
        [HttpGet("InfoStudentGroupNull")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> InfoStudentGroupNull(int GroupNull)
        {
            var command = new InfoStudentGroupNull { IndexGroup3 = GroupNull };
            var result = await mediator.SendAsync(command);

            return Ok(result);
        }

    }
}
