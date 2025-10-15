using MyMediator.Interfaces;
using WebApplication1.DB;
using Microsoft.EntityFrameworkCore;


namespace WebApplication6.cqrs.Student
{
    public class ListStudentGender : IRequest<IEnumerable<StudentDTO>>
    {
                
        public int IndexGroup2 { get; set; }
        public class ListStudentByGroupIndexCommandHandler :
            IRequestHandler<ListStudentGender, IEnumerable<StudentDTO>>
        {

            private readonly Db131025Context db;
            public ListStudentByGroupIndexCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<StudentDTO>> HandleAsync(ListStudentGender request,
                CancellationToken ct = default)
            {

                return await db.Students.Where(s => s.Gender == request.IndexGroup2).Select(s =>
                new StudentDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,

                    LastName = s.LastName,

                    Phone = s.Phone,

                    Gender = s.Gender,

                    IdGroup = s.IdGroup,
                }).ToListAsync();
            }

        }
    }
}