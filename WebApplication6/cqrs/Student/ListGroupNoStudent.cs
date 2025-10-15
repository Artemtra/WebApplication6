//using MyMediator.Interfaces;
//using WebApplication1.DB;
//using WebApplication6.cqrs.Student;
//using Microsoft.EntityFrameworkCore;

//namespace WebApplication6.cqrs.Group
//{
//    public class ListGroupNoStudent : IRequest<IEnumerable<StudentDTO>>
//    {
//        public int IndexGroup4 { get; set; }
//        public class ListStudentByGroupIndexCommandHandler :
//            IRequestHandler<ListGroupNoStudent, IEnumerable<StudentDTO>>
//        {

//            private readonly Db131025Context db;
//            public ListStudentByGroupIndexCommandHandler(Db131025Context db)
//            {
//                this.db = db;
//            }
//            public async Task<IEnumerable<StudentDTO>> HandleAsync(ListGroupNoStudent request,
//                CancellationToken ct = default)
//            {

//                return await db.Students.Where(s => s.IdGroup == null).Select(s =>
//                new StudentDTO
//                {
//                    Id = s.Id,
//                    FirstName = s.FirstName,

//                    LastName = s.LastName,

//                    Phone = s.Phone,

//                    Gender = s.Gender,

//                    IdGroup = s.IdGroup,
//                }).ToListAsync();
//            }

//        }

//    }
//}