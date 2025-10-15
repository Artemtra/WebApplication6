using MyMediator.Interfaces;
using WebApplication1.DB;
using WebApplication6.cqrs.Student;
using Microsoft.EntityFrameworkCore;


namespace WebApplication6.cqrs.Group
{
    public class ListGroupNoStudent : IRequest<IEnumerable<GroupDTO>>
    {
        ListStudentGroupNull studentGroupNull = null;



        public int IndexGroup4 { get; set; }
        public class ListStudentByGroupIndexCommandHandler :
            IRequestHandler<ListGroupNoStudent, IEnumerable<GroupDTO>>
        {

            private readonly Db131025Context db;
            public ListStudentByGroupIndexCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<GroupDTO>> HandleAsync(ListGroupNoStudent request,
                CancellationToken ct = default)
            {


                return await db.Groups.GroupJoin(db.Students,
                    g => g.Id,
                    s => s.IdGroup, (g, student) => new { Group = g, Students = student })
                    .Where(x => !x.Students.Any())
                    .Select(x => new GroupDTO
                    {
                        Id = x.Group.Id,
                        Title = x.Group.Title,
                        IdSpecial = x.Group.IdSpecial,

                    }).ToListAsync();
            }

        }

    }
}