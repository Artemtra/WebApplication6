using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;


namespace WebApplication6.cqrs.Student
{
    public class InfoStudentGroupNull : IRequest<IEnumerable<StudentDTO>>
    {
     
        public int IndexGroup3 { get; set; }
        public class ListStudentByGroupIndexCommandHandler :
            IRequestHandler<InfoStudentGroupNull, IEnumerable<StudentDTO>>
        {

            private readonly Db131025Context db;
            public ListStudentByGroupIndexCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<StudentDTO>> HandleAsync(InfoStudentGroupNull request,
                CancellationToken ct = default)
            {

                return await db.Students.Where(s => s.IdGroup == null).Select(s =>
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


