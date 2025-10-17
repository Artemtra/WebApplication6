using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Text.RegularExpressions;
using WebApplication1.DB;
using WebApplication6.cqrs.Student;

namespace WebApplication6.cqrs.Group.Add
{
    public class AddGroup : IRequest
    {

        public GroupDTO Group { get; set; }
        

        public class ListGroupByGroupIndexCommandHandler :
            IRequestHandler<AddGroup, Unit>
        {

            private readonly Db131025Context db;
            public ListGroupByGroupIndexCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<Unit> HandleAsync(AddGroup request,
                CancellationToken ct = default)
            {
                WebApplication1.DB.Group group = new WebApplication1.DB.Group { Id = request.Group.Id, IdSpecial = request.Group.IdSpecial, Title = request.Group.Title };
                db.Groups.Add(group);
                await db.SaveChangesAsync();
                return Unit.Value;
                
            }

        }
    }
}
