//using Microsoft.AspNetCore.Mvc;
//using MyMediator.Types;
//using WebApplication6.cqrs.Material;
////using WebApplication1.DB;

//namespace WebApplication6.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MaterialsController : ControllerBase
//    {
//        private readonly Mediator mediator;
//        public MaterialsController(Mediator mediator)
//        {
//            this.mediator = mediator;
//        }

//        [HttpGet("ListGenders")]
//        public async Task<ActionResult<IEnumerable<MaterialDTO>>> ListGenders(bool onlyNormal)
//        {
//            // 1. экземпляр команды 
//            var command = new GetListMaterialCommand {};
//            // 2. отправили команду на обработку в медиатор
//            // 3. медиатор нашел обработчик, передал туда команду, получил результат
//            var result = await mediator.SendAsync(command);
//            return Ok(result);
//        }


//    } 
//}
